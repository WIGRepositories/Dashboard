var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname
    $scope.dashboardDS = $localStorage.dashboardDS;

    $scope.increasecart() = function (qty) {
        $scope.cartitem = qty;

        for (qty = 0; qty < 50; qty++)
        {
                $scope.cartitem = $scope.cartitem + qty;
            }
            return $scope.cartitem;
     
    }

});