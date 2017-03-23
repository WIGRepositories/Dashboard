// JavaScript source code
var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.userCmpId = $scope.userdetails[0].CompanyId;
    $scope.userSId = $scope.userdetails[0].UserId;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;

    
    $scope.GetBTPosDetails = function () {

        if ($scope.cmp == null) {
            $scope.cmpdata = null;
            $scope.FleetOwners = null;

            return;
        }

        if ($scope.s == null) {
            $scope.sdata = null;
            $scope.BTPos = null;
            return;
        }
        if ($scope.b == null) {
            $scope.BTPos = null;
        }

        $http.get('/api/BTPOSConfig/GetFleeBTPosDetails?cmpId=' + $scope.cmp.Id + '&fleetOwnerId=' + $scope.s.Id + '&BTPosId=' + $scope.b.Id).then(function (res, data) {
            $scope.BTPos = res.data;
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
            $scope.getFleetOwnerRoute($scope.s);
        });
    }

   
    $scope.GetBTPosForFO = function () {

        if ($scope.s == null) {
            $scope.BTPos = null;
            return;
        }
        var vc = {
            needBTPos: '1',

            sId: $scope.s.Id
        };

        var req = {
            method: 'POST',
            url: '/api/VehicleConfig/VConfig',
            //headers: {
            //    'Content-Type': undefined

            data: vc


        }
        $http(req).then(function (res) {
            $scope.sdata = res.data;
        });
    }


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