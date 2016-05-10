// JavaScript source code
var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('myCtrl', function ($scope, $http,$localStorage) {
    $scope.uname = $localStorage.uname

    $scope.GetInventoryItems = function () {

        $http.get('http://localhost:1476/api/InventoryItem/GetInventoryItem?InventoryId=-1').then(function (response, req) {
            $scope.InventoryItem = response.data;

        });
    }
    $scope.GetInventoryPurchases = function () {
        $http.get('http://localhost:1476/api/InventoryPurchase/GetInventoryPurchases').then(function (res, data) {
            $scope.Group = res.data;
        });
    }
    $scope.getselectval = function (seltype) {
        var grpid = (seltype) ? seltype.Id : -1;
        //to save new inventory item
        $http.get('http://localhost:1476/api/InventoryItem/GetInventoryItem?InventoryId=' + grpid).then(function (res, data) {
            $scope.Group = res.data;
        });
    }
    $scope.savepurchases = function (Group) {

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
            url: 'http://localhost:1476/api/InventoryPurchase/SaveInventoryPurchases',
            data: Group
        }
        $http(req).then(function (response) {
            alert('saved successfully.');
        
        });
    }
    $scope.save = function (Group) {

        var Group = {
            Id:Group.Id,
            ItemName: Group.ItemName,
            Quantity: Group.Quantity,
            PerUnitPrice: Group.PerUnitPrice,
            PurchaseDate: Group.PurchaseDate,
            PurchaseOrderNumber: Group.PurchaseOrderNumber
        }

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/InventoryPurchase/SaveInventoryPurchases',
            data: Group
        }
        $http(req).then(function (response) {
            alert('saved successfully.');
        });
        $scope.Purchase1 = null;
    };

    $scope.setGroups = function (usr) {
        $scope.Purchase1 = usr;
    };
    $scope.clearPurchase1 = function () {
        $scope.Purchase1 = null;
    }


});






