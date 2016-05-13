
// JavaScript source code
var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname

    $scope.GetFleetRoutes = function () {


        $http.get('http://localhost:1476/api/Routes/GetRoutes').then(function (res, data) {
            $scope.routes = res.data;
        });


    }
    $http.get('http://localhost:1476/api/Fleet/GetFleetConfigurations').then(function (res, data) {
        $scope.User = res.data;
    });

    $http.get('http://localhost:1476/api/FleetRoutes/GetFleetRoutes').then(function (res, data) {
        $scope.FleetRoute = res.data;

    });

    $scope.save = function (FleetRoute) {
        if(FleetRoute == null || FleetRoute.VehicleId == null){
            alert('Please select a type VehicleId');
            return;
        }
        if(FleetRoute == null || FleetRoute.RouteId == null){
            alert('Please select a type  RouteId ');
            return;
        }
     
        var FleetRoute = {
            Id: FleetRoute.Id,
            VehicleId: FleetRoute.VehicleId,
            RouteId: FleetRoute.RouteId,
            EffectiveFrom: FleetRoute.EffectiveFrom,
            EffectiveTill: FleetRoute.EffectiveTill,
            Active: FleetRoute.Active,

        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/FleetRoutes/NewFleetRoutes',
            //headers: {
            //    'Content-Type': undefined

            data: FleetRoute


        }
        $http(req).then(function (res) { });


    }

});





