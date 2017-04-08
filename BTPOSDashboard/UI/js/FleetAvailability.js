var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var ctrl = app.controller('Mycntrl', function ($scope, $http,$localStorage) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.userCmpId = $scope.userdetails[0].CompanyId;
    $scope.userSId = $scope.userdetails[0].UserId;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;


    $scope.setCurrRole = function (R) {
        $scope.currRole = R;
    };

   
    $scope.GetCompanies = function () {

        $http.get('/api/GetCompanyGroups?userid=-1').then(function (res, data) {
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

    //$scope.GetCompanies = function () {

    //    var vc = {
    //        needCompanyName: '1'
    //    };

    //    var req = {
    //        method: 'POST',
    //        url: '/api/VehicleConfig/VConfig',
    //        //headers: {
    //        //    'Content-Type': undefined
    //        data: vc
    //    }
    //    $http(req).then(function (res) {
    //        $scope.initdata = res.data;
    //    });

    //}

    $scope.GetFleeAvailabilty = function () {

        if ($scope.cmp == null) {
            $scope.FleetAvailability = null;
            return;
        }
       
        $http.get('/api/FleetAvailability/GetFleetAvailability?foid=-1&cmpId='+$scope.cmp.Id).then(function (res, data) {
            $scope.FleetAvailability = res.data;

        });

    }

    $scope.GetFleetOwners = function () {

        var vc = {
            needfleetowners: '1',
            cmpId: $scope.cmp.Id
        };

        var req = {
            method: 'POST',
            url: '/api/VehicleConfig/VConfig',
            //headers: {
            //    'Content-Type': undefined

            data: vc


        }
        $http(req).then(function (res) {
            $scope.cmpdata = res.data;

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
            $scope.GetFleetDetails($scope.s);

        });
        //$http.get('/api/Getfleet').then(function (res, data) {
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
        //    $scope.GetFleeAvailabilty($scope.s);
        //});
    }

    //$scope.GetFleetOwners = function () {
    //    if ($scope.cmp == null) {
    //        $scope.FleetOwners = null;
    //        return;
    //    }
    //    var vc = {
    //        needfleetowners: '1',
    //        cmpId: $scope.cmp.Id
    //    };

    //    var req = {
    //        method: 'POST',
    //        url: '/api/VehicleConfig/VConfig',
    //        //headers: {
    //        //    'Content-Type': undefined

    //        data: vc


    //    }
    //    $http(req).then(function (res) {
    //        $scope.cmpdata = res.data;
    //    });
    //}

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
            url: '/api/VehicleConfig/VConfig',
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
            FleetOwner:  $scope.fo.Id,
            VehicleId: FleetAvailability.v.Id,           
            FromDate: FleetAvailability.fd,
            ToDate: FleetAvailability.td,
            insupddelflag: 'I'
        };

        var req = {
            method: 'POST',
            url: '/api/FleetAvailability/SetFleetAvailability',
            //headers: {
            //    'Content-Type': undefined

            data: newFleetAvail
        }

        $http(req).then(function (response) {

           // $scope.showDialog("Saved successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };


    $scope.save = function (currRole) {
       
        if (currRole == null || currRole.VehicleId == null) {
            alert('Please select Vehicle.');
            return;
        }

        if (currRole.VehicleId == null) {
            alert('Please select Vehicle.');
            return;
        }


        var FAvailability = {
            Id: -1,

            VehicleId: currRole.VehicleId,
            FromDate: currRole.fd,
            ToDate: currRole.td,
            insupddelflag: 'U'

        };

        var req = {
            method: 'POST',
            url: '/api/FleetAvailability/SetFleetAvailability',
            //headers: {
            //    'Content-Type': undefined

            data: FAvailability


        }
        $http(req).then(function (res) { });
        //alert('updated successfully.');

    }


    $scope.testdel = function (R) {
        var FAvaliability = {

            Id: -1,
            VehicleId: R.VehicleId,
            FromDate: R.fd,
            ToDate: R.td,
            insupddelflag: 'D'
        };

        var req = {
            method: 'POST',
            url: '/api/FleetAvailability/SetFleetAvailability',
            data: FAvaliability
        }
        $http(req).then(function (response) {
            //alert('Removed successfully.');

            $http.get('/api/FleetAvailability/GetFleetAvailability?VehicleId=' + R.VehicleId).then(function (res, data) {
                $scope.FleetAvailability = res.data;
            });

        });

    }

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



