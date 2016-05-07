var app = angular.module('myApp', ['ngStorage'])

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname;

    btposlist = [];

    $scope.GetBTPOSList = function () {
        $http.get('http://localhost:1476/api/BTPOSDetails/GetBTPOSDetails').then(function (response, req) {
            $scope.BTPOS1 = response.data;
            //  $localStorage.BTPOSOld = response.data;
        })
    };

    $scope.addpos = function (pos)
    {
        if (pos == null) {
            alert('Please enter IMEI.');
            return;
        }

        if (pos.IMEI == null) {
            alert('Please enter IMEI.');
            return;
        }
        
        if (pos.CompanyId == null)
        {
            alert('Please enter CompanyId')
            return;
        }
        var found = false;
        for (var i = 0; i < btposlist.length ; i++)
        {
            if(btposlist[i].Id == pos.Id)
            {
                found = true;

                btposlist[i].IMEI = pos.IMEI;
                btposlist[i].ipconfig = pos.ipconfig;
                btposlist[i].insupdflag = 'U';
                break;
            }
        }
        if (!found)
        {
            var Group = {
                Id: pos.Id,
                GroupName: pos.GroupName,
                CompanyId: 1,//pos.CompanyId,
                IMEI: pos.IMEI,
                POSID: pos.POSID,
                StatusId: 7,//pos.StatusId,
                ipconfig: pos.ipconfig,
                active: 1,//Group.ipconfig,
                fleetownerid: 1,//pos.FleetOwnerId,
                insupdflag: 'U'
            }

            btposlist.push(Group);
        }
    }

    $scope.saveBTPOSList = function () {

        $http({
            url: 'http://localhost:1476/api/BTPOSDetails/SaveBTPOSDetails',
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            data: btposlist,

        }).success(function (data, status, headers, config) {
            alert('saved btpos details successfully');
        }).error(function (ata, status, headers, config) {
            alert(ata);
        });

   }
        

    $scope.save = function (Group, flag) {
      
                var newpos = {
                    Id: Group.Id,
                    CompanyId: 1,//Group.CompanyId,
                    GroupId: Group.GroupId,
                    IMEI: Group.IMEI,
                    POSID: Group.POSID,
                    StatusId: 7,//Group.StatusId,
                    ipconfig: Group.ipconfig,
                    active: 1,//Group.ipconfig,
                    fleetownerid: 1,//Group.FleetOwnerId,
                    insupdflag: flag
                }
                btposlist.push(newpos);

                var req = {
                    method: 'POST',
                    url: 'http://localhost:1476/api/BTPOSDetails/SaveBTPOSDetails',
                    data: btposlist 
                }

                $http(req).then(function (response) {
                    alert('saved btpos details successfully');                    
                });
      
        $scope.currGroup = null;
    };


    $scope.setBTPOS = function (grp) {
        $scope.currGroup = grp;
    };

    $scope.clearGroup = function () {
        $scope.currGroup = null;
    }   
});