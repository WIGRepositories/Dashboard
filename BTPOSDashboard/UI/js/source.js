

var app = angular.module('myApp', []);
var ctrl = app.controller('myCtrl', function ($scope, $http) {
    $http.get('http://localhost:1476/api/Dashboard/getdashboard').then(function (response, data) {
       
        $scope.BTPOS = response.data.Table;
        $scope.Group = response.data.Table1;
        $scope.User = response.data.Table2;
       // $scope.Group = response.data[0];
      //  $scope.Group = response.data[0];
       
  
    });

    $scope.myVar = false;
    $scope.toggle = function () {
        $scope.myVar = !$scope.myVar;
    }

});







