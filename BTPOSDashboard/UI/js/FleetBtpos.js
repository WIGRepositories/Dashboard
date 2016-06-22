
// JavaScript source code
var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname

    $scope.GetFleeBTPosDetails = function () {

        $http.get('http://localhost:1476/api/FleetBtpos/GetFleebtDetails?sId=-1&cmpid=-1').then(function (res, data) {
            $scope.FleetBtposList = res.data;
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

    $scope.GetFleetBTPosForFO = function () {

        if ($scope.fo == null) {
            $scope.FleetnBTPos = null;
            return;
        }
        var vc = {
            needvehicleRegno:'1',
            needbtpos:'1',
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
            $scope.FleetnBTPos = res.data;
        });
    }
    //$scope.GetFleetBTPosForreg() = function () {

    //    if ($scope.vr == null) {
    //        $scope.FleetnBTPos = null;
    //        return;
    //    }
    //    var vc = {
    //        needvehicleRegno: '1',
    //        needbtpos: '1',
    //        fleetownerId: $scope.fo.Id
    //    };

    //    var req = {
    //        method: 'POST',
    //        url: 'http://localhost:1476/api/VehicleConfig/VConfig',
    //        //headers: {
    //        //    'Content-Type': undefined

    //        data: vc


    //    }
    //    $http(req).then(function (res) {
    //        $scope.FleetnBTPos = res.data;
    //    });
    //}

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



    }

});