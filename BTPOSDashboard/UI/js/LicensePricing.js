var app = angular.module('myApp', [])
var ctrl = app.controller('Mycntrlr', function ($scope, $http) {

    $http.get('http://localhost:1476/api/LicensePricing/LicensePricing').then(function (res, data) {
        $scope.LicensePricing = res.data;

    })


    $scope.Save = function (Licensepricing) {

        var Licensepricing = {

            LicenseId: Licensepricing.LicenseId,
            TimePeriod: Licensepricing.TimePeriod,
            UnitPrice: Licensepricing.UnitPrice,
            fromdate: Licensepricing.fromdate,
            todate: Licensepricing.todate,
            Active : Licensepricing.Active ,
            
            MinTimePeriods:Licensepricing.MinTimePeriods

          

        };
        
        var req = {
            method: 'POST',
            url: ('http://localhost:1476/api/LicensePricing/SaveLicensePricing'),
            //headers: {
            //    'Content-Type': undefined

            data: Licensepricing


        }
        $http(req).then(function (response) { });

    }

});