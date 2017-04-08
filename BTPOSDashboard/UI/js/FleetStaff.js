// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var mycrtl1 = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.userCmpId = $scope.userdetails[0].CompanyId;
    $scope.userSId = $scope.userdetails[0].UserId;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;



    $scope.GetCompanies = function () {

        $http.get('/api/GetCompanyGroups?userid=-1').then(function (res, data) {
            $scope.Companies = res.data;
            $scope.Companies1 = res.data;


            if ($scope.userCmpId != 1) {
                //loop throug the companies and identify the correct one
                for (i = 0; i < res.data.length; i++) {
                    if (res.data[i].Id == $scope.userCmpId) {
                        $scope.cmp = res.data[i];
                        document.getElementById('test').disabled = true;
                        break
        }
                }
                // $scope.GetFleetOwners();
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
            $scope.GetFleetStaff($scope.s);

        });
    }
   
    //$scope.GetCompanies1 = function () {

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
    //        //$scope.initdata = res.data;
    //        $scope.companies1 = res.data;
    //    });

    //}
    //$scope.GetFleetOwners1 = function () {
    //    if ($scope.cmp1 == null) {
    //        $scope.cmp1data = null;
    //        $scope.userRoles = null;
    //        $scope.vehicles = null;
    //        return;
    //    }
    //    var vc = {
    //        needfleetowners: '1',
    //        cmpId: $scope.cmp1.Id
    //    };

    //    var req = {
    //        method: 'POST',
    //        url: '/api/VehicleConfig/VConfig',
    //        //headers: {
    //        //    'Content-Type': undefined

    //        data: vc


    //    }
    //    $http(req).then(function (res) {
    //        $scope.cmp1data = res.data;
    //    });
        
    //    $http.get('/api/Users/GetUserRoles?cmpId=' + $scope.cmp1.Id).then(function (res, data) {
    //        $scope.userRoles = res.data;
    //    });
    //}
   


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
            url: '/api/VehicleConfig/VConfig',
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

        //$http.get('/api/FleetStaff/getUsersnRoles?companyId=' + cmpId + '&UserId=' + UserId).then(function (res, data) {
        //    $scope.cmpUsers1 = res.data;
        //});

        //$http.get('/api/FleetStaff/getUsersnRoles?cmpId=' + cmpId + '&RoleId=' + RoleId).then(function (res, data) {
        //    $scope.cmproles1 = res.data;
        //});

        $http.get('/api/Users/GetUserRoles?cmpId=' + $scope.cmp.Id).then(function (res, data) {
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
            vehicleId: newVD.Id,
            roleId: newVD.uu.RoleId,
            UserId: newVD.uu.Id,
            cmpId: $scope.cmp.Id,
            FromDate: newVD.fd,
            ToDate: newVD.td,
            // Active:1,
            insupddelflag: 'I'
        };


        var req = {
            method: 'POST',
            url: '/api/FleetStaff/NewFleetStaff',
            //headers: {
            //    'Content-Type': undefined

            data: Fleet
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
    $scope.savefleetStaff = function () {
        var FleetStaff = $scope.f1;
        if (FleetStaff == null) {
            alert('Please select VehicleRegNo.');
            return;
        }

        if (FleetStaff.Id == null) {
            alert('Please select VehicleRegNo.');
            return;
        }
       

        var FleetS = {
            
            Id: -1,
            vehicleId: FleetStaff.Id,
            roleId: FleetStaff.uu.RoleId,
            UserId: FleetStaff.uu.Id,
            cmpId: $scope.cmp.Id,
            FromDate: FleetStaff.fd,
            ToDate: FleetStaff.td,
            // Active:1,
            insupddelflag: 'U'
        };

        var req = {
            method: 'POST',
            url: '/api/FleetStaff/NewFleetStaff',
            //headers: {
            //    'Content-Type': undefined

            data: FleetS


        }
        $http(req).then(function (res) {
           // $scope.showDialog("Updated successfully!");
            GetFleetDetails();
        });


    }

    //$scope.savenewfleetStaffdetails = function () {
    //    var newVD = $scope.f;
    //    if (newVD == null) {
    //        alert('Please select VehicleRegNo.');
    //        return;
    //    }

    //    if (newVD.Id == null) {
    //        alert('Please select VehicleRegNo.');
    //        return;
    //    }
    //    //validate user, company and role also      


    //    var Fleet = {
    //        Id: -1,
    //        vehicleId: newVD.Id,
    //        roleId: newVD.uu.RoleId,
    //        UserId: newVD.uu.Id,
    //        cmpId: $scope.cmp.Id,
    //        FromDate: newVD.fd,
    //        ToDate: newVD.td,
    //        // Active:1,
    //        insupddelflag: 'I'
    //    };


    //    var req = {
    //        method: 'POST',
    //        url: '/api/FleetStaff/NewFleetStaff',
    //        //headers: {
    //        //    'Content-Type': undefined

    //        data: Fleet
    //    }

    //    $http(req).then(function (response) {

    //        $scope.showDialog("Saved successfully!");

    //        $scope.Group = null;

    //    }, function (errres) {
    //        var errdata = errres.data;
    //        var errmssg = "";
    //        errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
    //        $scope.showDialog(errmssg);
    //    });
    //    $scope.currGroup = null;
    //};

    $scope.GetFleetStaff = function () {
        if ($scope.cmp == null || $scope.cmp.Id == null) {
            $scope.FleetStaff = null;
            return;
        }

        if ($scope.s == null || $scope.s.Id == null) {
            $scope.FleetStaff = null;
            return;
        }

        $http.get('/api/FleetStaff/GetFleetStaff?foId=' + $scope.s.Id + '&cmpId=' + $scope.cmp.Id).then(function (res, data) {
            $scope.FleetStaff = res.data;
        });
    }


    $scope.setFleet = function (Fleet) {
        $scope.currFleet = Fleet;
    };
    $scope.testdel = function (Fleet) {
        var FRoutes = {

            Id: -1,
            vehicleId: Fleet.Id,
            roleId: Fleet.RoleId,
            UserId: Fleet.UserId,
            cmpId: $scope.cmp.Id,
            FromDate: Fleet.fd,
            ToDate: Fleet.td,
            // Active:1,
            insupddelflag: 'D'
        };

        var req = {
            method: 'POST',
            url: '/api/FleetStaff/NewFleetStaff',
            data: FRoutes
        }
        $http(req).then(function (response) {
            //alert('Removed successfully.');

            $http.get('/api/FleetStaff/GetFleetStaff?roleid=' + Fleet.RoleId).then(function (res, data) {
                $scope.FleetStaff = res.data;
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



