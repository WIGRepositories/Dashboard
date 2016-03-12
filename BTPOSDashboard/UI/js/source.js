

var app = angular.module('myApp', []);
var ctrl = app.controller('personCtrl', function ($scope, $http) {
    $http.get('http://localhost:1476/api/dashboard/getdashboard').then(function (response, req) {
        $scope.Group = response.data;
  
        $scope.myVar = false;
        $scope.toggle = function() {
            $scope.myVar = !$scope.myVar;
        };
    });
})
