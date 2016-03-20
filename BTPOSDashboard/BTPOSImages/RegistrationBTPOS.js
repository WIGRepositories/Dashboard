// JavaScript source code
var app = angular.module('myApp', [])
var ctrl = app.controller('myCtrl', function ($scope, $http) {
  
    $scope.save = function (Group) {
        window.location.href = "http://localhost:1476/BTPOSImages/poweron.html";


        //var RegistrationBTPOS = {                
        //    code: Group.code,
        //    ipconfig:"100.100.100.01"   
        //}

        //var req = {
        //    method: 'POST',
        //    url: 'http://localhost:1476/api/RegistrationBTPOS/saveRegistrationBTPOS',
        //    data: RegistrationBTPOS
        //}

        //$http(req).then(function (response) {
        //    window.location.href = "http://localhost:1476/BTPOSImages/poweron.html";
        //});
    };
});