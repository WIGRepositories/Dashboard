// JavaScript source code
var myapp1 = angular.module('myApp', [])
var mycrtl1 = myapp1.controller('Mycntrlr', function ($scope, $http) {

    $http.get('http://localhost:8020/api/Roles/roles').then(function (res, data) {
        $scope.roles = res.data;


    });
    $scope.save = function (roles) {
        alert("ok");
        var roles = {
            Id: roles.Id,
            Name:roles.Name,
            Desc:roles.Desc,
            Active:roles.Active

        };
       
        var req = {
            method: 'POST',
            url: 'http://localhost:8020/api/Roles/role',
            //headers: {
            //    'Content-Type': undefined

            data: roles


        }
        $http(req).then(function (res) { });

    };
});