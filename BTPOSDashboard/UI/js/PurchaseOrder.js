var app = angular.module('myApp', ['ngStorage']);
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;


    $scope.GetPurchaseOrder = function () {

        $http.get('http://localhost:1476/api/PurchaseOrder/GetPurchaseOrder').then(function (res,data) {
            $scope.PurchaseOrder = res.data;
        });
    }

});




