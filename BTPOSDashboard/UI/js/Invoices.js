var app = angular.module('myApp', ['ngStorage']);
var ctrl = app.controller('myctrl', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname;

    $scope.GetInvoices = function () {

        $http.get('http://localhost:1476/api/Invoices/GetInvoices').then(function (res, data) {
            $scope.Invoices = res.data;
        });
    }

});




