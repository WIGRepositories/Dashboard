// JavaScript source code
var app = angular.module('myApp', [])
var ctrl = app.controller('myCtrl', function ($scope, $http) {

    $scope.save = function (Group) {
        alert("saved");
        var TG = {

            Source: Group.Source,
            Target: Group.Target,
            NoOfTickets: Group.NoOfTickets
           



        }

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/TicketGeneration/saveTicketGeneration',

            data: TG

        }

        $http(req).then(function (response) { });
    };
});// JavaScript source code
