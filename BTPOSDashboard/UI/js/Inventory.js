// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', []);
var ctrl = app.controller('myCtrl', function ($scope, $http) {
    $http.get('http://localhost:1476/api/Inventory/GetInventory').then(function (response, req) {
        $scope.Group = response.data;

    });
    $scope.save = function (Group) {
        
        var Group = {
            Name: Group.Name,
            Code: Group.Code,
            Description: Group.Description,
            AvailableQty: Group.AvailableQty,
            Category: Group.Category,
            SubCategory: Group.SubCategory,
            PerUnitPrice: Group.PerUnitPrice,
            ReorderPont: Group.ReorderPont,
            Active: (Group.Active==true)?0:1
          

            // "Id": 1, "Name": "hyioj", "Records": "bfdfsg",

        }


        var req = {
            
            method: 'POST',
            url: 'http://localhost:1476/api/Inventory/SaveInventory',
            data: Group
        }
        $http(req).then(function (response) {
            alert('saved successfully.');
        });


        $scope.Inventory = null;
    };

    $scope.setInventory = function (usr) {
        $scope.Inventory = usr;

    };

    $scope.clearInventory = function () {
        $scope.Inventory = null;
       
       
      
    };
});