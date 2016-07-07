// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;

    $http.get('http://localhost:1476/api/TroubleTicketingDetails/getTroubleTicketingDetails').then(function (response, req) {
        $scope.Group = response.data;

    });
    $scope.save = function (Group) {
        if (Group == null)
        {
            alert('Please enter ticketTypeId ');
            return;
        }        
        var Group = {
            RefId: Group.RefId,
            Type: Group.Type,
            createdBy: Group.createdBy,
            Id: Group.Id,
            Raised: Group.Raised,
            TicketTitle: Group.TicketTitle,
            IssueDetails: Group.IssueDetails,
            AddInfo: Group.AddInfo,
            Status: Group.Status,
            Asign: Group.Asign,

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