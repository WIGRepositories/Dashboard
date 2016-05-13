var app = angular.module('myApp', [])
var ctrl = app.controller('Mycntrlr', function ($scope, $http) {

    $http.get('http://localhost:1476/api/LicenseDetails/LicenseDetails').then(function (res, data) {
        $scope.License = res.data;

    })


    $scope.Save = function (LicenseDetails) {

        var LicenseDetails = {

            FeatureName: LicenseDetails.FeatureName,
            FeatureValue: LicenseDetails.FeatureValue,
            FeatureLabel: LicenseDetails.FeatureLabel,
            LicenseCode: LicenseDetails.LicenseCode,
            LicenseName: LicenseDetails.LicenseName,
            LabelClass: LicenseDetails.LabelClass,
            Active: LicenseDetails.Active,
            fromDate: LicenseDetails.fromDate,
            toDate: LicenseDetails.toDate


        };

        var req = {
            method: 'POST',
            url: ('http://localhost:1476/api/LicenseDetails/SaveLicenseDetails'),
            //headers: {
            //    'Content-Type': undefined

            data: LicenseDetails


        }
        $http(req).then(function (response) { });

    }

});