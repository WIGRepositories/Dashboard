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

        $http.get('http://localhost:1476/api/FleetBtpos/GetFleebtDetails?foId=-1&cmpid=-1&initdata.newfleet.fdid=-1').then(function (res, data) {
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


        $http.get('http://localhost:1476/api/Getfleet').then(function (res, data) {
            $scope.fleet = res.data;

            if ($scope.userSId != 1) {
                //loop throug the companies and identify the correct one
                for (i = 0; i < res.data.length; i++) {
                    if (res.data[i].Id == $scope.userSId) {
                        $scope.s = res.data[i];
                        document.getElementById('test1').disabled = true;
                        break
                    }
                }
            }
            else {
                document.getElementById('test1').disabled = false;
            }
            $scope.GetFleetRoutes($scope.s);
        });
    }

    $scope.GetRoutesForFO = function () {

        $scope.vehicles = null;

        var fleetowner = $scope.s;

        if (fleetowner == null) {
            return;
        }

      
        var vc = {
            needvehicleRegno: '1',
            fleetownerId: fleetowner.Id,
            needfleetownerroutes:'1'
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

    $scope.GetFleetRoutes = function () {      

        var selCmp = $scope.cmp;

        if (selCmp == null) {
            $scope.FleetRoute = null;          
            return;
        }
        var cmpId = (selCmp == null) ? -1 : selCmp.Id;

        var fr = {
            cmpId: selCmp.Id,
            routeid: '-1',
            fleetownerId: $scope.s.Id,
            regno: '-1'
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/FleetRoutes/getFleetRoutesList',
            //headers: {
            //    'Content-Type': undefined
            data: fr
        }
        $http(req).then(function (res) {
            $scope.FleetRoute = res.data;
        });
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
    //        url: 'http://localhost:1476/api/VehicleConfig/VConfig',
    //        //headers: {
    //        //    'Content-Type': undefined

    //        data: vc


    //    }
    //    $http(req).then(function (res) {
    //        $scope.FleetOwners = res.data;          
    //    });
    //}

    $scope.save = function (currFR) {
        var FleetRoutes = currFR.newfleet;

        if (FleetRoutes == null || FleetRoutes.v == null) {
            alert('Please select a type VehicleId');
            return;
        }
        if(FleetRoutes == null || FleetRoutes.RouteId == null){
            alert('Please select a type  RouteId ');
            return;
        }
     
        var FleetRoute = {
            Id: FleetRoutes.Id,
            VehicleId: FleetRoutes.VehicleId,
            RouteId: FleetRoutes.RouteId,
            EffectiveFrom: FleetRoutes.EffectiveFrom,
            EffectiveTill: FleetRoutes.EffectiveTill,
            Active: FleetRoutes.Active,

        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/FleetRoutes/NewFleetRoutes',
            //headers: {
            //    'Content-Type': undefined

            data: FleetRoute


        }
        $http(req).then(function (res) { });


    }

    $scope.saveNewFleetRoutes = function (initdata) {
              
        var newFR = initdata.newfleet;

        if (newFR == null || newFR.v == null) {
            alert('Please select VehicleRegNo.');
            return;
        }

        if (newFR.v == null) {
            alert('Please select Vehicle.');
            return;
        }

        if (newFR.r == null) {
            alert('Please select route.');
            return;
        }

        var FleetRouters = {
            Id:-1 ,
            VehicleId: newFR.v.Id,          
            RouteId: newFR.r.RouteId,
            EffectiveFrom: newFR.fd,
            EffectiveTill: newFR.td,
            insupddelflag:'I'            
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/FleetRoutes/NewFleetRoutes',
            //headers: {
            //    'Content-Type': undefined

            data: FleetRouters
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
    $scope.testdel = function (R) {
        var FRoutes = {

            Id: -1,
            VehicleId: R.Id,
            RouteId: R.RouteId,
            EffectiveFrom: R.fd,
            EffectiveTill: R.td,
            insupddelflag: 'D'
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/FleetRoutes/NewFleetRoutes',
            data: FRoutes
        }
        $http(req).then(function (response) {
            alert('Removed successfully.');

            $http.get('http://localhost:1476/api/FleetRoutes/getFleetRoutesList?VehicleId=' + R.VehicleId).then(function (res, data) {
                $scope.FleetRoute = res.data;
            });

        });
       
    }

    $scope.setRoute = function (R) {
        $scope.currFR = R;
        $scope.currFR.VehicleTypeId = 9;
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
