
    var app = angular.module('myApp',[])
    var ctrl = app.controller('Mycntrlr', function ($scope, $http) {

        $scope.GetLicenseCategories = function () {
            $http.get('http://localhost:1476/api/Types/TypesByGroupId?groupid=3').then(function (res, data) {
                $scope.lcat = res.data;
            });
        }
    
        $scope.getLicenseTypes = function () {

            var selCat = $scope.s;

            if (selCat == null) {
                $scope.lTypes = null;
                return;
            }

            $http.get('http://localhost:1476/api/License/GetLicenseTypes?catid=' + selCat.Id).then(function (res, data) {
                $scope.lTypes = res.data;
            });
        }

        $scope.GetLicenseFeatures = function () {
            var selCat = $scope.l;

            if (selCat == null) {
                $scope.ldetails = null;
                return;
            }

            $http.get('http://localhost:1476/api/LicenseDetails/getLicenseDetails?catId=' + selCat.Id).then(function (res, data) {
                $scope.ldetails = res.data;
            });
        }
    
        $scope.currLicense = function (L) {
            $scope.currSelLicense = L;
        }
        $scope.Save = function (currSelLicense,flag) {

            var currSelLicense = {
                LicenseTypeId: currSelLicense.LicenseTypeId,
                FeatureName: currSelLicense.FeatureName,
                FeatureValue: currSelLicense.FeatureValue,
                FeatureLabel: currSelLicense.FeatureLabel,               
                //LabelClass: currSelLicense.LabelClass,                
                //fromDate: currSelLicense.fromDate,
                //toDate: currSelLicense.toDate
                insupddelflag:flag
              };

            var req = {
                method: 'POST',
                url: ('http://localhost:1476/api/LicenseDetails/SaveLicenseDetails'),
                //headers: {
                //    'Content-Type': undefined

                data: currSelLicense


            }
            $http(req).then(function (response) {
                alert('saved successfully');
            });

        }

        $scope.SaveNewFeature = function (currSelLicense, flag) {

            var selCat = $scope.l;

            if (selCat == null) {
                alert('Please select license type.');
                return;
            }

            var currSelLicense = {
                LicenseTypeId: selCat.Id,
                FeatureName: currSelLicense.FeatureName,
                FeatureValue: currSelLicense.FeatureValue,
                FeatureLabel: currSelLicense.FeatureLabel,
                //LabelClass: currSelLicense.LabelClass,                
                //fromDate: currSelLicense.fromDate,
                //toDate: currSelLicense.toDate
                insupddelflag: flag
            };

            var req = {
                method: 'POST',
                url: ('http://localhost:1476/api/LicenseDetails/SaveLicenseDetails'),
                //headers: {
                //    'Content-Type': undefined

                data: currSelLicense


            }
            $http(req).then(function (response) {
                alert('saved successfully');
            });

        }
    });