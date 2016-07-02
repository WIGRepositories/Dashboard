var app = angular.module('myApp', ['ngStorage']);
app.directive('ngOnFinishRender', function ($timeout) {
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

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $filter) {
    $scope.uname = $localStorage.uname;



    $scope.checkedArr = new Array();
    $scope.uncheckedArr = new Array();
    $scope.FORoutes = [];

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

    $scope.getFleetOwnerRoute = function () {

        if ($scope.s == null) {
            $scope.FORoutes = null;          
            return;
        }

        $http.get('http://localhost:1476/api/FleetOwnerRoute/getFleetOwnerRoute?cmpId=' + $scope.cmp.Id + '&fleetownerId=' + $scope.s.Id).then(function (res, data) {
            $scope.FORoutes = res.data;
          
        });
    }

    $scope.getFOFleetforRoute = function () {       

            var selCmp = $scope.cmp;

            if (selCmp == null) {
                $scope.fleet = null;
                return;
            }
            var cmpId = (selCmp == null) ? -1 : selCmp.Id;

            var fr = {
                cmpId: selCmp.Id,
                routeid: $scope.r.RouteId,
                fleetownerId: $scope.s.Id
            };

            var req = {
                method: 'POST',
                url: 'http://localhost:1476/api/FleetRoutes/getFleetRoutesList',
                //headers: {
                //    'Content-Type': undefined
                data: fr
            }
            $http(req).then(function (res) {
                $scope.fleet = res.data;
            });
        
    }

    $scope.getVehicleFareConfig = function () {

        if ($scope.v == null) {
            $scope.FOVFareConfig = null;           
            return;
        }

        $http.get('http://localhost:1476/api/FleetOwnerRouteFare/GetFOVehicleFareConfig?vehicleId=' + $scope.v.VehicleId+'&routeId='+$scope.r.RouteId).then(function (res, data) {
            $scope.FOVFareConfig = res.data;

        });

    }

    $scope.SetPrice = function () {
        for (var cnt = 0; cnt < $scope.FOVFareConfig.length; cnt++) {
            angular.element('')
        }
    }
    $scope.saveFORouteFare = function () {

        if ($scope.prc == null) return;
        var FleetOwnerRouteFare = [];
        var configFareList = $scope.FOVFareConfig;
        for (var cnt = 0; cnt < configFareList.length; cnt++) {

            var fr = {
                RouteId         : $scope.r.RouteId,                    
                VehicleTypeId   : $scope.v.VehicleTypeId,
                FromStopId      : configFareList[cnt].FromStopId,
                ToStopId        : configFareList[cnt].ToStopId,
                Distance        :configFareList[cnt].Distance,
                PerUnitPrice    : $scope.puprc,
                Amount          : ($scope.prc == 1) ? eval($scope.puprc) * eval(configFareList[cnt].Distance) : configFareList[cnt].Amount,
                FareTypeId      :configFareList[cnt].FareTypeId,
                VehicleId       : $scope.v.Id,
                Active          :1,      
                FromDate        :configFareList[cnt].FromDate,
                ToDate          :configFareList[cnt].ToDate
        }

                FleetOwnerRouteFare.push(fr);
            
        }        

        $http({
            url: 'http://localhost:1476/api/FleetOwnerRouteFare/saveFleetOwnerRoutefare',
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            data: FleetOwnerRouteFare,

        }).success(function (data, status, headers, config) {
            alert('Fleet owner routes successfully');
            $scope.getFleetOwnerRoute();
        }).error(function (ata, status, headers, config) {
            alert(ata);
        });
    };

    $scope.$on('ngRepeatFinished', function () {
        $("input[id*='date']").datepicker({
            dateFormat: "dd/mm/yy"
        });
    });

});
