// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', ['ngStorage','ui.bootstrap'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname;
    $scope.dashboardDS = $localStorage.dashboardDS;


    $scope.GetStops = function () {
        $http.get('http://localhost:1476/api/Stops/GetStops').then(function (res, data) {
            $scope.Stops = res.data;
        });
    }

    $scope.saveNewStop = function (newStop) {
        if (newStop == null)
        {
            alert('Please Enter Name');
            return;
        }
        if (newStop.Name == null)
        {
            alert('Please Enter Nmae');
            return;
        }       
        if (newStop.Code == null)
        {
            alert('Please Enter Code');
            return;
        }

        var newStop = {
            Id: -1,
            Name: newStop.Name,
            Description: newStop.Description,
            Code: newStop.Code,
           
            Active: (newStop.Active == true) ? 1 : 0,
          
            insupdflag: "I"
        }

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/Stops/saveStops',
            data: newStop
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


        $scope.Stops1 = null;
    

    $scope.save = function (Stops, flag) {
        if (Stops == null) {
            alert('Please Enter Name');
            return;
        }
        if (Stops.Name == null) {
            alert('Please Enter Nmae');
            return;
        }
        if (Stops.Code == null) {
            alert('Please Enter Code');
            return;
        }

        var Stops = {
            Id: Stops.Id,
            Name: Stops.Name,
            Description: Stops.Description,
            Code: Stops.Code,

            Active: (Stops.Active == true) ? 1 : 0,


            insupdflag: "U"
        }

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/Stops/saveStops',
            data: Stops
        }
        $http(req).then(function (response) {
            alert('saved successfully.');

        });


        $scope.Stops1 = null;
    };

    $scope.setStops = function (usr) {
        $scope.Stops1 = usr;
    };

    $scope.clearStops = function () {
        $scope.Stops1 = null;
    }


   




