var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname
    $scope.dashboardDS = $localStorage.dashboardDS;

    $scope.GetInventory = function () {

        $http.get('http://localhost:1476/api/InventoryStatus/GetInventory').then(function (response, req) {
            $scope.Inventory = response.data;

        });
    }
  
});