var app = angular.module('myApp', ['ngStorage']);
var ctrl = app.controller('myctrl', function ($scope, $http, $localStorage) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;


    $scope.GetInvoices = function () {

        $http.get('/api/Invoices/GetInvoices').then(function (res, data) {
            $scope.Invoices = res.data;
        });
    }

});




