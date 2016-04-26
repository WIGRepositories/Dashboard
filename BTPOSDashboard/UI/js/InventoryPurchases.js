// JavaScript source code
// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('myCtrl', function ($scope, $http,$localStorage) {
    $scope.uname=$localStorage.uname
    $http.get('http://localhost:1476/api/InventoryPurchase/GetInventoryPurchases').then(function (res, data) {
        $scope.Group = res.data;
    });
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
            url: 'http://localhost:1476/api/InventoryPurchase/SaveInventoryPurchases',
            data: Group
        }
        $http(req).then(function (response) {
            alert('saved successfully.');
        
        });


        $scope.Sales1 = null;
    };

    $scope.setSales = function (usr) {
        $scope.Sales1 = usr;
    };


});






