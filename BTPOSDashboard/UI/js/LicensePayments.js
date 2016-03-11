// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', [])
var ctrl = app.controller('myCtrl', function ($scope, $http) {
    $http.get('http://localhost:1476/api/LicensePayments/LicensePayment1').then(function (response, req) {
        $scope.Group = response.data;

    });
    $scope.save = function (Group) {
        alert("saved");
        var Group = {
            expiryOn: Group.expiryOn,
            Id: Group.Id,
            licenseFor: Group.licenseFor,
            licenseId: Group.licenseId,

            licenseType: Group.licenseType,
            Paidon: Group.Paidon,
            renewedon: Group.renewedon,
            transId: Group.transId
        }

            // "Id": 1, "Name": "hyioj", "Records": "bfdfsg",

        


        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/LicensePayments/LicensePayment2',
            data: Group
        }
        $http(req).then(function (response) { });
    };
});