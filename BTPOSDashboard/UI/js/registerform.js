// JavaScript source code
// JavaScript source code
var myapp1 = angular.module('myApp', [])
var mycrtl1 = myapp1.controller('myCtrl', function ($scope, $http) {

    //$http.get('/api/RegisterForm/logindb').then(function (res, data) {
    //    $scope.type = res.data;

    //    //alerts("hi");
    //});
    $scope.save = function (type) {
       
        var type = {

            UserName: type.username,
            Password: type.Password,
            ConfirmPassword: type.ConfirmPassword,
            Emailaddress: type.Emailaddress,
            FirstName: type.firstname,
            LastName: type.lastname,
            Gender:type.Gender,



        };

        var req = {
            method: 'POST',
            url: '/api/RegisterForm/pos',
            //headers: {
            //    'Content-Type': undefined

            data: type


        }
        $http(req).then(function (response) { });

    }

});