// JavaScript source code
var myapp1 = angular.module('myApp', [])

var mycrtl1 = myapp1.controller('Mycntrlr', function ($scope, $http) {

    stopsList = [];
    $scope.RouteDetails = [];

    $scope.GetRoutes = function () {
        $http.get('http://localhost:1476/api/Routes/GetRoutes').then(function (res, data) {
            $scope.routes = res.data;
           // GetRouteDetails($scope.routes[0].Id);
        });
        
        $http.get('http://localhost:1476/api/Stops/GetStops').then(function (res, data) {
            $scope.Stops = res.data;
        });
        
    }

    $scope.GetRouteDetails = function (route) {
        if (route == null || route.Id == null)
        {
            //alert('Please select a route.');
            $scope.RouteDetails = [];
            return;
        }
        $http.get('http://localhost:1476/api/routedetails/getroutedetails?routeid=' + route.Id).then(function (res, data) {
            $scope.RouteDetails = res.data;

        });
    }

    $scope.SetCurrStop = function (currStop,indx)
    {
        //alert(currStop.StopName);
        $scope.currStop = currStop;
        $scope.currStopIndx = indx;
    }
    //This will hide the DIV by default.
    $scope.IsHidden = true;

    $scope.ShowHide = function () {
        //If DIV is hidden it will be visible and vice versa.
        $scope.IsHidden = $scope.IsHidden ? false : true;
    }
   
        $scope.save = function (RouteDetails) {
            
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

        $scope.addPrevStop = function (stop) {
            //  stopsList.splice(index, 0, stop);
            var newStop = {
                StopName: stop.Name,
                StopCode: stop.Code
            }

            $scope.RouteDetails.Table1.splice($scope.currStopIndx + 1, 0, newStop);
        }

        $scope.addNextStop = function (stop) {
            //stopsList.splice(index, 0, stop);
            var newStop = {
                StopName: stop.Name,
                StopCode: stop.Code
            }

            $scope.RouteDetails.Table1.splice($scope.currStopIndx, 0, newStop);
        }

        $scope.delStop = function (stop) {
            stopsList.splice(index, 0, stop);
        }
    
    });
   

   
