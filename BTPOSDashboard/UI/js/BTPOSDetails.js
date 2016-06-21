var app = angular.module('myApp', ['ngStorage'])

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname;

    btposlist = [];

    $scope.GetCompanies = function () {

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
        $http(req).then(function (res) {
            $scope.initdata = res.data;
        });
        $scope.GetBTPOSList();

    } 


    $scope.GetBTPOSList = function () {

        $scope.cmpdata = null;
        $scope.BTPOS1 = null;

        var cmpId = ($scope.cmp == null || $scope.cmp.Id == null) ? -1 : $scope.cmp.Id;
        var fId = ($scope.s == null || $scope.s.Id == null) ? -1 : $scope.s.Id;

        $http.get('http://localhost:1476/api/BTPOSDetails/GetBTPOSDetails?cmpId=' + cmpId + '&fId=-1').then(function (response, req) {
            $scope.BTPOS1 = response.data;
         
            //  $localStorage.BTPOSOld = response.data;
            $scope.setPage();
        })

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
        $http(req).then(function (res) {
            $scope.cmpdata = res.data;
        });

    };

    $scope.GetBTPOSListByFleetOwner = function () {
               
        $scope.BTPOS1 = null;

        var cmpId = ($scope.cmp == null || $scope.cmp.Id == null) ? -1 : $scope.cmp.Id;
        var fId = ($scope.s == null || $scope.s.Id == null) ? -1 : $scope.s.Id;

        $http.get('http://localhost:1476/api/BTPOSDetails/GetBTPOSDetails?cmpId=' + cmpId + '&fId=' + fId).then(function (response, req) {
            $scope.BTPOS1 = response.data;
            //  $localStorage.BTPOSOld = response.data;
        })
    }

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
                StatusId: 4,//pos.StatusId,
                ipconfig: pos.ipconfig,
                active: 1,//Group.ipconfig,
                fleetownerid: null,//pos.FleetOwnerId,
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
                    CompanyId: $scope.cmp.Id,
                    GroupId: Group.GroupId,
                    IMEI: Group.IMEI,
                    POSID: Group.POSID,
                    StatusId: Group.StatusId,
                    ipconfig: Group.ipconfig,
                    active: 1,//Group.ipconfig,
                    fleetownerid: $scope.s.Id,
                    insupdflag: flag
                }
                btposlist.push(newpos);

                var req = {
                    method: 'POST',
                    url: 'http://localhost:1476/api/BTPOSDetails/SaveBTPOSDetails',
                    data: btposlist 
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


    $scope.setBTPOS = function (grp) {
        $scope.currGroup = grp;

        $http.get('http://localhost:1476/api/Types/TypesByGroupId?groupid=1').then(function (res, data) {
            $scope.Types = res.data;
        });
    };

    $scope.clearGroup = function () {
        $scope.currGroup = null;
    }



    //$scope.setPage = function () {

    //    $scope.cmpdata = null;
    //    $scope.BTPOS1 = null;

    //    var cmpId = ($scope.cmp == null || $scope.cmp.Id == null) ? -1 : $scope.cmp.Id;
    //    var fId = ($scope.s == null || $scope.s.Id == null) ? -1 : $scope.s.Id;

    //    $http.get('http://localhost:1476/api/BTPOSDetails/GetBTPOSDetails1?fId=-1').then(function (response, req) {
    //        $scope.BTPOS1 = response.data;
    //    })

    //    var vc = {
    //        needfleetowners: '1',
    //        cmpId: $scope.cmp.Id
    //    };

    //    var req = {
    //        method: 'POST',
    //        url: 'http://localhost:1476/api/VehicleConfig/VConfig',
    //        //headers: {
    //        //    'Content-Type': undefined

    //        data: vc


    //    }
    //    $http(req).then(function (res) {
    //        $scope.cmpdata = res.data;
    //    });

    //};





});