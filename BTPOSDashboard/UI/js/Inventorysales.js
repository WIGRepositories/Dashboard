// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var ctrl = app.controller('myCtrl', function ($scope, $http,$localStorage) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;


    $scope.GetInventoryItem = function () {

        $http.get('/api/InventoryItem/GetInventoryItem?InventoryId=-1').then(function (response, req) {
            $scope.InventoryItem = response.data;

        });
    }
        $scope.GetInventorySales = function () {
            $http.get('/api/Inventorysales/GetInventorySales').then(function (res, data) {
                $scope.Sales = res.data;
            });
        }


    $scope.getselectval = function (seltype) {
        var grpid = (seltype) ? seltype.Id : -1;
        //to save new inventory item
        $http.get('/api/InventoryItem/GetInventoryItem?InventoryId=' + grpid).then(function (res, data) {
            $scope.Sales = res.data;
        });
    }


    $scope.savenewsales = function (Sales) {

        var Sales = {
            Id:-1,
            ItemName: Sales.ItemName.ItemName,
            Quantity: Sales.Quantity,
            PerUnitPrice: Sales.PerUnitPrice,
            PurchaseDate: Sales.PurchaseDate,
            InVoiceNumber: Sales.InVoiceNumber
        }

        var req = {
            method: 'POST',
            url: '/api/Inventorysales/SaveInventorySales',
            data: Sales
        }

        $http(req).then(function (response) {

        //    $scope.showDialog("Saved successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };

    $scope.save = function (Sales) {

        var Sales = {
            Id: Sales.Id,
            ItemName: Sales.ItemName,
            Quantity: Sales.Quantity,
            PerUnitPrice: Sales.PerUnitPrice,
            PurchaseDate: Sales.PurchaseDate,
            InVoiceNumber: Sales.InVoiceNumber
        }

        var req = {
            method: 'POST',
            url: '/api/Inventorysales/SaveInventorySales',
            data: Sales
        }
        $http(req).then(function (response) {

          //  $scope.showDialog("Saved successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };


    $scope.Sales1 = null;


    $scope.setSales = function (usr) {
        $scope.Sales1 = usr;
    };
    $scope.clearSales = function () {
        $scope.Sales1 = null;
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



