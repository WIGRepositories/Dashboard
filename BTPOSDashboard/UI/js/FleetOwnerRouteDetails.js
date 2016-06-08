// JavaScript source code
var myapp1 = angular.module('myApp', [])

var mycrtl1 = myapp1.controller('Mycntrlr', function ($scope, $http) {

    stopsList = [];
    $scope.RouteDetails = [];

    $scope.GetRoutes = function () {
        $http.get('http://localhost:1476/api/FleetOwnerRouteDetails/GetRoutes').then(function (res, data) {
            $scope.routes = res.data;
            // GetRouteDetails($scope.routes[0].Id);
        });

        $http.get('http://localhost:1476/api/Stops/GetStops').then(function (res, data) {
            $scope.Stops = res.data;
        });

    }
    $scope.GetCompanies = function () {

        var vc = {
            needCompanyName: '1'
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/VehicleConfig/VConfig',
            //headers: {
            //    'Content-Type': undefined
            data: vc
        }
        $http(req).then(function (res) {
            $scope.initdata = res.data;
        });

    }

    $scope.GetFleetOwners = function () {
        if ($scope.cmp == null) {
            $scope.FleetOwners = null;
            return;
        }
        var vc = {
            needfleetowners: '1',
            cmpId: $scope.cmp.Id
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/VehicleConfig/VConfig',
            //headers: {
            //    'Content-Type': undefined

            data: vc


        }
        $http(req).then(function (res) {
            $scope.cmpdata = res.data;
        });
    }
  
    $scope.GetRouteDetails = function () {


        if ($scope.s == null) {
            $scope.routes = null;
            return;
        }
       
        var vc = {
            needroutes: '1',
            sId: $scope.s.Id
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/VehicleConfig/VConfig',
            //headers: {
            //    'Content-Type': undefined

            data: vc


        }
        $http(req).then(function (res) {
            $scope.sdata = res.data;
            GetRouteDetails1();
        });
    }

    $scope.GetRouteDetails1 = function (route) {
        if (route == null || route.Id == null) {
            //alert('Please select a route.');
            $scope.RouteDetails = [];
            return;
        }
        $http.get('http://localhost:1476/api/routedetails/getroutedetails1?routeid=' + route.Id).then(function (res, data) {
            $scope.RouteDetails = res.data;
        });
    }

});



