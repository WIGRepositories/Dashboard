/// <reference path="DataLoad.js" />
var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {

    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;
    $scope.GetDataLoad = function () {

        $http.get('http://localhost:1476/api/DataLoad/GetDataLoad').then(function (response, req) {
            $scope.GetDataLoad = response.data;
        });
    }
});