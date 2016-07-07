var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {
     $scope.uname = $localStorage.uname;
    $scope.dashboardDS = $localStorage.dashboardDS;

    $http.get('http://localhost:1476/api/Roledetails/getroledetails').then(function (res, data) {
        $scope.Roledetails = res.data;
    });
    $scope.save = function (Roledetails) {
        alert("ok");
        var Roledetails = {
            ObjectName: Roledetails.ObjectName,
            Path: Roledetails.Path,
         

        }

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/Roledetails/saveroledetails',
            data: Roledetails
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






