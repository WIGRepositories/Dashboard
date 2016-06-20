var myapp1 = angular.module('myApp', ['ngStorage'])

var myCtrl = myapp1.controller('myCtrl', function ($scope, $http, $localStorage) {
    $scope.save = function (type) {

        var type = {

            UserName: type.UserName,
            oldPassword: type.oldPassword,
            newPassword: type.newPassword,
            reenternewPassword: type.reenternewPassword,

        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/UserLogins/ResetPassword',
            //headers: {
            //    'Content-Type': undefined
            data: type
        }
        $http(req).then(function (response) {

        })
    }



    $scope.Signin = function () {

        var u = $scope.UserName;
        var p = $scope.Password

        if (u == null) {
            alert('Please enter username');
            return;
        }

        if (p == null) {
            alert('Please enter password');
            return;
        }

        var inputcred = { LoginInfo: u, Passkey: p }


        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/LOGIN/ValidateCredentials/',
            data: inputcred
        }

        $http(req).then(function (res) {
            if (res.data.length == 0) {
                alert('invalid credentials');
            }
            else {
                //if the user has role, then get the details and save in session
                $localStorage.uname = res.data[0].name;
                $localStorage.userdetails = res.data;
                window.location.href = "index.html";
            }
        });
    }
});
