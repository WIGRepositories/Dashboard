
// JavaScript source code
// JavaScript source code
var myapp1 = angular.module('myApp', ['ngStorage'])
var mycrtl1 = myapp1.controller('Mycntrl', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname

   
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
            $scope.cmpdata = null;
            $scope.Fleet = null;
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
        getUsersnRoles();
    }    

    $scope.GetVehicleConfig = function () {

        $scope.vehicles = null;

        var fleetowner = $scope.s;

        if (fleetowner == null) {
            return;
        }


        var vc = {
            needvehicleRegno: '1',
            sId: fleet.Id,
            needfleetownerroutes: '1'
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/VehicleConfig/VConfig',
            //headers: {
            //    'Content-Type': undefined
            data: vc
        }
        $http(req).then(function (res) {
            $scope.vehicles = res.data;
        });

    }
    
    $scope.getUsersnRoles = function () {
        var selCmp = $scope.initdata.newfleet.cmp;

        if (selCmp == null) {
            $scope.cmproles1 = null;
            $scope.cmpUsers1 = null;
            return;
        }
        var cmpId = (selCmp == null) ? -1 : selCmp.Id;

        $http.get('http://localhost:1476/api/FleetStaff/getUsersnRoles?companyId=' + cmpId + '&UserId=' + UserId).then(function (res, data) {
            $scope.cmpUsers1 = res.data;
        });

        $http.get('http://localhost:1476/api/FleetStaff/getUsersnRoles?cmpId=' + cmpId + '&RoleId=' + RoleId).then(function (res, data) {
            $scope.cmproles1 = res.data;
        });
    }

    $scope.savenewfleetStaffdetails = function (initdata) {
        var newVD = $scope.initdata.newfleet;
        if (newVD == null || newVD.v == null) {
             alert('Please select VehicleRegNo.');
             return;
         }
 
        if (newVD.v.Id == null) {
             alert('Please select VehicleRegNo.');
             return;
         }
         //validate user, company and role also      


        var Fleet = {
            Id: -1,
            vehicleId:newVD.v.Id,
            roleId:newVD.ur.Id,
            UserId:newVD.uu.Id,
            cmpId:newVD.cmp.Id,
            FromDate:newVD.fd,
            ToDate:newVD.td,
           // Active:1,
            insupddelflag:'I'
        };      


        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/FleetStaff/NewFleetStaff',
            //headers: {
            //    'Content-Type': undefined

            data: Fleet
        }

        $http(req).then(function (res) {
            alert('Sucessfully saved!');
        });
    }

    $scope.GetFleetStaff = function () {
        if ($scope.cmp == null) {
            $scope.FleetStaff = null;
            return;
        }

        //var foId = ($scope.fo == null) ? -1 : $scope.fo.Id;
        var cmpid = ($scope.cmp == null) ? -1 : $scope.cmp.Id;

        $http.get('http://localhost:1476/api/FleetStaff/GetFleetStaff?foId=-1&cmpId=' + cmpid).then(function (res, data) {
            $scope.FleetStaff = res.data;
        });
    }

});

   

