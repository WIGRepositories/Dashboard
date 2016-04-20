// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', [])
var ctrl = app.controller('myCtrl', function ($scope, $http) {

    $http.get('http://localhost:1476/api/Inventorysales/GetInventorySales').then(function (res, data) {
        $scope.Group = res.data;
    });
    $scope.save = function (Group) {

        var Group = {
            Id: Group.Id,
            ItemName: Group.ItemName,
            Quantity: Group.Quantity,
            PerUnitPrice: Group.PerUnitPrice,

            PurchaseDate: Group.PurchaseDate,

            InVoiceNumber:Group.InVoiceNumber
        }

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/Inventorysales/SaveInventorySales',
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






