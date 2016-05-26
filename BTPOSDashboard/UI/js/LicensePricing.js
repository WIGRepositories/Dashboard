var app = angular.module('myApp', [])
var ctrl = app.controller('Mycntrlr', function ($scope, $http) {

    $scope.GetLicenseCategories = function ()
    {
        $http.get('http://localhost:1476/api/Types/TypesByGroupId?groupid=3').then(function (res, data) {
            $scope.lcat = res.data;
        });
    }

    $scope.getLicensePricing = function () {

        var selCat = $scope.s;

        if (selCat == null) {
            $scope.lpricing = null;
            return;
        }

        $http.get('http://localhost:1476/api/LicensePricing/LicensePricing?categoryid=' + selCat.Id).then(function (res, data) {
            $scope.lpricing = res.data;

        });
    }


    $scope.getLicenseDetails = function () {
        $http.get('http://localhost:1476/api/LicensePricing/LicensePricing').then(function (res, data) {
            $scope.LicensePricing = res.data;

        })
    }
    $scope.currLicense = function (L) {
        $scope.currSelLicense = L;
    }

    $scope.Save = function (currSelLicense) {

        var currSelLicense = {

            LicenseId: currSelLicense.LicenseId,
            TimePeriod: currSelLicense.TimePeriod,
            UnitPrice: currSelLicense.UnitPrice,
            fromdate: currSelLicense.fromdate,
            todate: currSelLicense.todate,
            Active: currSelLicense.Active,

            MinTimePeriods: currSelLicense.MinTimePeriods



        };

        var req = {
            method: 'POST',
            url: ('http://localhost:1476/api/LicensePricing/SaveLicensePricing'),
            //headers: {
            //    'Content-Type': undefined

            data: currSelLicense


        }
        $http(req).then(function (response) { });

    }

});