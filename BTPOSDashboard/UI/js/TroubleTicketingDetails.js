// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname;
    $http.get('http://localhost:1476/api/TroubleTicketingDetails/getTroubleTicketingDetails').then(function (response, req) {
        $scope.Group = response.data;

    });
    $scope.save = function (Group) {
        if (Group == null)
        {
            alert('Please enter ticketTypeId ');
        }
        if (Group.ticketTypeId == null)
        {
            alert('Please enter ticketTypeId')
        }
        if(Group == null)
        {
            alert('Please enter   TTId ');
        }
        if (Group.TTId == null)
        {
            alert('please enter   TTId');
        }
        if (Group == null)
        {
            alert('Please enter createdBy ');
        }
        if (Group.createdBy == null)
        {
            alert('Please enter createdBy');
        }
        if (Group == null)
        {
            alert('please enter createdOn ')
        }
        if (Group.createdOn == null)
        {
            alert('Please enter createdOn')
        }
        if (Group == null)
        {
            alert('Please enter ticketinfo ');
        }
        if (Group.ticketinfo == null)
        {
            alert('Please enter ticketinfo');
        }
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

        $http(req).then(function (response) {
        
        });
    };
});