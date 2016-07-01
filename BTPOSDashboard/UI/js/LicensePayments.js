// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var ctrl = app.controller('myCtrl', function ($scope, $http,$localStorage) {
    $scope.uname = $localStorage.uname;
    $scope.dashboardDS = $localStorage.dashboardDS;
    $http.get('http://localhost:1476/api/GetLicensePayments').then(function (response, req) {
        $scope.Group = response.data;

    });
    $scope.save = function (Group,flag) {
      
        var Group = {
            expiryOn: Group.expiryOn,
            Id: Group.Id,
            licenseFor: Group.licenseFor,
            licenseId: Group.licenseId,

            licenseType: Group.licenseType,
            paidon: Group.paidon,
            renewedon: Group.renewedon,
            transId: Group.transId,
            insupdflag:flag
        }

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/LicensePayments/LicensePayment2',
            data: Group
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