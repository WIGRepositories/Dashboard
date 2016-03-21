var myapp1 = angular.module('myApp', [])
var myCtrl = myapp1.controller('Mycntrl', function ($scope, $http) {
   
    $scope.Signin = function () {
        alert();
        var u = $scope.UserName;
        var p = $scope.Password      

        var inputcred = { username: u, pwd: p }


        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/LOGIN/ValidateCredentials/',
            //headers: {
            //    'Content-Type': undefined

            data: inputcred
        }
        $http(req).then(function (res) {
            if (res.data[0]["result"] == "1")
                window.location.href = "index.html";
            else
                alert('invalid credentials');
        });
    }
});


   