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
        if (Fleet == null) {
            alert('Please enter VehicleRegNo.');
            return;
        }

       if(Fleet.VehicleRegNo == null) {
            alert('Please enter VehicleRegNo.');
            return;
       }
       if (Fleet.group == null || Fleet.VehicleTypeId.group.Id == null) {
           alert('Please select a type group');
           return;
       }
      
                       
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
   

   

