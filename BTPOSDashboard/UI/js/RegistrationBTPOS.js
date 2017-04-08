// JavaScript source code
var app = angular.module('myApp', [])
var ctrl = app.controller('myCtrl', function ($scope, $http) {
  
    $scope.save = function (Group) {
       // alert("saved");
        var RegistrationBTPOS = {
                
            code: Group.code,
            ipconfig:"100.100.100.01"
          
            

        }

        var req = {
            method: 'POST',
            url: '/api/RegistrationBTPOS/saveRegistrationBTPOS',

            data: RegistrationBTPOS

        }

        $http(req).then(function (response) { });
    };
});