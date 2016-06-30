var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var ctrl = app.controller('Mycntrl', function ($scope, $http,$localStorage) {
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

    $scope.GetFleeAvailabilty = function () {

        if ($scope.cmp == null) {
            $scope.FleetAvailability = null;
            return;
        }
       
        $http.get('http://localhost:1476/api/FleetAvailability/GetFleetAvailability?foid=-1&cmpId='+$scope.cmp.Id).then(function (res, data) {
            $scope.FleetAvailability = res.data;

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

    $scope.GetFleetForFO = function () {

        if ($scope.fo == null) {
            $scope.FleetForFO = null;
            return;
        }
        var vc = {
            needHireVehicle: '1',
            fleetownerId: $scope.fo.Id
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/VehicleConfig/VConfig',
            //headers: {
            //    'Content-Type': undefined

            data: vc


        }
        $http(req).then(function (res) {
            $scope.FleetForFO = res.data;
        });
    }


    $scope.saveFleetAvailability = function (FleetAvailability) {

        if (FleetAvailability == null || FleetAvailability.v == null) {
            alert('Please select Vehicle.');
            return;
        }

        if (FleetAvailability.v.Id == null) {
            alert('Please select Vehicle.');
            return;
        }      

        var newFleetAvail = {
            Id: -1,
            VehicleId: FleetAvailability.v.Id,           
            FromDate: FleetAvailability.fd,
            ToDate: FleetAvailability.td,
            insupddelflag: 'I'
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/FleetAvailability/SetFleetAvailability',
            //headers: {
            //    'Content-Type': undefined

            data: newFleetAvail
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






