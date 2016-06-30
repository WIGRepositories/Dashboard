
// JavaScript source code
var myapp1 = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])

var mycrtl1 = myapp1.controller('myCtrl', function ($scope, $http, $localStorage) {
    $scope.dashboardDS = $localStorage.dashboardDS;


    stopsList = [];
    $scope.RouteDetails = [];

    //$scope.GetRoutes = function () {
    //    $http.get('http://localhost:1476/api/FleetOwnerRouteDetails/GetRoutes').then(function (res, data) {
    //        $scope.routes = res.data;
    //        // GetRouteDetails($scope.routes[0].Id);
    //    });

    //    $http.get('http://localhost:1476/api/Stops/GetStops').then(function (res, data) {
    //        $scope.Stops = res.data;
    //    });

    //}
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

    $scope.GetRouteDetails = function () {
        $scope.RouteDetails = [];
        if ($scope.r == null || $scope.r.RouteId == null) {
            //alert('Please select a route.');
            $scope.RouteDetails = [];
            return;
        }
        $http.get('http://localhost:1476/api/FleetOwnerRouteDetails/GetFleetOwnerRouteDetails?fleetownerid=' + $scope.s.Id + '&routeid=' + $scope.r.RouteId).then(function (res, data) {
            $scope.RouteDetails = res.data;
        });
    }

    $scope.SetCurrStop = function (currStop, indx) {
        //alert(currStop.StopName);
        $scope.currStop = currStop;
        currStop.newassigned = currStop.assigned;
        $scope.currStopIndx = indx;
    }

    $scope.save = function () {

        if ($scope.s == null) {         
            return;
        }       

        var stops = $scope.RouteDetails.Table1;

        var fleetownerstops = new Array();
        for (i = 0; i < stops.length; i++) {
            if (stops[i].newassigned != null  && stops[i].assigned != stops[i].newassigned) {
                var item = {
                    "FleetOwnerId": $scope.s.Id,
                    "RouteId": $scope.r.RouteId,
                    "StopId": stops[i].stopid,
                    "insupddelflag": (stops[i].newassigned == "1") ? "I" : "D"
                }
                fleetownerstops.push(item)
            }
        }
       
        if (fleetownerstops.length == 0) return;
        //write the post logic and test
        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/FleetOwnerRouteDetails/SaveFleetOwnerRouteDetails',
            data: fleetownerstops

        }
        $http(req).then(function (response) {

            $scope.showDialog("Saved successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };

    $scope.showDialog = function (message) {

        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: 'myModalContent.html',
            controller: 'ModalInstanceCtrl',
            resolve: {
                mssg: function () {
                    return message;
                }
            }
        });
    }

});


