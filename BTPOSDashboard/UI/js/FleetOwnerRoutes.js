var app = angular.module('myApp', ['ngStorage']);
var ctrl = app.controller('mycntrlr', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname;

    $scope.getFleetOwnerRoute = function () {

        $http.get('http://localhost:1476/api/FleetOwnerRoute/getFleetOwnerRoute').then(function (res, data) {
            $scope.FleetOwnerRoute = res.data;
        });
    }
    $scope.save = function (FleetOwnerRoutes) {
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
});
