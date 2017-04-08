// JavaScript source code
var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {
    //$scope.uname = $localStorage.uname
   
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;

    $scope.GetInventoryItems = function () {

        $http.get('/api/InventoryItem/GetInventoryItem?InventoryId=-1').then(function (response, req) {
            $scope.InventoryItem = response.data;

        });
    }
    $scope.GetInventoryPurchases = function () {
        $http.get('/api/InventoryPurchase/GetInventoryPurchases').then(function (res, data) {
            $scope.Group = res.data;
        });
    }
    $scope.getselectval = function (seltype) {
        var grpid = (seltype) ? seltype.Id : -1;
        //to save new inventory item
        $http.get('/api/InventoryItem/GetInventoryItem?InventoryId=' + grpid).then(function (res, data) {
            $scope.Group = res.data;
        });
    }
    $scope.savepurchases = function (Group) {
        if (Group == null) {
            alert('please select Item')
        }
        if (Group.ItemName == null) {
            alert('please enter Itemname')
        }

        var Group = {
            Id:-1,
            ItemName: Group.ItemName.ItemName,
            subCategoryId: Group.ItemName.SubCategoryId,
            Quantity: Group.Quantity,
            PerUnitPrice: Group.PerUnitPrice,
            PurchaseDate: Group.PurchaseDate,
            PurchaseOrderNumber: Group.PurchaseOrderNumber
        }

        var req = {
            method: 'POST',
            url: '/api/InventoryPurchase/SaveInventoryPurchases',
            data: Group
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

    $scope.save = function (Group) {

        var Group = {
            Id: Group.Id,
            ItemName: Group.ItemName,
            Quantity: Group.Quantity,
            PerUnitPrice: Group.PerUnitPrice,
            PurchaseDate: Group.PurchaseDate,
            PurchaseOrderNumber: Group.PurchaseOrderNumber
        }

        var req = {
            method: 'POST',
            url: '/api/InventoryPurchase/SaveInventoryPurchases',
            data: Group
        }
        $http(req).then(function (response) {

           // $scope.showDialog("Saved successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };

    $scope.setGroups = function (usr) {
        $scope.Purchase1 = usr;
    };
    $scope.clearPurchase1 = function () {
        $scope.Purchase1 = null;
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






