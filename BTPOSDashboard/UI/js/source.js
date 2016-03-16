

var app = angular.module('myApp', []);
var ctrl = app.controller('personCtrl', function ($scope, $http) {
    $http.get('http://localhost:1476/api/dashboard/getdashboard').then(function (response, req) {
        $scope.Group = response.data[0];
        $scope.Company = response.data[1];
        $scope.User = response.data[2];
  
        $scope.myVar = false;
        $scope.toggle = function() {
            $scope.myVar = !$scope.myVar;
        };
    });
})
