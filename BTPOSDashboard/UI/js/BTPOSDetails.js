// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', [])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {
    $http.get('http://localhost:8020/api/getbtposdetails').then(function (response, req) {
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
            StatusId: Group.StatusId,
            Status: Group.Status
            // "Id": 1, "Name": "hyioj", "Records": "bfdfsg",

        }


        var req = {
            method: 'POST',
            url: 'http://localhost:8020/api/BTPOSDetails/BTPOSDetails2',
            data: Group
        }
        $http(req).then(function (response) { });

        alert("saved");
        $scope.currGroup = null;
    };


    $scope.setCompany = function (grp) {
        $scope.currGroup = grp;
    };

    $scope.clearGroup = function () {
        $scope.currGroup = null;
    }

    $scope.GotToBTPOSDetails=function (btposid)
    {
        $localStorage.btposid = btposid;
        $window.location.href = 'AddNewBTPOSDetails.html';
    }
  
    $scope.GetBTPOSDetails()
    {
        var btposid = $localStorage.btposid;

        $http.get('http://localhost:8020/api/getbtposdetails?id=' + btposid).then(function (response, req) {
            $scope.btposdetails = response.data;

        });
    }
});