// JavaScript source code
var myapp1 = angular.module('myApp', [])
var mycrtl1 = myapp1.controller('Mycntrlr', function ($scope, $http) {

    $http.get('http://localhost:1476/api/roles/getroles').then(function (res, data) {
        $scope.roles = res.data;


    });
    $scope.save = function (roles) {
        alert("ok");
        var roles = {
           
            Name: roles.Name,
            Description: roles.Description,
            Active:roles.Active

        };
      
        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/roles/saveroles',
            //headers: {
            //    'Content-Type': undefined

            data: roles


        }
        $http(req).then(function (res) { });

    };
});