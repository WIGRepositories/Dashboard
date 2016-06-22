var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {
    //$scope.uname = $localStorage.uname
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;
    $scope.GetFleetOwner = function () {

        $http.get('http://localhost:1476/api/FleetOwner/getFleetOwner').then(function (res, data) {
            $scope.FleetOwner = res.data;
        });
    }
   
    $scope.setUsers = function (usr) {
        $scope.User1 = usr;
    };

    $scope.clearUsers = function () {
        $scope.User1 = null;
    }


    $scope.save = function (Fleet) {
        if (Fleet == null) {
            alert('Please enter VehicleRegNo.');
            return;
        }

        if (Fleet.Name == null) {
            alert('Please enter VehicleRegNo.');
            return;
        }
        if (Fleet.group == null || Fleet.VehicleTypeId.group.Id == null) {
            alert('Please select a type group');
            return;
        }



        var Fleet = {
            Id: Fleet.Id,
            Name: Fleet.Name,
            Company: Fleet.Company,
            FleetOwnerCode: Fleet.FleetOwnerCode,
            Active: Fleet.Active,
           

        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/Fleet/NewFleetDetails',
            //headers: {
            //    'Content-Type': undefined

            data: Fleet


        }
        $http(req).then(function (res) { });


    }

    $scope.savenewfleetdetails = function (initdata) {
        var newVD = initdata.newfleet;
        /* if (newVD == null) {
             alert('Please enter VehicleRegNo.');
             return;
         }
 
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
            Id: Fleet.Id,
            Name: Fleet.Name,
            Company: Fleet.Company,
            FleetOwnerCode: Fleet.FleetOwnerCode,
            Active: Fleet.Active,

        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/Fleet/NewFleetDetails',
            //headers: {
            //    'Content-Type': undefined

            data: Fleet
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




