var app = angular.module('myApp', ['ngStorage'])

var ctrl = app.controller('Myctrlr', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname;
    $scope.dashboardDS = $localStorage.dashboardDS;

    /* user details functions */
    $scope.uname = $localStorage.uname;

    $scope.GetLicenses = function () {
        $http.get('/api/GetLicensePayments').then(function (response, req) {
            $scope.Group = response.data;

        });
    }

    

});
   
