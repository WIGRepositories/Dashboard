var app = angular.module('myApp', ['ngStorage']);
var ctrl = app.controller('myctrl', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname;

   
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

        $http.get('http://localhost:1476/api/BtposRoutes/GetFleetBtposRoutes?cmpId=' + $scope.cmp.Id + '&fleetOwnerId=' + $scope.s.Id).then(function (res, data) {
            $scope.BtposRoutes = res.data;
        });
    }
   
    $scope.GetCompanies = function ()
    {

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
        $http(req).then(function (res)
        {
            $scope.initdata = res.data;
            //  $scope.companies = res.data.Table;
        });

    }

    $scope.GetFleetOwners = function ()
    {
        if ($scope.cmp == null)
        {
            $scope.cmpdata = null;
            $scope.Fleet = null;
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
        $http(req).then(function (res)
        {
            $scope.cmpdata = res.data;
        });
    }
   

  /*  $scope.getBtposRoutes = function () {

        $http.get('http://localhost:1476/api/BtposRoutes/getBtposRoutes').then(function (res, data) {
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
            url: 'http://localhost:1476/api/VehicleConfig/VConfig',
            //headers: {
            //    'Content-Type': undefined

            data: vc


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