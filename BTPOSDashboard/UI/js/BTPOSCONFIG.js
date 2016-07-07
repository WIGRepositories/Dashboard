// JavaScript source code
var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
if ($localStorage.uname == null)
{
    window.location.href = "login.html";
}
$scope.uname = $localStorage.uname;
$scope.userdetails = $localStorage.userdetails;
$scope.Roleid = $scope.userdetails[0].roleid;

$scope.dashboardDS = $localStorage.dashboardDS; 

    //  $scope.FleeBTPosDetails = [];


    $scope.GetFleeBTPosDetails = function () {

        if ($scope.cmp == null) {
            $scope.cmpdata = null;
            $scope.FleetOwners = null;

            return;
        }

        if ($scope.s == null) {
            $scope.sdata = null;
            $scope.BTPos = null;
            return;
        }
        if ($scope.b == null) {
            $scope.BTPos = null;
        }

        $http.get('http://localhost:1476/api/BTPOSConfig/GetFleeBTPosDetails?cmpId=' + $scope.cmp.Id + '&fleetOwnerId=' + $scope.s.Id + '&BTPosId=' + $scope.b.Id).then(function (res, data) {
            $scope.BTPos = res.data;
        });
    }

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

    $scope.GetBTPosForFO = function () {

        if ($scope.s == null) {
            $scope.BTPos = null;
            return;
        }
        var vc = {
            needBTPos: '1',

            sId: $scope.s.Id
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
        });
    }


    $scope.saveFleetBTPOS = function (FleetBtpos) {

        if (FleetBtpos == null || FleetBtpos.v == null) {
            alert('Please select Vehicle.');
            return;
        }

        if (FleetBtpos.v.Id == null) {
            alert('Please select Vehicle.');
            return;
        }

        if (FleetBtpos.b.Id == null) {
            alert('Please select BT POS.');
            return;
        }

        var newFleetPOS = {
            Id: -1,
            VehicleId: FleetBtpos.v.Id,
            BTPOSId: FleetBtpos.b.Id,
            FromDate: FleetBtpos.fd,
            ToDate: FleetBtpos.td,
            insupddelflag: 'I'
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/FleetBtpos/AssignFleetBTPOS',
            //headers: {
            //    'Content-Type': undefined

            data: newFleetPOS
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

app.controller('ModalInstanceCtrl', function ($scope, $uibModalInstance, mssg) {

    $scope.mssg = mssg;
    $scope.ok = function () {
        $uibModalInstance.close('test');
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});