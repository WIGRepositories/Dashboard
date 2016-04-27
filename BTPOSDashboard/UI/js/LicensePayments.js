// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('myCtrl', function ($scope, $http,$localStorage) {
    $scope.uname = $localStorage.uname;
    $http.get('http://localhost:1476/api/GetLicensePayments').then(function (response, req) {
        $scope.Group = response.data;

    });
    $scope.save = function (Group) {
      
        var Group = {
            expiryOn: Group.expiryOn,
            Id: Group.Id,
            licenseFor: Group.licenseFor,
            licenseId: Group.licenseId,

            licenseType: Group.licenseType,
            paidon: Group.paidon,
            renewedon: Group.renewedon,
            transId: Group.transId
        }

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/LicensePayments/LicensePayment2',
            data: Group
        }
        $http(req).then(function (response) {
          
        });
    };
});