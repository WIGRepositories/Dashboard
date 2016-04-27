// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('myCtrl', function ($scope, $http,$localStorage) {
    $scope.uname = $localStorage.uname

    $scope.GetInventoryItem = function () {

        $http.get('http://localhost:1476/api/InventoryItem/GetInventoryItem?InventoryId=-1').then(function (response, req) {
            $scope.InventoryItem = response.data;

        });
    }
        $scope.GetInventorySales = function () {
            $http.get('http://localhost:1476/api/Inventorysales/GetInventorySales').then(function (res, data) {
                $scope.Sales = res.data;
            });
        }


    $scope.getselectval = function (seltype) {
        var grpid = (seltype) ? seltype.Id : -1;
        //to save new inventory item
        $http.get('http://localhost:1476/api/InventoryItem/GetInventoryItem?InventoryId=' + grpid).then(function (res, data) {
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
            url: 'http://localhost:1476/api/Inventorysales/SaveInventorySales',
            data: Sales
        }

        $http(req).then(function (response) {
            alert('saved successfully.');

        });
    }
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
                url: 'http://localhost:1476/api/Inventorysales/SaveInventorySales',
                data: Sales
            }
            $http(req).then(function (response) {
                alert('saved successfully.');

            });


        $scope.Sales1 = null;
    };

    $scope.setSales = function (usr) {
        $scope.Sales1 = usr;
    };
    $scope.clearSales = function () {
        $scope.Sales1 = null;
    }

   
});






