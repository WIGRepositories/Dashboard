var app = angular.module('myApp', [])
var ctrl = app.controller('myCtrl', function ($scope, $http) {

    $http.get('http://localhost:1476/api/EditHistory/GetEditHistory').then(function (res, data) {
        $scope.Edit = res.data;
        $scope.setEdit = function (L) {
          
        }
        $http.get('http://localhost:1476/api/EditHistoryDetails/GetEditHistoryDetails').then(function (res, data) {
        })
    })
});
