// JavaScript source code
var app = angular.module('myApp', []);
var ctrl = app.controller('myCtrl', function ($scope, $http) {
    $scope.save = function (Group) {
        alert("saved");
        var TicketGeneration = {
            Source: Group.Source,
            Target: Group.Target,
            NoOfTickets: group.NoOfTickets

        }

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/TicketGeneration/saveTicketGeneration',
            data: TicketGeneration
        }
        alert('saving');
        $http(req).then(function (response) { });
    };
});
