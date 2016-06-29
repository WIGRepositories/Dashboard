var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {
    $scope.dashboardDS = $localStorage.dashboardDS;

    $scope.GetEditHistory = function () {
        $http.get('http://localhost:1476/api/EditHistory/GetEditHistory').then(function (res, data) {
            $scope.Edit = res.data;
        })
    }

    $scope.setEditHistroyId = function (L) {
        $http.get('http://localhost:1476/api/EditHistoryDetails/GetEditHistoryDetails?edithistoryid=' + L.Id).then(function (res, data) {
            $scope.details = res.data;
        })
    }
});
