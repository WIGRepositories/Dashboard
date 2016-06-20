
var app = angular.module('myApp', [])
var ctrl = app.controller('myCtrl', function ($scope, $http) {

    $http.get('http://localhost:1476/api/Roledetails/getroledetails').then(function (res, data) {
        $scope.Roledetails = res.data;
    });
    $scope.save = function (Roledetails) {
        alert("ok");
        var Roledetails = {
            ObjectName: Roledetails.ObjectName,
            Path: Roledetails.Path,
           



        }

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/Roledetails/saveroledetails',
            data: Roledetails
        }
        $http(req).then(function (response) {
            alert('saved successfully.');

        });

    }
    
});






