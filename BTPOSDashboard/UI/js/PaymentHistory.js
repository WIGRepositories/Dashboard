var app = angular.module('myApp', ['ngStorage']);
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname;
    $scope.dashboardDS = $localStorage.dashboardDS;

    $scope.GetPaymentHistory = function () {

        $http.get('http://localhost:1476/api/PaymentHistory/GetPaymentHistory').then(function (res, data) {
            $scope.PaymentHistory = res.data;
        });
    }

});


