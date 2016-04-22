var app = angular.module('myApp', ['ngStorage'])

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {
    $http.get('http://localhost:1476/api/BTPOSDetails/GetBTPOSDetails').then(function (response, req) {
        $scope.BTPOS = response.data;
        $localStorage.BTPOSOld = response.data;

    });
    $scope.save = function (Group, flag) {

        //if any of the fields are changed then save
        var olddata = $localStorage.BTPOSOld;
        for (var i = 0; i < $scope.BTPOS.length; i++) {

            if ($scope.BTPOS[i].IMEI != olddata[i].IMEI) {
                var Group = {
                    Id: Group.Id,
                    GroupName: Group.GroupName,
                    GroupId: Group.GroupId,
                    IMEI: BTPOS[i].IMEI,
                    POSID: Group.POSID,
                    StatusId: Group.StatusId,
                    ipconfig: Group.ipconfig,
                    active: 1,//Group.ipconfig,
                    fleetownerid: Group.FleetOwnerId,
                    insupdflag: flag
                }


                var req = {
                    method: 'POST',
                    url: 'http://localhost:1476/api/BTPOSDetails/SaveBTPOSDetails',
                    data: Group
                }
                $http(req).then(function (response) {
                    alert('saved btpos details successfully');
                });
            }
        }
      
        $scope.currGroup = null;
    };


    $scope.setBTPOS = function (grp) {
        $scope.currGroup = grp;
    };

    $scope.clearGroup = function () {
        $scope.currGroup = null;
    }

});