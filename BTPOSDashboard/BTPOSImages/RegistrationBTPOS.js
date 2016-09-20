// JavaScript source code
var app = angular.module('myApp', [])
var ctrl = app.controller('myCtrl', function ($scope, $http) {
  
    $scope.save = function (Group) {

        if (Group.code == null) {
            alert('please enter valid fleet owner code or contact administrator.');
            return false;
        }
        else {
            $http.get('http://localhost:1476/api/fleetownerlicense/registerpos?fleetownercode=' + Group.code + '&ipconfig=' + Group.ipconfig).then(function (response, req) {
                $scope.result = response.data;

                if ($scope.result > 0)
                {
                    document.getElementById('txt').style.display = 'inline';
                }
                else
                    alert('invalid fleet owner code or ipconfig');

            });
        }        
       // window.location.href = "http://localhost:1476/BTPOSImages/poweron.html";


    };
});