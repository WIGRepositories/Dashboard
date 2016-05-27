var app = angular.module('myApp', ['ngStorage']);
var ctrl = app.controller('mycntrlr', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname;

    $scope.GetPurchaseOrder = function () {

        $http.get('http://localhost:1476/api/PurchaseOrder/GetPurchaseOrder').then(function (res,data) {
            $scope.PurchaseOrder = res.data;
        });
    }

});




