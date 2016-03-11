
var app = angular.module('myApp', [])
var ctrl = app.controller('myCtrl', function ($scope, $http) {
    $http.get('http://localhost:1476/api/busdetails/busdetails1').then(function (response, req) {
        $scope.Group = response.data;

    });
    $scope.save = function (Group) {
        alert("saved");
        var Group = {
            busId: Group.busId,
            busTypeId: Group.busTypeId,
            conductorId: Group.conductorId,
            conductorName: Group.conductorName,

            driverId: Group.driverId,
            driverName: Group.driverName,
            fleetOwnerId: Group.fleetOwnerId,
            groupname: Group.groupname,
            Id: Group.Id,

            POSID: Group.POSID,
            RegNo: Group.RegNo,
            route: Group.route,
            Status: Group.Status,

            statusid: Group.statusid


            // "Id": 1, "Name": "hyioj", "Records": "bfdfsg",

        }


        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/busdetails/busdetails2',
            data: Group
        }
        $http(req).then(function (response) { });
    };
});
