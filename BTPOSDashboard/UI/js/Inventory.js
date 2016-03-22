// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', []);
var ctrl = app.controller('myCtrl', function ($scope, $http) {
    $http.get('http://localhost:1476/api/Inventory/GetInventory').then(function (response, req) {
        $scope.Group = response.data;

    });
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

            // "Id": 1, "Name": "hyioj", "Records": "bfdfsg",

        }


        var req = {
            
            method: 'POST',
            url: 'http://localhost:1476/api/Inventory/SaveInventory',
            data: Group
        }
        $http(req).then(function (response) { });
       
      
    };
});