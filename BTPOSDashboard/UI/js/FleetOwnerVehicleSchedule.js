var myapp1 = angular.module('myApp', [])

var mycrtl1 = myapp1.controller('Mycntrlr', function ($scope, $http) {
    $scope.StopCount = [];

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

    $scope.GetFORoutes = function () {


        if ($scope.s == null) {
            $scope.routes = null;
            return;
        }

        var vc = {
            needFleetOwnerRoutes: '1',
            fleetownerId: $scope.s.Id
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
            // GetRouteDetails1();
        });
    }

    $scope.GetRouteFleet = function () {

        var selCmp = $scope.cmp;

        if (selCmp == null) {
            $scope.FleetRoute = null;
            return;
        }
        var cmpId = (selCmp == null) ? -1 : selCmp.Id;

        var fr = {
            cmpId: selCmp.Id,
            routeid: $scope.r.RouteId,
            fleetownerId: $scope.s.Id,           
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/FleetRoutes/getFleetRoutesList',
            //headers: {
            //    'Content-Type': undefined
            data: fr
        }
        $http(req).then(function (res) {
            $scope.RouteFleet = res.data;
        });
    }

    $scope.GetVehicleSchedule = function () {
        $scope.RouteVehicleSchedule = [];
        if ($scope.r == null || $scope.r.RouteId == null) {
            //alert('Please select a route.');
            $scope.RouteVehicleSchedule = [];
            return;
        }
        $http.get('http://localhost:1476/api/FleetOwnerVehicleSchedule/getVehicleSchedule?fleetownerid=' + $scope.s.Id + '&routeid='
            + $scope.r.RouteId+'&vehicleId='+$scope.v.Id).then(function (res, data) {
            $scope.RouteVehicleSchedule = res.data;
        });
    }

    $scope.SetCurrStop = function (currStop, indx) {
        //alert(currStop.StopName);
        $scope.currStop = currStop;
        $scope.currStopIndx = indx;
    }


    $scope.GetshowDivStopDetails= function () {

        if (StopCount > 0) {

            document.getElementById("Stopdetails").style.display = 'inline';
        }
        else {
            document.getElementById("StopDetails").style.display = 'none';
        }
    }

});



