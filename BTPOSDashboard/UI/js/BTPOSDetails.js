// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', [])
var ctrl = app.controller('myCtrl', function ($scope, $http) {
    $http.get('http://localhost:1476/api/GetBTPOSDetails').then(function (response, req) {
        $scope.Group = response.data;

    });
    $scope.save = function (Group) {

        var Group = {
            Id: Group.Id,
            GroupName: Group.GroupName,
            GroupId: Group.GroupId,
            IMEI: Group.IMEI,
            Location: Group.Location,
            POSID: Group.POSID,
          
            Status: Group.Status
            // "Id": 1, "Name": "hyioj", "Records": "bfdfsg",

        }


        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/BTPOSDetails/BTPOSDetails2',
            data: Group
        }
        $http(req).then(function (response) { });

      
        $scope.currGroup = null;
    };


    $scope.setCompany = function (grp) {
        $scope.currGroup = grp;
    };

    $scope.clearGroup = function () {
        $scope.currGroup = null;
    }

});