// JavaScript source code
var app = angular.module('myApp', [])
var ctrl = app.controller('myCtrl', function ($scope, $http) {
  
    $scope.save = function (Group) {
        alert("saved");
        var Group = {
                
            code: Group.code,
            ipconfig: Group.ipconfig
          
            // "Id": 1, "Name": "hyioj", "Records": "bfdfsg",

        }

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/RegistrationBTPOS/saveRegistrationBTPOS',

            data: Group

        }

        $http(req).then(function (response) { });
    };
});