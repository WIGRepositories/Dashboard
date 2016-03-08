// JavaScript source code
// JavaScript source code
var myapp1 = angular.module('myApp', [])
var mycrtl1 = myapp1.controller('Mycntrlr', function ($scope, $http) {

    $http.get('http://localhost:8020/api/Users1/Users1').then(function (res, data) {
        $scope.User = res.data;


    });
    $scope.save = function (User) {                      
        
        var User = {                  
            Id: User.Id,
            FirstName: User.FirstName,
            LastName: User.LastName,
            UserType: User.UserType,
           
            EmpNo: User.EmpNo,
            Email: User.Email,
            AdressId: User.AdressId,
            MobileNo: User.MobileNo,
            Role1:User.Role1,
            Active: User.Active
            
        }
     
        var req = {
            method: 'POST',
            url: 'http://localhost:8020/api/Users1/Users2',
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
 

