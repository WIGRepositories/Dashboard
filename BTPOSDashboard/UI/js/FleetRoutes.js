// JavaScript source code
var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname

    $scope.GetVehicleConfig = function () {

        var vc = {
            needvehicleRegno: '1',
            needRoutes: '1'
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

    $scope.GetFleetRoutes = function () {      

        $http.get('http://localhost:1476/api/FleetRoutes/getFleetRoutesList?routeid=-1').then(function (res, data) {
            $scope.FleetRoute = res.data;

        });
    }

    $scope.GetFleetRouteInit = function () {

        $http.get('http://localhost:1476/api/FleetRoutes/GetFleetList').then(function (res, data) {
            $scope.FleetRouteinit = res.data.Table;
        });

    }

    $scope.save = function (FleetRoute) {
        if(FleetRoute == null || FleetRoutes.VehicleId == null){
            alert('Please select a type VehicleId');
            return;
        }
        if(FleetRoute == null || FleetRoutes.RouteId == null){
            alert('Please select a type  RouteId ');
            return;
        }
     
        var FleetRoute = {
            Id: FleetRoutes.Id,
            VehicleId: FleetRoutes.VehicleId,
            RouteId: FleetRoutes.RouteId,
            EffectiveFrom: FleetRoutes.EffectiveFrom,
            EffectiveTill: FleetRoutes.EffectiveTill,
            Active: FleetRoutes.Active,

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
            VehicleId: newFR.v.Id,          
            RouteId: newFR.r.ID,
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





