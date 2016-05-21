// JavaScript source code
var app = angular.module('myApp', ['ngStorage'])

var ctrl = app.controller('Mycntrlr', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname;

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
        if (User == null) {
            alert('Please enter Email.');
            return;
           }

          if (User.Email.Name == null) {
            alert('Please enter Email.');
            return;
          }
          if (User == null) {
              alert('Please enter EmpNo.');
              return;
          }

          if (User.EmpNo == null) {
              alert('Please enter EmpNo.');
              return;
          }
          if (user == null)
          {
              alert('Please enter Adress');
          }
          if (user.AdressId == null)
          {
              alert('Please enter AdressId');
          }
          if (RoleId.group == null || RoleId.group.Id == null)
          {
              alert('Please select a type group');
              return;
          }
          if (User == null)
          {
              alert('Please enter Username');
          }
          if (User.UserName == null)
          {
              alert('Please enter Password');
          }

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


