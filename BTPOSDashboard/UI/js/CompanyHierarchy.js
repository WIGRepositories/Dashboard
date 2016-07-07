var app = angular.module('myApp', ['ngStorage']);

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {
     $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;

    $scope.GetCompanys = function () {
        $http.get('http://localhost:1476/api/GetCompanyGroups?userid=-1').then(function (response, data) {
            $scope.Companies = response.data;

        });
    }
});
