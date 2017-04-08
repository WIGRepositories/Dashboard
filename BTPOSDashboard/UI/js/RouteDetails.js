// JavaScript source code
var myapp1 = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])

var mycrtl1 = myapp1.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;

    stopsList = [];
    $scope.RouteDetails = [];

    $scope.GetRoutes = function () {
        $http.get('/api/Routes/GetRoutes').then(function (res, data) {
            $scope.routes = res.data;
           // GetRouteDetails($scope.routes[0].Id);
        });
        
        $http.get('/api/Stops/GetStops').then(function (res, data) {
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
        $http.get('/api/routedetails/getroutedetails?routeid=' + route.Id).then(function (res, data) {
            $scope.RouteDetails = res.data;      
        });
    }

    $scope.SetCurrStop = function (currStop,indx)
    {
        //alert(currStop.StopName);
        $scope.currStop = currStop;
        $scope.currStopIndx = indx;
    }

    $scope.setNewStopCode = function (stp) {
        $scope.newNextStop.StopCode = stp.Code;
    }

    //This will hide the DIV by default.
    $scope.IsHidden = true;

    $scope.ShowHide = function () {
        //If DIV is hidden it will be visible and vice versa.
        $scope.IsHidden = $scope.IsHidden ? false : true;
    }
   
        $scope.save = function (RouteDetails) {
            
            
            var req = {
                method: 'POST',
                url: '/api/routedetails/saveroutedetails',
                //headers: {
                //    'Content-Type': undefined

                data: RouteDetails.Table1
            }
            $http(req).then(function (response) {

                //$scope.showDialog("Saved successfully!");

                $scope.Group = null;

            }, function (errres) {
                var errdata = errres.data;
                var errmssg = "";
                errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
                $scope.showDialog(errmssg);
            });
            $scope.currGroup = null;
        };

        $scope.addPrevStop = function (stop) {
            //  stopsList.splice(index, 0, stop);
            var newStop = {
                StopName: stop.stp.Name,
                StopCode: stop.StopCode,
                RouteId: $scope.s.Id,
                stopid: stop.stp.Id,
                PreviousStopId: $scope.currStop.PreviousStopId,
                prevstop: $scope.currStop.prevstop,
                nextstop: $scope.currStop.StopName,
                NextStopId: $scope.currStop.stopid,
                DistanceFromSource: stop.DistanceFromSource,
                DistanceFromDestination: stop.DistanceFromDestination,
                DistanceFromPreviousStop: stop.DistanceFromPreviousStop,
                DistanceFromNextStop: stop.DistanceFromNextStop,
                StopNo: $scope.currStop.StopNo,
                insupddelflag: 'I'
            }

            $scope.RouteDetails.Table1.splice($scope.currStopIndx, 0, newStop);

            for (var cnt = 0; cnt < $scope.RouteDetails.Table1.length; cnt++) {
                if ($scope.RouteDetails.Table1[cnt].insupddelflag == null || $scope.RouteDetails.Table1[cnt].insupddelflag != 'I') {

                    $scope.RouteDetails.Table1[cnt].insupddelflag = 'U';
                }
                $scope.RouteDetails.Table1[cnt].StopNo = cnt + 1;
            }
            $scope.currStop.PreviousStopId = stop.stp.Id;
            $scope.currStop.prevstop = stop.stp.Name;

            var prvStop = $scope.RouteDetails.Table1[$scope.currStopIndx - 1];
            prvStop.NextStopId = stop.stp.Id;
            prvStop.nextstop = stop.stp.Name;

        }

        $scope.addNextStop = function (stop) {
            //stopsList.splice(index, 0, stop);
            var newStop = {
                StopName: stop.stp.Name,
                StopCode: stop.StopCode,
                RouteId: $scope.s.Id,
                stopid: stop.stp.Id,
                PreviousStopId: $scope.currStop.stopid,
                prevstop: $scope.currStop.StopName,
                nextstop: $scope.currStop.nextstop,
                NextStopId: $scope.currStop.NextStopId,
                DistanceFromSource: stop.DistanceFromSource,
                DistanceFromDestination: stop.DistanceFromDestination,
                DistanceFromPreviousStop: stop.DistanceFromPreviousStop,
                DistanceFromNextStop: stop.DistanceFromNextStop,
                StopNo: $scope.currStop.StopNo + 1,
                insupddelflag: 'I'
            }
            $scope.currStop.NextStopId = stop.stp.Id;
            $scope.currStop.nextstop = stop.stp.Name;

            $scope.RouteDetails.Table1.splice($scope.currStopIndx + 1, 0, newStop);

            var nxtStop = $scope.RouteDetails.Table1[$scope.currStopIndx + 2];
            nxtStop.PreviousStopId = stop.stp.Id;
            nxtStop.prevstop = stop.stp.Name;


            for (var cnt = 0; cnt < $scope.RouteDetails.Table1.length; cnt++) {
                if ($scope.RouteDetails.Table1[cnt].insupddelflag == null || $scope.RouteDetails.Table1[cnt].insupddelflag != 'I') {
                    $scope.RouteDetails.Table1[cnt].insupddelflag = 'U';
                }
                $scope.RouteDetails.Table1[cnt].StopNo = cnt + 1;
            }

        }

        $scope.delStop = function (stop) {
            stopsList.splice(index, 0, stop);
        }

    $scope.showDialog = function (message) {

        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: 'myModalContent.html',
            controller: 'ModalInstanceCtrl',
            resolve: {
                mssg: function () {
                    return message;
                }
            }
        });
    }

});


myapp1.controller('ModalInstanceCtrl', function ($scope, $uibModalInstance, mssg) {

    $scope.mssg = mssg;
    $scope.ok = function () {
        $uibModalInstance.close('test');
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});
      
    
    
   

   
