// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', [])
var ctrl = app.controller('Mycntrlr', function ($scope, $http) {

    $http.get('http://localhost:1476/api/Users/GetUsers').then(function (res, data) {
        $scope.User = res.data;


    });
    $scope.save = function (User) {
        alert("saved");
        var User = {
            Id: User.Id,
            FirstName: User.FirstName,
            LastName: User.LastName,
            UserType: User.UserType,
            EmpNo: User.EmpNo,
            Email: User.Email,
            AdressId: User.AdressId,
            MobileNo: User.MobileNo,
            Role: User.Role,
            Active: User.Active,
            UserName: User.UserName,
            Password: User.Password

        }

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/users/saveusers',
            data: User
        }
        $http(req).then(function (response) { });

        alert("saved");
        $scope.User1 = null;
    };

    $scope.setUsers = function (usr) {
        $scope.User1 = usr;
    };

    $scope.clearUsers = function () {
        $scope.User1 = null;
    }
});


