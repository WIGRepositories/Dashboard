var app = angular.module('myApp', [])
var ctrl = app.controller('Mycntrlr', function ($scope, $http) {

    var range = [];

    $scope.GetLicenseCategories = function ()
    {
        $http.get('http://localhost:1476/api/Types/TypesByGroupId?groupid=3').then(function (res, data) {
            $scope.lcat = res.data;
            document.getElementById('btnAdd').disabled = true;
        });

        $http.get('http://localhost:1476/api/Types/TypesByGroupId?groupid=7').then(function (res, data) {
            $scope.FreqTypes = res.data;
        });
     
        
        for (var i = 1; i <= 100; i++) {
            range.push(i);
        }
        $scope.range = range;
    }

    $scope.getLicensePricing = function () {

        var selCat = $scope.s;

        document.getElementById('btnAdd').disabled = false;

        if (selCat == null) {
            $scope.lpricing = null;
            document.getElementById('btnAdd').disabled = true;
            return;
        }

        $http.get('http://localhost:1476/api/LicensePricing/LicensePricing?categoryid=' + selCat.Id).then(function (res, data) {
            $scope.lpricing = res.data;

        });

        $http.get('http://localhost:1476/api/License/GetLicenseTypes?catid=' + selCat.Id).then(function (res, data) {
            $scope.lTypes = res.data;
        });
    }
    

    $scope.currLicense = function (L) {
        $scope.currSelLicense = L;
    }

    $scope.SaveNewPricing = function () {

        var newLicensePricing = {
            Id:-1,
            LicenseId: $scope.l.Id,
            RenewalFreqTypeId: $scope.ftype.Id,
            RenewalFreq: $scope.freq,
            UnitPrice: $scope.newUnitPrice,
            fromdate: $scope.nfd,
            todate: $scope.ntd,
            insupddelflag: 'I'           
        }
    
        var req = {
            method: 'POST',
            url: ('http://localhost:1476/api/LicensePricing/SaveLicensePricing'),
            //headers: {
            //    'Content-Type': undefined

            data: newLicensePricing


        }
        $http(req).then(function (response) {
            alert('saved successfully');
        });
    }



    $scope.Save = function (currSelLicense) {

        var newLicensePricing = {
            Id: currSelLicense.Id,
            LicenseId: currSelLicense.LicenseId,
            RenewalFreqTypeId: currSelLicense.ftype.Id,
            RenewalFreq: currSelLicense.freq,
            UnitPrice: currSelLicense.UnitPrice,
            fromdate: currSelLicense.fd,
            todate: currSelLicense.td,
            insupddelflag: 'U'
        }

        var req = {
            method: 'POST',
            url: ('http://localhost:1476/api/LicensePricing/SaveLicensePricing'),
            //headers: {
            //    'Content-Type': undefined

            data: newLicensePricing


        }
        $http(req).then(function (response) {
            alert('saved successfully');
        });
    }

});