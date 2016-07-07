// JavaScript source code
var myapp1 = angular.module('myApp', ['ngStorage'])

var mycrtl1 = myapp1.controller('myCtrl', function ($scope, $http, $localStorage) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;

    $scope.GetRoutes = function () {
        $http.get('http://localhost:1476/api/Routes/GetRoutes').then(function (res, data) {
            $scope.routes = res.data;
            // GetRouteDetails($scope.routes[0].Id);
        });
        
        $http.get('http://localhost:1476/api/Stops/GetStops').then(function (res, data) {
            $scope.Stops = res.data;
        });
        
    }

    $scope.GetRouteFareDetails = function () {
        $http.get('http://localhost:1476/api/RouteFare/getRouteFare?routeId='+$scope.s.Id).then(function (res, data) {
            $scope.routefares = res.data;
        });
    }

    $scope.GetStops = function () {
        $http.get('http://localhost:1476/api/Stops/GetStops').then(function (res, data) {
            $scope.Stops = res.data;
        });

    }

    $scope.test = function (dr) {
        alert(dr);
    }   

});



