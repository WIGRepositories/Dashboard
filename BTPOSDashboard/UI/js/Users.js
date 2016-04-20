// JavaScript source code
var app = angular.module('myApp', [])

var ctrl = app.controller('Mycntrlr', function ($scope, $http) {

    $scope.GetCompanyRoles = function (){
        $http.get('http://localhost:1476/api/Roles/getroles?companyId=-1').then(function (res, data) {
            $scope.companies = res.data;
        });
    }    

    $scope.GetUsers = function () {
        $http.get('http://localhost:1476/api/Users/GetUsers').then(function (res, data) {
            $scope.User = res.data;
        });
    }

    $scope.save = function (User, flag, role) {
     
        var User = {
            Id: User.Id,
            FirstName: User.FirstName,
            LastName: User.LastName,
            MiddleName:User.MiddleName,
            UserTypeId: (role) ? 2 : User.UserType,
            EmpNo: User.EmpNo,
            Email: User.Email,
            AdressId: User.AdressId,
            MobileNo: User.MobileNo,
            RoleId: (role) ? 2 : User.Role,
            Active: (User.Active == true) ? 1 : 0,
            UserName: User.UserName,
            Password: User.Password,
            insupdflag: flag
        }

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/users/saveusers',
            data: User
        }
        $http(req).then(function (response) {
            alert('saved successfully.');
        });

    
        $scope.User1 = null;
    };

    $scope.setUsers = function (usr) {
        $scope.User1 = usr;

    };

    $scope.clearUsers = function () {
        $scope.User1 = null;
    }
});


