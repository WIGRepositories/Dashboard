var app = angular.module('myApp', [])
var ctrl = app.controller('Mycntrlr', function ($scope, $http) {

    $http.get('http://localhost:1476/api/LicenseDetails/License').then(function (res, data) {
        $scope.License = res.data;
    
    })
   
    $scope.Save = function (LicenseDetails) {
       
        var LicenseDetails = {

            FeatureName: LicenseDetails.FeatureName,
            FeatureValue: LicenseDetails.FeatureValue,
            FeatureLabel: LicenseDetails.FeatureLabel



    };
  
    var req = {
        method: 'POST',
        url: ('http://localhost:1476/api/LicenseDetails/btpos'),
        //headers: {
        //    'Content-Type': undefined

        data: LicenseDetails


    }
    $http(req).then(function (response) { });

}

});