var app = angular.module('myApp', ['ngStorage']);
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname;
    //if ($localStorage.userdetails && $localStorage.userdetails.length > 0 && $localStorage.userdetails[0])
    //$scope.userid = $localStorage.userdetails[0].userid;

    //now call GetDashboardDetails and pass userid as parameter

    $scope.myVar = false;
    $scope.toggle = function () {
        $scope.myVar = !$scope.myVar;
      
    };

});







