var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap']);
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;
    $scope.GetSmsGatewayConfig = function () {

        $http.get('/api/SmsGatewayConfig/GetSmsGatewayConfig').then(function (response, req) {
            $scope.GetSmsGatewayConfig = response.data;
           
            for (cnt = 0; cnt < response.data.length; cnt++) {
                $scope.GetSmsGatewayConfig[cnt].startdate = new Date($scope.GetSmsGatewayConfig[cnt].startdate);
                $scope.GetSmsGatewayConfig[cnt].enddate = new Date($scope.GetSmsGatewayConfig[cnt].enddate);
            }

        });
    }
    $scope.save = function (Group,flag) {


        var newCmp = {
            Id:Group.Id,
            providername: Group.providername,
            enddate: Group.enddate,
            hashkey: Group.hashkey,          
            pwd: Group.pwd,
            saltkey: Group.saltkey,
            startdate: Group.startdate,
            username: Group.username,
            ClientId: Group.ClientId,
            SecretId: Group.SecretId,
            insupdflag: 'I'

        }


        var req = {
            method: 'POST',
            url: '/api/SmsGatewayConfig/SaveSmsGatewaySettings',
            data: newCmp
        }
        $http(req).then(function (response) {

            //$scope.showDialog("Saved successfully!!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });


        $scope.currGroup = null;
    };

    $scope.saveCmpChanges = function (Group,flag) {

       
        var Group = {
            Id:Group.Id,
            providername: Group.providername,
            enddate: Group.enddate,
            hashkey: Group.hashkey,           
            pwd: Group.pwd,
            saltkey: Group.saltkey,
            startdate: Group.startdate,
            username: Group.username,
            ClientId: Group.ClientId,
            SecretId: Group.SecretId,
            insupdflag: 'U'
           
        }


        var req = {
            method: 'POST',
            url: '/api/SmsGatewayConfig/SaveSmsGatewaySettings',
            data: Group
        }
        $http(req).then(function (response) {

            //$scope.showDialog("Saved successfully!!");

        }
        , function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);

        });
       
        $scope.currGroup = null;
    };


    $scope.setSmsGatewayConfig = function (grp) {
        $scope.currGroup = grp;
    };

    $scope.clearGroup = function () {
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
app.controller('ModalInstanceCtrl', function ($scope, $uibModalInstance, mssg) {

    $scope.mssg = mssg;
    $scope.ok = function () {
        $uibModalInstance.close('test');
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});