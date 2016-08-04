// JavaScript source code
var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.userCmpId = $scope.userdetails[0].CompanyId;
    $scope.userSId = $scope.userdetails[0].UserId;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;

  
    $scope.GetFleeBTPosDetails = function () {

        $http.get('http://localhost:1476/api/FleetBtpos/GetFleebtDetails?sId=-1&cmpid=-1').then(function (res, data) {
            $scope.FleetBtposList = res.data;
        });
    }

    $scope.GetCompanies = function () {

        $http.get('http://localhost:1476/api/GetCompanyGroups?userid=-1').then(function (res, data) {
            $scope.Companies = res.data;

            if ($scope.userCmpId != 1) {
                //loop throug the companies and identify the correct one
                for (i = 0; i < res.data.length; i++) {
                    if (res.data[i].Id == $scope.userCmpId) {
                        $scope.cmp = res.data[i];
                        document.getElementById('test').disabled = true;
                        break
                    }
                }
            }
            else {
                document.getElementById('test').disabled = false;
            }
            $scope.GetFleetOwners($scope.cmp);
        });



    }

    $scope.GetFleetOwners = function () {
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
            $scope.cmpdata1 = res.data;

            if ($scope.userSId != 1) {
                //loop throug the fleetowners and identify the correct one
                for (i = 0; i < res.data.Table.length; i++) {
                    if (res.data.Table[i].UserId == $scope.userSId) {
                        $scope.s = res.data.Table[i];
                        document.getElementById('test1').disabled = true;
                        break
                    }
                }
            }
            else {
                document.getElementById('test1').disabled = false;
            }
            $scope.GetFleeBTPosDetails($scope.s);

        });

        //$http.get('http://localhost:1476/api/Getfleet').then(function (res, data) {
        //    $scope.fleet = res.data;

        //    if ($scope.userSId != 1) {
        //        //loop throug the companies and identify the correct one
        //        for (i = 0; i < res.data.length; i++) {
        //            if (res.data[i].Id == $scope.userSId) {
        //                $scope.s = res.data[i];
        //                document.getElementById('test1').disabled = true;
        //                break
        //            }
        //        }
        //    }
        //    else {
        //        document.getElementById('test1').disabled = false;
        //    }
        //    $scope.getFleetOwnerRoute($scope.s);
        //});
    }

    $scope.GetFleetBTPosForFO = function () {

        if ($scope.fo == null) {
            $scope.FleetnBTPos = null;
            return;
        }
        var vc = {
            needvehicleRegno: '1',
            needbtpos: '1',
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