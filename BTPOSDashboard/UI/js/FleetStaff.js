// JavaScript source code
// JavaScript source code
var myapp1 = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var mycrtl1 = myapp1.controller('myCtrl', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname
    $scope.dashboardDS = $localStorage.dashboardDS;

   
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
            $scope.userRoles = null;
            $scope.vehicles = null;
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
        
        $http.get('http://localhost:1476/api/Users/GetUserRoles?cmpId=' + $scope.cmp.Id).then(function (res, data) {
            $scope.userRoles = res.data;
        });
    }    

    $scope.GetVehicleConfig = function () {

        $scope.vehicles = null;

        var fleetowner = $scope.s;

        if (fleetowner == null) {
            return;
        }


        var vc = {
            needvehicleRegno: '1',
            fleetownerId: fleetowner.Id,
           
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
        var s = $scope.cmp;

        if (s == null) {
            $scope.userRoles = null;           
            return;
        }
        var cmpId = (s == null) ? -1 : s.Id;

        //$http.get('http://localhost:1476/api/FleetStaff/getUsersnRoles?companyId=' + cmpId + '&UserId=' + UserId).then(function (res, data) {
        //    $scope.cmpUsers1 = res.data;
        //});

        //$http.get('http://localhost:1476/api/FleetStaff/getUsersnRoles?cmpId=' + cmpId + '&RoleId=' + RoleId).then(function (res, data) {
        //    $scope.cmproles1 = res.data;
        //});

        $http.get('http://localhost:1476/api/Users/GetUserRoles?cmpId=' + $scope.cmp.Id).then(function (res, data) {
            $scope.userRoles = res.data;
        });
    }

    $scope.savenewfleetStaffdetails = function () {
        var newVD = $scope.f;
        if (newVD == null) {
             alert('Please select VehicleRegNo.');
             return;
         }
 
        if (newVD.Id == null) {
             alert('Please select VehicleRegNo.');
             return;
         }
         //validate user, company and role also      


        var Fleet = {
            Id: -1,
            vehicleId:newVD.Id,
            roleId:newVD.uu.RoleId,
            UserId:newVD.uu.Id,
            cmpId: $scope.cmp.Id,
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

        $http(req).then(function (response) {

            $scope.showDialog("Saved successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };

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
    

    $scope.GetFleetStaff = function () {
        if ($scope.cmp == null || $scope.cmp.Id == null) {
            $scope.FleetStaff = null;
            return;
        }

        if ($scope.s == null || $scope.s.Id == null) {
            $scope.FleetStaff = null;
            return;
        }       

        $http.get('http://localhost:1476/api/FleetStaff/GetFleetStaff?foId=' + $scope.s.Id + '&cmpId=' + $scope.cmp.Id).then(function (res, data) {
            $scope.FleetStaff = res.data;
        });
    }



   

