// JavaScript source code
var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname

    $scope.GetVehicleConfig = function () {


        $http.get('http://localhost:1476/api/FleetRoutes/GetVehicleConfig(VehicleConfig vc)').then(function (res, data) {
            $scope.initdata = res.data;
        });


    }
    $scope.GetFleetRoutes = function () {      

        $http.get('http://localhost:1476/api/FleetRoutes/getFleetRoutesList').then(function (res, data) {
            $scope.FleetRoute = res.data;

        });
    }

    $scope.GetFleetRouteInit = function () {

        $http.get('http://localhost:1476/api/FleetRoutes/GetFleetList').then(function (res, data) {
            $scope.FleetRouteinit = res.data.Table;
        });

    }
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

    $scope.saveNewFleetRoutes = function (initdata) {
        var newFR = initdata.newfleet;
        /* if (newVD == null) {
             alert('Please enter VehicleRegNo.');
             return;
         }
 
         if (newVD.VehicleRegNo == null) {
             alert('Please enter VehicleRegNo.');
             return;
         }
         if (Fleet.group == null || Fleet.VehicleTypeId.group.Id == null) {
             alert('Please select a type group');
             return;
         }
         */




        var FleetRouters = {
            Id:-1 ,
            VehicleId: newFR.VehicleId,
            VehicleRegNo:newFR.VehicleRegNo,

            RouteId: newFR.RouteId,
            EffectiveFrom: newFR.EffectiveFrom,
            EffectiveTill: newFR.EffectiveTill,
            Active: 1,


        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/FleetRoutes/NewFleetRoutes',
            //headers: {
            //    'Content-Type': undefined

            data: FleetRouters
        }

        $http(req).then(function (res) {
            alert('Sucessfully saved!');
        });


    }
});





