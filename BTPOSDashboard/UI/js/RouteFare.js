// JavaScript source code
var myapp1 = angular.module('myApp', [])

var mycrtl1 = myapp1.controller('Mycntrlr', function ($scope, $http) {

    $scope.routefares =function () {
        $http.get('http://localhost:1476/api/RouteFare/getRouteFare?routeId=2&fleetownerId=2').then(function (res, data) {
            $scope.Stops = res.data;
        });

    $scope.GetStops = function () {
        $http.get('http://localhost:1476/api/Stops/GetStops').then(function (res, data) {
            $scope.Stops = res.data;
        });

    }

    $scope.test = function (dr) {
        alert(dr);
    }   

});



