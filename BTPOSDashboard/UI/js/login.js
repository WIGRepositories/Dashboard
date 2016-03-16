// JavaScript source code
//function loginuser() {

//    if (document.getElementById('userid').value.toLowerCase() == 'pavani'
//        && document.getElementById('pwd').value.toLowerCase() == 'pavani') {
//        window.location = 'index.html';

//    }
//    else {
//        document.getElementById('loginstatus').innerHTML = 'invalid username';
//        return false;
//    }

////}
var myapp1 = angular.module('myApp', [])
var myCtrl = myapp1.controller('Mycntrl', function ($scope, $http) {
    alert('hai')
    $scope.Signin = function () {
        var u = $scope.UserName;
        var p = $scope.Password;

        $http.get('http://localhost:1476/api/LOGIN/ValidateCredentials?username=' + u + '&pwd=' + p).then(function (res,data) {
           
            if (res.data[0]["result"] == "1")
                window.location.href = "index.html";
            else
                alert('invalid credentials');
        });
    }
});


    //$http.get('http://localhost:49672/api/LOGIN/login').then(function (res, data) {
       
    //    $scope.alerts = res.data;
    //    alert("hi");
    //});

    //$scope.Signin = function (type) {
    //    alert("passvalues");
    //    var type = {
    //        UserName: type.UserName,
    //        Password: type.Password,
    //    }
    //    $scope.Signin
    //    var req = {
    //        method: 'POST',
    //        url: 'http://localhost:49672/api/ValidateCredentials/',
    //        //headers: {
    //        //    'Content-Type': undefined

    //        data: type
    //    }
    //    $http(req).then(function () {
    //    });

    //};



















        //alert("testing");
        ////$http.get('http://localhost:49672/api/LOGIN/login?result').success(function (response) {

        //    alert("back");
        //    //console.log(data);
        
        //    $http.post('http://localhost:49672/api/LOGIN/Password?Signin').success(function (response) {

                
//                if (data != null) {
//                    Window.href("/index.html");
//                }

//                else
//                    alert("error");

//            })
                    
//            });

    
//        };
     
//});
//var myapp1 = angular.module('myApp', [])
//var myCtrl = myapp1.controller('Mycntrlr', function ($scope, $http,$location)
//{

   
//    (function () {  
//        'use strict';  
//        app.controller('loginController', ['$scope', '$http', '$location', function ($scope, $http, $location) {  
  
//            $scope.Signin = {  
//                UserName: "",  
//                Password: ""  
//            }
//        }
        
//        }];
//    alert("hi");
  
//    $scope.Signin = function () {  
//        $http.Signin($scope.Signin. UserName, $scope.Signin.Password).then(function (response) {  
//            if (response != null && response.error != undefined) {  
//                $scope.message = response.error_description;  
//            }  
//            else {  
//                $location.path('/next');  
//            }  
//        }
        
//        }];
       
          