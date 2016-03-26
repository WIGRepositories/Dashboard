// JavaScript source code
var app = angular.module('myApp', [])
var ctrl = app.controller('myCtrl', function ($scope, $http) {

    $scope.GoToConfirmation = function (code) {

        if (code == null) {
            alert('please enter valid fleet owner code or contact administrator.');
            return false;
        }
        else {
            $http.get('http://localhost:1476/api/fleetownerlicense/validatefleetowner?fleetownercode=' + code).then(function (response, req) {
                $scope.result = response.data;

                if ($scope.result > 0)
                    window.location.href = "http://localhost:1476/CommercialSite/LicenseConfirmation.html";
                else
                    alert('invalid fleet owner code');

            });
        }   
    };

    $scope.GoTobuy = function (code, units) {

        if (code == null) {
            alert('please enter valid fleet owner code or contact INTERBUS administrator.');
            return false;
        } else {
            if (units == null) {
                alert('please enter valid no. of units.');
                return false;
            }
            else {
                $http.get('http://localhost:1476/api/fleetownerlicense/updatebtpos?fleetownercode=' + code+ '&units='+units).then(function (response, req) {
                    $scope.result = response.data;

                    if ($scope.result == 0)
                        alert('invalid fleet owner code or BT POS units not available. Please contact INTERBUS admin');
                    else
                        alert('Please login into BT POS dashboard and activate the BT POS ' + units + ' unit(s)');
                    
                });
            }
        }
    };
});