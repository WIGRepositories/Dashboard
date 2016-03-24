// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', [])
var ctrl = app.controller('myCtrl', function ($scope, $http) {
    $http.get('http://localhost:1476/api/GetBTPOSDetails').then(function (response, req) {
        $scope.Group = response.data;

    });
    $scope.save = function (Group, flag) {

        var Group = {
            Id: Group.Id,
            GroupName: Group.GroupName,
            GroupId: Group.GroupId,
            IMEI: Group.IMEI,            
            POSID: Group.POSID,          
            StatusId: Group.StatusId,
            ipconfig:Group.ipconfig,
            active:1,//Group.ipconfig,
            fleetownerid:Group.fleetownerid,
            insupdflag:flag
        }


        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/BTPOSDetails/BTPOSDetails2',
            data: Group
        }
        $http(req).then(function (response) {
            alert('saved btpos details successfully');
        });

      
        $scope.currGroup = null;
    };


    $scope.setCompany = function (grp) {
        $scope.currGroup = grp;
    };

    $scope.clearGroup = function () {
        $scope.currGroup = null;
    }

});