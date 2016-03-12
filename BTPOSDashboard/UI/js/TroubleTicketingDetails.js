// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', [])
var ctrl = app.controller('myCtrl', function ($scope, $http) {
    $http.get('http://localhost:1476/api/GetTroubleTicketingDetails').then(function (response, req) {
        $scope.Group = response.data;

    });
    $scope.save = function (Group) {
        alert("saved");
        var Group = {
            addInfo: Group.addInfo,
            createdBy: Group.createdBy,
            createdOn: Group.createdOn,
            Id: Group.Id,
            raisedBy: Group.raisedBy,
            status: Group.status,
            ticketinfo: Group.ticketinfo,
            ticketTypeId: Group.ticketTypeId,
            TTId: Group.TTId
            // "Id": 1, "Name": "hyioj", "Records": "bfdfsg",

        }


        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/TroubleTicketingDetails/saveTroubleTicketingDetails',

            data: Group

        }

        $http(req).then(function (response) { });
    };
});