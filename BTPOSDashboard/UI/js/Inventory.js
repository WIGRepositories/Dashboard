// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap']);
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;

    $http.get('/api/Inventory/GetInventory').then(function (response, req) {
        $scope.Group = response.data;

    });
   
    $scope.getselectval = function (seltype) {
        var grpid = (seltype) ? seltype.id : -1;

        $http.get('/api/Inventory/GetInventory?groupid=' + grpid).then(function (res, data) {
            $scope.Group = res.data;

        });

        $scope.selectedvalues = 'Name: ' + $scope.selitem.name + ' Id: ' + $scope.selitem.id;

    }
   
    $scope.getselectval1 = function (seltype1) {
        var grpid = (seltype1) ? seltype1.id : -1;

        $http.get('/api/Inventory/GetInventory?groupid=' + grpid).then(function (res, data) {
            $scope.Group = res.data;

        });

        $scope.selectedvalues = 'Name: ' + $scope.selitem.name + ' Id: ' + $scope.selitem.id;

    }    
        
    //to save new inventory item
    $scope.saveNewItem = function (Item)
    {
        var invItem = {
            Active: Group.Active,
            availableQty: Group.availableQty,
            category: Group.category,
            code: Group.code,
            desc: Group.desc,
            InventoryId: Group.InventoryId,
            name: Group.name,        

            reorderpoint: Group.reorderpoint,
            subcat: Group.subcat
        }

        var req = {

            method: 'POST',
            url: '/api/Inventory/SaveInventory',
            data: invItem
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

    $scope.save = function (Group) {

        var Group = {
            Active: Group.Active,
            availableQty: Group.availableQty,
            category: Group.category,
            code: Group.code,
            desc: Group.desc,
            InventoryId: Group.InventoryId,
            name: Group.name,
            PerUnitPrice: Group.PerUnitPrice,
            reorderpoint: Group.reorderpoint,
            subcat: Group.subcat
        }
        var req = {

            method: 'POST',
            url: '/api/Inventory/SaveInventory',
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

    $scope.Inventory = null;

    $scope.setInventory = function (usr) {
        $scope.Inventory = usr;

    };

    $scope.clearInventory = function () {
        $scope.Inventory = null;


    };

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