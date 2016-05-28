var app = angular.module('myApp', ['ngStorage']);
var ctrl = app.controller('myctrl', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname;

    $scope.getBtposRoutes = function () {

        $http.get('http://localhost:1476/api/BtposRoutes/getBtposRoutes').then(function (res, data) {
            $scope.BtposRoutes = res.data;
        });
    }
});