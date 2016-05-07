// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('Mycntrlr', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname;
    $http.get('http://localhost:1476/api/Stops/GetStops').then(function (res, data) {
        $scope.Stops = res.data;
    });
    $scope.save = function (Stops, flag) {
        if (Stops == null)
        {
            alert('Please Enter Name');
        }
        if (Stops.Name == null)
        {
            alert('Please Enter Nmae');
        }
        if (Stops == null)
        {
            alert('Please enter Code');
        }
        if (Stops.Code == null)
        {
            alert('Please Enter Code');
        }

        var Stops = {
            Id: Stops.Id,
           Name: Stops.Name,
           Description: Stops.Description,
            Code: Stops.Code,
           
            Active: (Stops.Active == true) ? 1 : 0,
          
            insupdflag: "I"
        }

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/Stops/saveStops',
            data: Stops
        }
        $http(req).then(function (response) {
            alert('saved successfully.');
       
        });


        $scope.Stops1 = null;
    };

    $scope.setStops = function (usr) {
        $scope.Stops1 = usr;
    };

    $scope.clearStops = function () {
        $scope.Stops1 = null;
    }
});

   




