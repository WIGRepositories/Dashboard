var app = angular.module('myApp', ['ngStorage']);
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;


    $scope.GetPaymentHistory = function () {

        $http.get('/api/PaymentHistory/GetPaymentHistory').then(function (res, data) {
            $scope.PaymentHistory = res.data;
        });
    }

});


