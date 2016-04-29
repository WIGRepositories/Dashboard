var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname

    $scope.GetFleetConfiguration = function () {


        $http.get('http://localhost:1476/api/GetCompanyGroups?vehicleId=-1').then(function (res, data) {
            $scope.Companies = res.data;
        });

        
    }
    $http.get('http://localhost:1476/api/Users/GetUsers?vehicleId=-1').then(function (res, data) {
        $scope.Companies = res.data;
    });

    $http.get('http://localhost:1476/api/Fleet/GetFleetConfiguration').then(function (res, data) {
        $scope.Fleet = res.data;

    });

    $scope.save = function (Fleet) {
        alert("ok");
        var Fleet = {
            Id:Fleet.Id,
            VehicleRegNo: Fleet.VehicleRegNo,
            VehicleTypeId: Fleet.VehicleTypeId,
            FleetOwnerId: Fleet.FleetOwnerId,
            CompanyId: Fleet.CompanyId,
            ServiceTypeId: Fleet.ServiceTypeId,
            Active: Fleet.Active,
           


        };
     
        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/Fleet/NewFleetDetails',
            //headers: {
            //    'Content-Type': undefined

            data: Fleet


        }
        $http(req).then(function (res) { });


    }
    
});
   

   

