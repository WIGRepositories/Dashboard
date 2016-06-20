// JavaScript source code

var myapp1 = angular.module('myApp', ['ngStorage'])
var mycrtl1 = myapp1.controller('myCtrl', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname;

    $scope.GetRoutes = function () {
        $http.get('http://localhost:1476/api/Routes/GetRoutes').then(function (res, data) {
            $scope.routes = res.data;
        });
    }

    $scope.GetStops = function () {
        $http.get('http://localhost:1476/api/Stops/GetStops').then(function (res, data) {          
            $scope.Stops = res.data;
        });
    }

    //$scope.myVar = false;
    //$scope.toggle = function () {
    //    $scope.myVar = !$scope.myVar;
    //};
    $scope.save = function (routes) {

        if (routes == null) {
            alert('Please enter Route');
            return;
        }
        if (routes.RouteName == null) {
            alert('plaease enter Route');
            return;

        }

        if (routes.Code == null) {
            alert('Please enter Code');
            return;
        }

        if (routes.Source == null) {
            alert('Please enter Source');
            return;
        }

        if (routes.Destination == null) {
            alert('Please enter Destination');
            return;
        }

        if (routes.Distance == null) {
            alert('Please enter Distance');
            return;
        }


        var newroute = {
            RouteName: routes.RouteName,
            Code: routes.Code,
            Description: routes.Description,
            Active: 1,//(routes.Active==true)?1:0,
            //BTPOSGroupId: routes.BTPOSGroupId,
            SourceId: routes.Source.Id,
            DestinationId: routes.Destination.Id,
            Distance: routes.Distance
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/Routes/SaveRoutes',
            //headers: {
            //    'Content-Type': undefined
            data: newroute
        }

        $http(req).then(function (res) {
           // alert('Route created successfully');
        });

        //insert the return route details if provided
        var needReturnRoute = document.getElementById('rtn').checked;

        if (needReturnRoute) {
            var retroutes = {
                RouteName: routes.ReturnRouteName,
                Code: routes.ReturnCode,
                Description: routes.Description,
                Active: 1,//(routes.Active==true)?1:0,
                //BTPOSGroupId: routes.BTPOSGroupId,
                SourceId: routes.Destination.Id,
                DestinationId: routes.Source.Id,
                Distance: routes.Distance
            };

            var req = {
                method: 'POST',
                url: 'http://localhost:1476/api/Routes/SaveRoutes',
                //headers: {
                //    'Content-Type': undefined
                data: retroutes
            }

            $http(req).then(function (res) {
                // alert('Route created successfully');
            });
        }
        alert('saved successfully.');
        $scope.routes = null;
    };
});