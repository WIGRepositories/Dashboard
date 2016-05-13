var app = angular.module('myApp', [])
var ctrl = app.controller('Mycntrlr', function ($scope, $http) {
    $scope.GetLicenseCategories = function () {
        $http.get('http://localhost:1476/api/subcategory/getsubcategory?catid=6').then(function (res, data) {
            $scope.License = res.data;

        })

    }
    $scope.getLicenseDetails = function () {
        $http.get('http://localhost:1476/api/LicensePricing/LicensePricing').then(function (res, data) {
            $scope.Licenses = res.data;

        })
    }
    $scope.currLicense = function (L) {
        $scope.currSelLicense = L;
    }
    $scope.Save = function (currSelLicense) {

        var currSelLicense = {

            FeatureName: currSelLicense.FeatureName,
            FeatureValue: currSelLicense.FeatureValue,
            FeatureLabel: currSelLicense.FeatureLabel,
            LicenseCode: currSelLicense.LicenseCode,
            LicenseName: currSelLicense.LicenseName,
            LabelClass: currSelLicense.LabelClass,
            Active: currSelLicense.Active,
            fromDate: currSelLicense.fromDate,
            toDate: currSelLicense.toDate


        };

        var req = {
            method: 'POST',
            url: ('http://localhost:1476/api/LicenseDetails/SaveLicenseDetails'),
            //headers: {
            //    'Content-Type': undefined

            data: currSelLicense


        }
        $http(req).then(function (response) { });

    }

});