
var app = angular.module('myApp', [])
var ctrl = app.controller('Mycntrlr', function ($scope, $http) {

    $http.get('http://localhost:1476/api/FleetAvailability/GetFleetAvailability').then(function (res, data) {
        $scope.FleetAvailability = res.data;
    });
    $scope.save = function (FleetAvailability) {
        if (FleetAvailability == null) {
            alert('Please values.');
            return;
        }

        if (FleetAvailability.Vehicle == null) {
            alert('Please enter Vehicle name.');
            return;
        }
        if (FleetAvailability.ServiceType == null) {
            alert('Please enter ServiceType.');
            return;
        }
        var FleetAvailability = {
            Id: -1,
            Vehicle: FleetAvailability.Vehicle,
            ServiceType: FleetAvailability.ServiceType,
            FromDate: FleetAvailability.FromDate,
            ToDate: FleetAvailability.ToDate
        }

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/fleetavailability/savefleetavailability',
            data: FleetAvailability
        }
        $http(req).then(function (response) {
            alert('saved successfully.');

        });

        $scope.currRole = null;

    };

    $scope.setCurrRole = function (grp) {
        $scope.currRole = grp;
    };

    $scope.clearCurrRole = function () {
        $scope.currRole = null;
    };
});






