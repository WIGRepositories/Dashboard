
var app = angular.module('myApp', [])
var ctrl = app.controller('Mycntrlr', function ($scope, $http) {

    $http.get('http://localhost:1476/api/InventoryItem/GetInventoryItem').then(function (res, data) {
        $scope.Item = res.data;
    });
    $scope.save = function (Item) {

        var Item = {
            Id: Item.Id,
            ItemName: Item.ItemName,
            Code: Item.Code,
            Description: Item.Description,
            Category: Item.Category,
            SubCategory: Item.SubCategory,
            ReOrderPoint: Item.ReOrderPoint,
          

          

       
        }

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/InventoryItem/SaveInventoryItem',
            data: Item
        }
        $http(req).then(function (res) {
            alert('saved successfully.');
        });


        $scope.Items1 = null;
    };

    $scope.setItems1 = function (usr) {
        $scope.Items1 = usr;
    };

    $scope.clearItems1 = function () {
        $scope.Items1 = null;
    }
});







