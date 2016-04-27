
// JavaScript source code
var myapp1 = angular.module('myApp', [])
var mycrtl1 = myapp1.controller('Mycntrlr', function ($scope, $http) {

    $http.get('http://localhost:1476/api/license/getlicense?Subcatid=-1').then(function (response, data) {
        $scope.SubCategories = response.data;
        $scope.getselectval();
    })


    $scope.getselectval = function (seltype) {
        var grpid = (seltype) ? seltype.Id : -1;

        $http.get('http://localhost:1476/api/license/getlicense?Subcatid=' + grpid).then(function (res, data) {
            $scope.License = res.data;

        });
    }

    $scope.save = function (License) {

        if (License == null) {
            alert('Please enter values.');
            return;
        }

        if (License.FeatureName == null) {
            alert('Please enter FeatureName.');
            return;
        }
        if (License.FeatureValue == null) {
            alert('Please enter FeatureValue.');
            return;
        }


        var currLicense = {

            Id: License.Id,
            LicenseTypeId: License.LicenseTypeId,
            FeatureName: License.FeatureName,
            FeatureValue: License.FeatureValue,
            FeatureType: License.FeatureType,
            Description: License.Description,
            effectiveFrom: License.effectiveFrom,
            effectiveTill: License.effectiveTill,
            Label: License.Label,
            labelclass: License.labelclass,
           
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/license/savelicense',
            data: currLicense
        }
        $http(req).then(function (response) { });


        $scope.currGroup = null;

    };

    $scope.saveNewLicense = function (License) {

        if (License == null) {
            alert('Please enter values.');
            return;
        }

        if (License.FeatureName == null) {
            alert('Please enter Featurename.');
            return;
        }
        if (License.FeatureValue == null) {
            alert('Please enter Value.');
            return;
        }


        var NewLicense = {

            Id: -1,
            LicenseTypeId: License.LicenseTypeId,
            FeatureName: License.FeatureName,
            FeatureValue: License.FeatureValue,
            FeatureType: License.FeatureType,
            Description: License.Description,
            effectiveFrom: License.effectiveFrom,
            effectiveTill: License.effectiveTill,
            Label: License.Label,
            labelclass: License.labelclass,
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/subcategory/savesubcategory',
            data: NewLicense
        }

        $http(req).then(function (response) {
            alert('saved successfully.');
        });


        $scope.currRole = null;

    };

    $scope.setCurrRole = function (grp) {
        $scope.currRole = grp;
    };

    $scope.clearCurrRole = function () {
        $scope.currRole = null;
    };
});
