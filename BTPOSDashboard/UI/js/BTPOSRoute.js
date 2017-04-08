var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap']);
var ctrl = app.controller('myctrl', function ($scope, $http, $localStorage) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.userCmpId = $scope.userdetails[0].CompanyId;
    $scope.userSId = $scope.userdetails[0].UserId;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;


   
    $scope.GetFleetBtposRoutes = function () {

        if ($scope.cmp == null)
        {
            $scope.cmpdata = null;
            $scope.BtposRoutes = null;
            return;
        }

        if ($scope.s == null)
        {
            $scope.BtposRoutes = null;
            return;
        }

        $http.get('/api/BtposRoutes/GetFleetBtposRoutes?cmpId=' + $scope.cmp.Id + '&fleetOwnerId=' + $scope.s.Id).then(function (res, data) {
            $scope.BtposRoutes = res.data;
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
            }
            else {
                document.getElementById('test').disabled = false;
            }
            $scope.GetFleetOwners($scope.cmp);
        });

    }
    $scope.GetFleetOwners = function () {


        $http.get('/api/Getfleet').then(function (res, data) {
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
            $scope.GetFleetBtposRoutes($scope.s);
        });
    }
    //$scope.GetCompanies = function ()
    //{

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
    //    $http(req).then(function (res)
    //    {
    //        $scope.initdata = res.data;
    //        //  $scope.companies = res.data.Table;
    //    });

    //}

    //$scope.GetFleetOwners = function ()
    //{
    //    if ($scope.cmp == null)
    //    {
    //        $scope.cmpdata = null;
    //        $scope.Fleet = null;
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
    //    $http(req).then(function (res)
    //    {
    //        $scope.cmpdata = res.data;
    //    });
    //}
   

  /*  $scope.getBtposRoutes = function () {

        $http.get('/api/BtposRoutes/getBtposRoutes').then(function (res, data) {
            $scope.BtposRoutes = res.data;
        });
    }*/
    $scope.GetVehicleConfig = function () {

        var vc = {
            needVehicleRegNo: '1',
            needPOSID: '1',
            needroute: '1',
         //   needvehiclelayout: '1',
          //  needCompanyName: '1'
        };

        var req = {
            method: 'POST',
            url: '/api/VehicleConfig/VConfig',
            //headers: {
            //    'Content-Type': undefined

            data: vc


        }
        $http(req).then(function (response) {

            //$scope.showDialog("Saved successfully!");

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