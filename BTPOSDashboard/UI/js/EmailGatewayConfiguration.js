var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap']);
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;
    $scope.GetEmailGateway = function () {

        $http.get('http://localhost:1476/api/EmailGatewayConfig/GetEmailGateway').then(function (response, req) {
            $scope.GetEmailGateway = response.data;

        });
    }
    
    $scope.save = function (Group,flag) {

        var newCmp = {
            providername: Group.providername,
            enddate: Group.enddate,
            hashkey: Group.hashkey,
            pwd: Group.pwd,
            saltkey: Group.saltkey,
            startdate: Group.startdate,
            username: Group.username,    //       
            Port: Group.Port,
            ClientId: Group.ClientId,
            SelectId: Group.SelectId,
            insupdflag: 'I'
        }


        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/EmailGatewayConfig/SaveEmailGatewaySettings',
            data: newCmp
        }
        $http(req).then(function (response) {

            $scope.showDialog("Saved successfully!!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });


        $scope.currGroup = null;
    };

    $scope.savecmpChanges = function (Group,flag) {

        var newCmp = {
            providername: Group.providername,
            enddate: Group.enddate,
            hashkey: Group.hashkey,
            pwd: Group.pwd,
            saltkey: Group.saltkey,
            startdate: Group.startdate,
            username: Group.username,    //       
            Port: Group.Port,
            ClientId: Group.ClientId,
            SelectId: Group.SelectId,
            insupdflag: 'U'
        }


        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/EmailGatewayConfig/SaveEmailGatewaySettings',
            data: Group
        }
        $http(req).then(function (response) {

            $scope.showDialog("Saved successfully!!");

        }
        , function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);

        });
        $scope.GetEmailGateway();
        $scope.currGroup = null;
    };

    $scope.setEmailGateway = function (grp) {
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