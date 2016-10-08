// JavaScript source code
// JavaScript source code
var myapp1 = angular.module('myApp', [])
var mycrtl1 = myapp1.controller('myCtrl', function ($scope, $http) {

    $scope.getdata = function () {
        $http.get('/api/registrationform/getregdata').then(function (res, data) {
            $scope.register = res.data;

            //alerts("hi");
        });
    }
    $scope.save = function (register) {

        var type = {

            UserName: register.username,
            Password: register.Password,
            ConfirmPassword: register.ConfirmPassword,
            Emailaddress: register.Emailaddress,
            FirstName: register.firstname,
            LastName: register.lastname,
            Gender: register.Gender,


            
        };

        var req = {
            method: 'POST',
            url: '/api/registrationform/pos',
            //headers: {
            //    'Content-Type': undefined

            data: type


        }
        $http(req).then(function (response) { });

    }

});