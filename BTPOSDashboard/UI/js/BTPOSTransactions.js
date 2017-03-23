// JavaScript source code
var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.userCmpId = $scope.userdetails[0].CompanyId;
    $scope.userSId = $scope.userdetails[0].UserId;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;

   
    $scope.GetCompanies = function () {

        $http.get('/api/GetCompanyGroups?userid=-1').then(function (res, data) {
            $scope.Companies = res.data;
            $scope.Companies1 = res.data;


            if ($scope.userCmpId != 1) {
                //loop throug the companies and identify the correct one
                for (i = 0; i < res.data.length; i++) {
                    if (res.data[i].Id == $scope.userCmpId) {
                        $scope.cmp = res.data[i];
                        document.getElementById('test').disabled = true;
                        break
                    }
                }
                // $scope.GetFleetOwners();
            }
            else {
                document.getElementById('test').disabled = false;
            }
            $scope.GetFleetOwners($scope.cmp);
        });

    }


    $scope.GetFleetOwners = function () {
        if ($scope.cmp == null)
            return;

        var vc = {
            needfleetowners: '1',
            cmpId: $scope.cmp.Id
        };

        var req = {
            method: 'POST',
            url: '/api/VehicleConfig/VConfig',
            //headers: {
            //    'Content-Type': undefined

            data: vc


        }
        $http(req).then(function (res) {
            $scope.cmpdata = res.data;
            $scope.cmpdata1 = res.data;

            //if ($scope.userSId != 1) {
            //    //loop throug the fleetowners and identify the correct one
            //    for (i = 0; i < res.data.Table.length; i++) {
            //        if (res.data.Table[i].UserId == $scope.userSId) {
            //            $scope.s = res.data.Table[i];
            //            document.getElementById('test1').disabled = true;
            //            break
            //        }
            //    }
            //}
            //else {
            //    document.getElementById('test1').disabled = false;
            //}
           

        });
    }

    $scope.GetBTPOSTransactions = function () {

        if($scope.s ==null)
        {
            alert('Please select fleet owner');
            return;
        }

        $http.get('/api/BtposPayment/GetBTPOSTransactions?btposId=-1&fleetOwnerId=' + $scope.s.Id).then(function (res, data) {
            $scope.posTrans = res.data;            
        });
        }
        
    $scope.ShowTransDetails = function (trans) {
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

