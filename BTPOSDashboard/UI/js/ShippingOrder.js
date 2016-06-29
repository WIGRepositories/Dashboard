var app = angular.module('myApp', ['ngStorage']);
var ctrl = app.controller('myctrl', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname;
    $scope.dashboardDS = $localStorage.dashboardDS;


    $scope.GetShippingOrder = function () {

        $http.get('http://localhost:1476/api/ShippingOrder/GetShippingOrder').then(function (res, data) {
            $scope.ShippingOrder = res.data;
        });
    }

});