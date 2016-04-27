// JavaScript source code
var myapp1 = angular.module('myApp', [])

var mycrtl1 = myapp1.controller('Mycntrlr', function ($scope, $http) {

    $http.get('http://localhost:1476/api/routedetails/getroutedetails').then(function (res, data) {
        $scope.RouteDetails = res.data;

    });

 
   
        $scope.save = function (RouteDetails) {
            alert("ok");
            var RouteDetails = {
                Id:RouteDetails.Id,
                RouteId: RouteDetails.RouteId,
                stopname: RouteDetails.stopname,
                Description: RouteDetails.Description,
                StopCode: RouteDetails.StopCode,
                DistanceFromSource: RouteDetails.DistanceFromSource,
                DistanceFromDestination: RouteDetails.DistanceFromDestination,
                DistanceFromPreviousStop: RouteDetails.DistanceFromPreviousStop,
                DistanceFromNextStop: RouteDetails.DistanceFromNextStop


            };
     
            var req = {
                method: 'POST',
                url: 'http://localhost:1476/api/routedetails/saveroutedetails',
                //headers: {
                //    'Content-Type': undefined

                data: RouteDetails


            }
            $http(req).then(function (res) { });


        }
    
    });
   

   
