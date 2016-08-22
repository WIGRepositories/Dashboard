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
                $localStorage.uname = res.data[0].uname;
                $localStorage.userdetails = res.data;
                var roleid = $localStorage.userdetails[0].roleid;
                switch (roleid)
                {
                  

                     case 1:
                        window.location.href = "UI/index.html";
                        break;
                    case 2:
                        window.location.href = "UI/Index_finAdmin.html";
                        break;                

                        
                    case 3:
                        window.location.href = "UI/Index_support.html";
                         break;
                    case 4:
                        window.location.href = "UI/Index_help.html";
                         break;
                    case 5:
                       window.location.href = "UI/Index_sales.html";
                         break;
                    case 6:
                       window.location.href = "UI/Index_FO.html";
                        break;
                    case 11:
                        window.location.href = "UI/Index_G.html";
                        break;
                    case 12:
                       window.location.href = "UI/Index_cmpUser.html";
                        break;
                    default:
                       window.location.href = "UI/index.html";
                        break;

                }
            }
        });
    }
});
