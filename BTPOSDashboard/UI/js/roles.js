// JavaScript source code
var myapp1 = angular.module('myApp', [])
var mycrtl1 = myapp1.controller('Mycntrlr', function ($scope, $http) {

    $http.get('http://localhost:1476/api/Roles/getroles').then(function (res, data) {
        $scope.roles = res.data;


    });
    $scope.save = function (roles) {
       
        var roles = {
            Id:roles.Id,
            Name: roles.Name,
            Description: roles.Description,
            Active: (roles.Active=true)?1:0

        };
      
        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/roles/saveroles',
            //headers: {
            //    'Content-Type': undefined

            data: roles


        }
        $http(req).then(function (response) { });

        $scope.currGroup = null;

    };

    $scope.setCompany = function (grp) {
        $scope.currGroup = grp;
    };

    $scope.clearGroup = function () {
        $scope.currGroup = null;
    };
});