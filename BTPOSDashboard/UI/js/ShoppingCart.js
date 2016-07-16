var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname
    if ($localStorage.uname == null) {
       window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;


    $scope.cartitem = [];

    //get the items first (based on filters if any)
  //  $scope.items = [{ "name": "BT POS", "price": "10", "Id": "1" },
      //  { "name": "BT POS1", "price": "11", "Id": "3" }
      //  , { "name": "BT POS2", "price": "12", "Id": "2" }];



    $scope.increasecart = function (qty) {
        $scope.cartitem.push(qty);

        
            return $scope.cartitem;
     
    }
    $scope.GetItems = function () {
        $http.get('http://localhost:1476/api/ShoppingCart/GetItems').then(function (response, req) {
            $scope.items = response.data;
            $scope.itemsList = response.data;
        });
    }


    $scope.Save = function () {

        if ($scope.items == null) return;
        var Shoppingcart1 = [];
        var itemsList = $scope.Shoppingcarts;
        for (var cnt = 0; cnt < itemsList.length; cnt++) {

            var items = {
                //  Id: 1,
                Item: items.Item,
               // ItemName: items.ItemName,
                 UnitPrice: items.Unitprice,
                TransactionId: items.TransactionId,
                // Transaction_Num: items.Transaction_Num,
                amount: items.amount,
                //  PaymentMode: items.PaymentMode,
                Date: items.Date,
                // Transactionstatus: items.Transactionstatus,
                //Gateway_transId :items.Gateway_transId ,
                Quantity: items.Quantity,
                Id: items.Id,
                SalesOrderNum: items.SalesOrderNum,
                Status: items.Status
            }
            Shoppingcart1.push(items);

        }
        var items1 = {

            TransactionId: items.TransactionId,
           Transaction_Num: items.Transaction_Num,
            amount: items.amount,
           PaymentMode: items.PaymentMode,
            Transactionstatus: items.Transactionstatus,
            Gateway_transId: items.Gateway_transId,
            Date: items.Date,
           slist: Shoppingcart1
        }

        $http({
            url: 'http://localhost:1476/api/ShoppingCart/SaveCartItems',
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            data: items1,

        }).success(function (data, status, headers, config) {
            alert('saved successfully');
            window.location.href = "http://localhost:1476/UI/Payments.html";
        }).error(function (ata, status, headers, config) {
            alert(ata);
        });
    }
});
    //    $http(req).then(function (response) {

    //        $scope.showDialog("Saved successfully!");

    //        $scope.Group = null;

    //    }, function (errres) {
    //        var errdata = errres.data;
    //        var errmssg = "";
    //        errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
    //        $scope.showDialog(errmssg);
    //    });


    //}
    //$scope.showDialog = function (message) {

    //    var modalInstance = $uibModal.open({
    //        animation: $scope.animationsEnabled,
    //        templateUrl: 'myModalContent.html',
    //        controller: 'ModalInstanceCtrl',
    //        resolve: {
    //            mssg: function () {
    //                return message;
    //            }
    //        }
    //    });
    //}


app.controller('ModalInstanceCtrl', function ($scope, $uibModalInstance, mssg) {

   $scope.mssg = mssg;
    $scope.ok = function () {
        $uibModalInstance.close('test');
   };

   $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
  };
});

