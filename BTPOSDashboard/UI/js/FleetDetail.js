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



    $scope.GetFleetDetails = function () {

        if ($scope.cmp == null) {
            $scope.Companies = null;
            return;
        }

        if ($scope.s == null) {
            $scope.fleet = null;
            return;
        }

        $http.get('/api/Fleet/getFleetList?cmpId=' + $scope.cmp.Id + '&fleetOwnerId=' + $scope.s.Id).then(function (res, data) {
            $scope.Fleet = res.data.Table;
        });
    }

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
               // $scope.GetFleetOwners();
            }
            else {
                document.getElementById('test').disabled = false;
            }
            $scope.GetFleetOwners($scope.cmp);
        });

    }


    $scope.GetFleetOwners = function () {


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
        // //   $scope.GetFleetDetails($scope.s);
        //});

           
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
    }

    //This will hide the DIV by default.
    //$scope.IsHidden = true;
    //$scope.ShowHide = function () {
    //    //If DIV is hidden it will be visible and vice versa.
    //    $scope.IsHidden = $scope.IsHidden ? false : true;
    //}


    //$scope.GetCompanies1 = function () {

    //    var vc = {
    //        needCompanyName: '1'
    //    };

    //    var req = {
    //        method: 'POST',
    //        url: '/api/VehicleConfig/VConfig',
    //        headers: {
    //            'Content-Type': undefined
    //        data: vc
    //    }
    //    $http(req).then(function (res) {
    //        $scope.initdata = res.data;
    //        $scope.companies1 = res.data;
    //    });

    //}

    //$scope.GetFleetOwners1 = function () {
    //    if ($scope.cmp1 == null) {
    //        $scope.cmp1data = null;
    //        $scope.Fleet = null;
    //        return;
    //    }
    //    var vc = {
    //        needfleetowners: '1',
    //        cmpId: $scope.cmp1.Id
    //    };

    //    var req = {
    //        method: 'POST',
    //        url: '/api/VehicleConfig/VConfig',
    //        headers: {
    //            'Content-Type': undefined

    //        data: vc


    //    }
    //    $http(req).then(function (res) {
    //        $scope.cmp1data = res.data.Table;
    //    });
    //}

    $scope.GetVehicleConfig = function () {

        var vc = {
            // needfleetowners:'1',
            needvehicleType: '1',
            needServiceType: '1',
            needvehiclelayout: '1',
            needCompanyName: '1'
        };

        var req = {
            method: 'POST',
            url: '/api/VehicleConfig/VConfig',
            //headers: {
            //    'Content-Type': undefined

            data: vc


        }
        $http(req).then(function (res) {
            $scope.initdata = res.data;
        });

    }

    /* $scope.GetFleetDetails = function () {
 
         $http.get('/api/Fleet/getFleetList?cmpId=' + $scope.cmp.Id + '&fleetOwnerId=' + $scope.s.Id).then(function (res, data) {
             $scope.Fleet = res.data.Table;
         });
     }*/

    $scope.save = function (Fleet, flag) {
        if (Fleet == null) {
            alert('Please enter VehicleRegNo.');
            return;
        }

        if (Fleet.VehicleRegNo == null || Fleet.VehicleRegNo == "") {
            alert('Please enter VehicleRegNo.');
            return;
        }
        if (Fleet.FuelUsed == null || Fleet.FuelUsed == "") {
            alert('Please enter FuelUsed.');
            return;
        }
        if (Fleet.ChasisNo == null || Fleet.ChasisNo == "") {
            alert('Please enter ChasisNo.');
            return;
        }
        
        //if (Fleet.group == null || Fleet.VehicleTypeId.group.Id == null) {
        //    alert('Please select a type group');
        //    return;
        //}



        var Fleet = {
            Id: Fleet.Id,
            VehicleRegNo: Fleet.VehicleRegNo,
            VehicleTypeId: (Fleet.vt != null) ? Fleet.vt.Id : Fleet.VehicleTypeId,
            VehicleLayoutId: (Fleet.vl != null) ? Fleet.vl.Id : Fleet.LayoutTypeId,
            FleetOwnerId: $scope.s.Id,
            CompanyId: $scope.cmp.Id,
            ServiceTypeId: (Fleet.st != null) ? Fleet.st.Id : Fleet.ServiceTypeId,
            EngineNo: Fleet.EngineNo,
            FuelUsed: Fleet.FuelUsed,
            MonthAndYrOfMfr: Fleet.MonthAndYrOfMfr,
            ChasisNo: Fleet.ChasisNo,
            SeatingCapacity: Fleet.SeatingCapacity,
            DateOfRegistration: Fleet.DateOfRegistration,
            Active: 1,
            insupddelflag: 'U'
        };

        var req = {
            method: 'POST',
            url: '/api/Fleet/NewFleetDetails',
            //headers: {
            //    'Content-Type': undefined

            data: Fleet


        }
        $http(req).then(function (res) {
           // $scope.showDialog("Updated successfully!");
           
        });

        $scope. GetCompanies();
    }

    $scope.savenewfleetdetails = function (initdata, flag) {
        var newVD = initdata.newfleet;
        if (newVD == null) {
            alert('Please enter VehicleRegNo.');
            return;
        }
        /* 
        if (newVD.VehicleRegNo == null) {
            alert('Please enter VehicleRegNo.');
            return;
        }
        if (Fleet.group == null || Fleet.VehicleTypeId.group.Id == null) {
            alert('Please select a type group');
            return;
        }
        */


        var Fleet = {
            Id: -1,
            VehicleRegNo: newVD.VehicleRegNo,
            VehicleTypeId: (newVD.vt != null) ? newVD.vt.Id : newVD.VehicleTypeId,
            VehicleLayoutId: (newVD.vl != null) ? newVD.vl.Id : newVD.VehicleLayoutId,
            FleetOwnerId: $scope.s.Id,
            CompanyId: $scope.cmp.Id,
            ServiceTypeId: (newVD.st != null) ? newVD.st.Id : newVD.ServiceTypeId,
            EngineNo: newVD.EngineNo,
            FuelUsed: newVD.FuelUsed,
            MonthAndYrOfMfr: newVD.MonthAndYrOfMfr,
            ChasisNo: newVD.ChasisNo,
            SeatingCapacity: newVD.SeatingCapacity,
            DateOfRegistration: newVD.DateOfRegistration,
            Active: 1,
            insupddelflag: 'I'

        };

        var req = {
            method: 'POST',
            url: '/api/Fleet/NewFleetDetails',
            //headers: {
            //    'Content-Type': undefined

            data: Fleet
        }

        $http(req).then(function (response) {

          //  $scope.showDialog("Saved successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };

    $scope.setFleet = function (F) {
        $scope.currVD = F;
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
    $scope.filterValue = function ($event) {
        if (isNaN(String.fromCharCode($event.keyCode))) {
            $event.preventDefault();
        }
    };

    $scope.clearGroup = function () {
        $scope.currGroup = null;
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

