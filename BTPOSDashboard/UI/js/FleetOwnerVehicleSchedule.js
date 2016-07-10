//var myapp1 = angular.module('myApp', ['timepicker'])
var myapp1 = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])

angular.module('myApp').directive('ngOnFinishRender', function ($timeout, $localStorage) {
    
    return {
        restrict: 'A',
        link: function (scope, element, attr) {
            if (scope.$last === true) {
                $timeout(function () {
                    scope.$emit(attr.broadcastEventName ? attr.broadcastEventName : 'ngRepeatFinished');
                });
            }
        }
    };
   
});

var mycrtl1 = myapp1.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {
   
    $scope.dashboardDS = $localStorage.dashboardDS;
    $scope.StopCount = [];

    $scope.GetCompanies = function () {

        var vc = {
            needCompanyName: '1'
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/VehicleConfig/VConfig',
            //headers: {
            //    'Content-Type': undefined
            data: vc
        }
        $http(req).then(function (res) {
            $scope.initdata = res.data;
        });

    }


    $scope.GetFleetOwners = function () {
        if ($scope.cmp == null) {
            $scope.FleetOwners = null;
            return;
        }
        var vc = {
            needfleetowners: '1',
            cmpId: $scope.cmp.Id
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/VehicleConfig/VConfig',
            //headers: {
            //    'Content-Type': undefined

            data: vc


        }
        $http(req).then(function (res) {
            $scope.cmpdata = res.data;
        });
    }

    $scope.GetFORoutes = function () {


        if ($scope.s == null) {
            $scope.routes = null;
            return;
        }

        var vc = {
            needFleetOwnerRoutes: '1',
            fleetownerId: $scope.s.Id
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/VehicleConfig/VConfig',
            //headers: {
            //    'Content-Type': undefined

            data: vc


        }
        $http(req).then(function (res) {
            $scope.sdata = res.data;
            // GetRouteDetails1();
        });
    }

    $scope.GetRouteFleet = function () {

        var selCmp = $scope.cmp;

        if (selCmp == null) {
            $scope.FleetRoute = null;
            return;
        }
        var cmpId = (selCmp == null) ? -1 : selCmp.Id;

        var fr = {
            cmpId: selCmp.Id,
            routeid: $scope.r.RouteId,
            fleetownerId: $scope.s.Id,           
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/FleetRoutes/getFleetRoutesList',
            //headers: {
            //    'Content-Type': undefined
            data: fr
        }
        $http(req).then(function (res) {
            $scope.RouteFleet = res.data;
        });
    }

    $scope. getFORVehicleSchedule = function () {
        $scope.RouteVehicleSchedule = [];
        if ($scope.r == null || $scope.r.RouteId == null) {
            //alert('Please select a route.');
            $scope.RouteVehicleSchedule = [];
            return;
        }
        $http.get('http://localhost:1476/api/FleetOwnerVehicleSchedule/getFORVehicleSchedule?fleetownerid=' + $scope.s.Id + '&routeid='
            + $scope.r.RouteId+'&vehicleId='+$scope.v.Id).then(function (res, data) {
            $scope.RouteVehicleSchedule = res.data;
        });
    }

    $scope.SetCurrStop = function (currStop, indx) {
        //alert(currStop.StopName);
        $scope.currStop = currStop;
        $scope.currStopIndx = indx;
    }


    $scope.GetshowDivStopDetails= function () {

        if (StopCount > 0) {

            document.getElementById("Stopdetails").style.display = 'inline';
        }
        else {
            document.getElementById("StopDetails").style.display = 'none';
        }
    }

    //$scope.save = function () {
    //    var test = $scope.RouteVehicleSchedule;
       
    //}

    $scope.test = function (a) {
        alert(a);
    }

    $scope.$on('ngRepeatFinished', function () {

        $("input[id*='Date']").datetimepicker({
            pickDate: false
        });

       
    });

    $scope.GetData = function () {
        $scope.StopNo = '1';
        $scope.StopName = "Hyderabad";
        $scope.StopCode = "HYD";

      //  $http(req).then(function (res) {
          //  $scope.Data = res.data;
            // GetRouteDetails1();
       // });
      
    }
   // if (StopCount > 0) {
        $scope.updateTime = function (s) {
            var aid = s.stopid + 'ADate';
            var did = s.stopid + 'DDate';
            s.arrivaltime = document.getElementById(aid).value;
            s.departuretime = document.getElementById(did).value;

            var arrArry = s.arrivaltime.split(' ');
            var depArry = s.departuretime.split(' ');


        }
   // }
   
    
    $scope.save = function (stop, flag) {

      //  var test = $scope.RouteVehicleSchedule;

        //var FOVS = {
        //    //Id: stop.Id,
        //    StopNmae: stop.StopNmae,
        //    StopNo: stop.StopNo,
        //    StopCode: stop.StopCode,
        //    ArrivalHr: stop.ArrivalHr,
        //    DepartureHr: stop.DepartureHr,
        //    Duration: stop.Duration,
        //    ArrivalMin: stop.ArrivalMin,
        //    DepartureMin: stop.DepartureMin,
        //    ArrivalAMPM: stop.ArrivalAMPM,
        //    DepartureAmPm: stop.DepartureAmPmtopId,
        //    arrivaltime: stop.arrivaltime,
        //    departuretime: stop.departuretime,
        //    insupdflag: flag
        //}


        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/FleetOwnerVehicleSchedule/saveFORSchedule',
            data: $scope.RouteVehicleSchedule
        }
        $http(req).then(function (response) {

            $scope.showDialog("Saved successfully!!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
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

