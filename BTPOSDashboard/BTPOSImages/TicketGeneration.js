// JavaScript source code
var app = angular.module('myApp', [])
var ctrl = app.controller('myCtrl', function ($scope, $http) {
    $scope.save = function (Group) {
        alert("saved");
        var Group = {
            Source: Group.Source,
            Target: Group.Target,
            NoOfTickets: Group.NoOfTickets

        }

        var req = {
            method: 'POST',
            url: 'http://154.120.237.198:1476/api/TicketGeneration/saveTicketGeneration',
            data: Group
        }
 
        $http(req).then(function (response) { });
    };
});
