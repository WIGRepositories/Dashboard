// JavaScript source code
// JavaScript source code
var myapp1 = angular.module('myApp', [])
var mycrtl1 = myapp1.controller('Mycntrlr', function ($scope, $http) {

    $http.get('http://localhost:8020/api/Users1/Users').then(function (res, data) {
        $scope.User = res.data;


    });
    $scope.save = function (User) {                      
        alert("ok");
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
            
        };
        $scope.save
        var req = {
            method: 'POST',
            url: 'http://localhost:8020/api/Users1/Users1',
            //headers: {
            //    'Content-Type': undefined

            data: User


        }
        $http(req).then(function (response) { });

        alert("saved");
        $scope.User1 = null;
    };

    $scope.setUser = function (usr) {
        $scope.User1 = usr;
    };

    $scope.clearUser = function () {
        $scope.User1 = null;
    }
});
 