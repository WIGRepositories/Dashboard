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

var ctrl = app.controller('mycntrlr', function ($scope, $http, $localStorage, $filter) {
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
            $scope.checkedArr =  [];
            $scope.uncheckedArr = [];
            return;
        }

        $http.get('http://localhost:1476/api/FleetOwnerRoute/getFleetOwnerRoute?cmpId=' + $scope.cmp.Id + '&fleetownerId=' + $scope.s.Id).then(function (res, data) {
            $scope.FORoutes = res.data;
            $scope.checkedArr =  $filter('filter')($scope.FORoutes, { assigned: "1" });
            $scope.uncheckedArr = $filter('filter')($scope.FORoutes, { assigned: "0" });
        });
    }
    $scope.saveFORoutes = function () {
        if (FleetOwnerRoutes.CompanyId == null)
        {
            alert('Please enter CompanyId ');
            return;
        }
        if (FleetOwnerRoutes.RouteId == null)
        {
            alert('Please enter RouteId')
            return;
        }
       
        if (FleetOwnerRoutes.FleetOwnerId == null)
        {
            alert('please enter FleetOwnerId');
            return;
        }
        
      
        var FleetOwnerRoutes = {
            CompanyId: FleetOwnerRoutes.CompanyId,
            RouteId: FleetOwnerRoutes.RouteId,
            FleetOwnerId: FleetOwnerRoutes.FleetOwnerId,
            Id: FleetOwnerRoutes.Id,
           

        }

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/FleetOwnerRouteController/saveFleetOwnerRoute',

            data: FleetOwnerRoutes
        }

        $http(req).then(function (response) {
        
        });
    };


    $scope.toggle = function (item) {
        var idx = $scope.checkedArr.indexOf(item);
        if (idx > -1) {
            $scope.checkedArr.splice(idx, 1);
        }
        else {
            $scope.checkedArr.push(item);
        }

        var idx = $scope.uncheckedArr.indexOf(item);
        if (idx > -1) {
            $scope.uncheckedArr.splice(idx, 1);
        }
        else {
            $scope.uncheckedArr.push(item);
        }
    };
    

    $scope.toggleAll = function () {
        if ($scope.checkedArr.length === $scope.FORoutes.length) {
            $scope.uncheckedArr = $scope.checkedArr.slice(0);
            $scope.checkedArr = [];

        } else if ($scope.checkedArr.length === 0 || $scope.FORoutes.length > 0) {
            $scope.checkedArr = $scope.FORoutes.slice(0);
            $scope.uncheckedArr = [];
        }
      
    };

    $scope.exists = function (item, list) {
        return list.indexOf(item) > -1;
    };
  
   
    $scope.isChecked = function () {
        return $scope.checkedArr.length === $scope.FORoutes.length;
    };

    $scope.$on('ngRepeatFinished', function () {
        $("input[id*='date']").datepicker({
            dateFormat: "dd/mm/yy"
        });
    });
   
});
