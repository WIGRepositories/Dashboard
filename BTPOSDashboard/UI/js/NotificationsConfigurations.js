// JavaScript source code
var app = angular.module('myApp', ['ngStorage'])

var cntrlr = app.controller('myCtrl', function ($scope, $http, $localStorage) {
    $scope.dashboardDS = $localStorage.dashboardDS;



    $http.get('http://localhost:1476/api/Roles/GetRoles?allroles=-1').then(function (response, data) {
        $scope.GetRoles = response.data;
    });


    /* user details functions */
    $scope.GetNoticationConfiguration = function () {
        $http.get('http://localhost:1476/api/NotficationConfiguration/GetNoticationConfiguration').then(function (response, data) {
            $scope.NotficationConfiguration = response.data;
        });
    }
});