// JavaScript source code
var myapp1 = angular.module('myApp', [])
var mycrtl1 = myapp1.controller('Mycntrlr', function ($scope, $http) {

    $http.get('http://localhost:1476/api/roles/roles').then(function (res, data) {
        $scope.roles = res.data;


    });
    $scope.save = function (roles) {
      
        var roles = {
            Id: roles.Id,
            Name:roles.Name,
            Desc:roles.Desc,
            Active:roles.Active

        };
        $scope.save
        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/roles/role',
            //headers: {
            //    'Content-Type': undefined

            data: roles


        }
        $http(req).then(function (res) { });

    };
});