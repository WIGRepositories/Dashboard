// JavaScript source code

var myapp1 = angular.module('myApp', [])
var mycrtl1 = myapp1.controller('Mycntrlr', function ($scope, $http) {

    $http.get('http://localhost:1476/api/Routes/GetRoutes').then(function (res, data) {
        $scope.routes = res.data;


    });
    $scope.myVar = false;
    $scope.toggle = function () {
        $scope.myVar = !$scope.myVar;
    };
    $scope.save = function (routes) {
        alert("ok");
        var routes = {
            Route: routes.Route,
            Code: routes.Code,
            Description: routes.Description,
            Active: routes.Active,
            BTPOSGroupId: routes.BTPOSGroupId,
            Source: routes.Source,
            Destination:routes.Destination
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/Routes/SaveRoutes',
            //headers: {
            //    'Content-Type': undefined

            data: routes


        }
        $http(req).then(function (res) { });

    };
});