var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap']);
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;
    $scope.GetPaymentGateway = function () {

        $http.get('/api/PaymentGatewayConfiguration/GetPaymentGateway').then(function (response, req) {
            $scope.GetPaymentGateway = response.data;
            for (cnt = 0; cnt < response.data.length; cnt++) {
                $scope.GetPaymentGateway[cnt].startdate = new Date($scope.GetPaymentGateway[cnt].startdate);
                $scope.GetPaymentGateway[cnt].enddate = new Date($scope.GetPaymentGateway[cnt].enddate);
            }

        });
    }   
    $scope.save = function (Group, flag) {
        if (Group == null) {
            alert('please select PaymentGateway')
        }
        if (Group.TypeGroupId == null) {
            alert('please select PaymentGateway')
        }
        if (Group.providername == null) {
            alert('please select providername')
        }
        
        var newCmp = {          
            providername: Group.providername,
            enddate: Group.enddate,
            hashkey: Group.hashkey,
            TypeGroupId: Group.TypeGroupId,
            pwd: Group.pwd,
            saltkey: Group.saltkey,
            startdate: Group.startdate,
            username: Group.username,
            ClientId: Group.ClientId,
            secretId: Group.secretId,
            insupdflag: 'I'
            
        }


        var req = {
            method: 'POST',
            url: '/api/PaymentGatewayConfiguration/SavePaymentGatewaySettings',
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

    $scope.savecmpChanges = function (Group,flag) {
       
        var Group = {
                Id :Group.Id,
                providername: Group.providername,
                enddate: Group.enddate,
                hashkey: Group.hashkey,
                PaymentGatewayTypeId: Group.PaymentGatewayTypeId,
                pwd: Group.pwd,
                saltkey: Group.saltkey,
                startdate: Group.startdate,
                username: Group.username,
                ClientId: Group.ClientId,
                secretId: Group.secretId,
                insupdflag: 'U'

        }


        var req = {
            method: 'POST',
            url: '/api/PaymentGatewayConfiguration/SavePaymentGatewaySettings',
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
        $scope.GetPaymentGateway();
        $scope.currGroup = null;
    };
    $scope.setPaymentGateway = function (grp) {
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