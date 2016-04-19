var myapp1 = angular.module('myApp', [])
var myCtrl = myapp1.controller('Mycntrl', function ($scope, $http) {
   
    $scope.Signin = function () {
       
        var u = $scope.UserName;
        var p = $scope.Password      

        if (u == null)
        {
            alert('Please enter username');
            return;
        }

        if (p == null)
        {
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
                    window.location.href = "index.html";                
            }
        });
    }
});


   