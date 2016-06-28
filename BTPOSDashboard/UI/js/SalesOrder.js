var app = angular.module('myApp', ['ngStorage']);
var ctrl = app.controller('myctrl', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname;
    $scope.dashboardDS = $localStorage.dashboardDS;


    $scope.GetSalesOrder = function () {

        $http.get('http://localhost:1476/api/SalesOrder/GetSalesOrder').then(function (res, data) {
            $scope.SalesOrder = res.data;
        });
    }

});