var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname
    $scope.GetInventory = function () {

        $http.get('http://localhost:1476/api/InventoryStatus/getInventory').then(function (res, data) {
            $scope.Inventory = res.data.Table;
        });
    }
});