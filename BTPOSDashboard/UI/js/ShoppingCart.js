var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;


    $scope.cartitem = [];

    //get the items first (based on filters if any)
    $scope.items = [{ "name": "BT POS", "price": "10", "Id": "1" },
        { "name": "BT POS1", "price": "11", "Id": "3" }
        , { "name": "BT POS2", "price": "12", "Id": "2" }];



    $scope.increasecart = function (qty) {
        $scope.cartitem.push(qty);

        
            return $scope.cartitem;
     
    }
    $scope.GetItems = function () {
        $http.get('http://localhost:1476/api/ShoppingCart/GetItems').then(function (response, req) {
            $scope.items = response.data;
        });
    }


    $scope.Save = function (items) {

        if (items == null) {
            alert('Please select any item.');
            return;
        }
        var items = {
            Id: -1,
            ItemId: items.ItemId,
            ItemName: items.ItemName,
            UnitPrice: items.UnitPrice

           
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/ShoppingCart/SaveCartItems',
            //headers: {
            //    'Content-Type': undefined
            data: items
        }
        $http(req).then(function (response) {

            $scope.showDialog("Saved successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });


    }
    $scope.showDialog = function (message) {

        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: 'myModalContent.html',
            controller: 'ModalInstanceCtrl',
            resolve: {
                mssg: function () {
                    return message;
                }
            }
        });
    }

});
app.controller('ModalInstanceCtrl', function ($scope, $uibModalInstance, mssg) {

    $scope.mssg = mssg;
    $scope.ok = function () {
        $uibModalInstance.close('test');
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});

