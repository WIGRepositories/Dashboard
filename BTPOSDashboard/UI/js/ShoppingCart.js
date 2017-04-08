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

    ////get the items first (based on filters if any)
    //$scope.items = [{ "name": "BT POS", "price": "10", "Id": "1" },
    //    { "name": "BT POS1", "price": "11", "Id": "3" }
    //    , { "name": "BT POS2", "price": "12", "Id": "2" }];

    $scope.additem = [];

   // $scope.cnt = 0;
    $scope.addtocart = function (items) {
        if (items == null)
            return cnt= null;
        else {
            $scope.additem.push(items);
         //   return $scope.additem;
           // return cnt;
        }
    }

    $scope.increasecart = function (qty) {
        v = parseInt(document.getElementById(qty).value);
        document.getElementById(qty).value = v + 1;
        //$scope.cartitem.push(qty);

            return v;
     
    }
    //$scope.decrementcart = function (qty) {
    //   // javascript: document.getElementById("qty").value--;
    //    $scope.cartitem.push(qty);


    //    return $scope.cartitem;

    //}

    $scope.GetItems = function () {
        $http.get('/api/ShoppingCart/GetItems').then(function (response, req) {
            $scope.sitems = response.data;
            $scope.Shoppingcarts = $scope.sitems;
        });
    }

    $scope.GetItems1 = function () {
        $http.get('/api/ShoppingCart/GetItems1').then(function (response, req) {
            $scope.items = response.data;
            $scope.Shoppingcarts = $scope.items;
        });
    }

    $scope.Save = function () {

        if ($scope.items == null)
            return null;
        var Shoppingcart1 = [];
        var itemsList = $scope.Shoppingcarts;
        for (var cnt = 0; cnt < itemsList.length; cnt++) {

            var items = {
                // Id: items.Id,
                 ItemId: items.ItemId,
               // ItemName: items.ItemName,
                // UnitPrice: items.Unitprice,
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
            url: '/api/ShoppingCart/SaveCartItems',
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            data: items1,

        }).success(function (data, status, headers, config) {
            //alert('saved successfully');
            window.location.href = "/UI/CheckOut.html";
        }).error(function (ata, status, headers, config) {
            alert(ata);
        });
      
    }
    $scope.CheckOut = function () {
        window.location.href = "/UI/CheckOut.html";
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

