// JavaScript source code
var myapp1 = angular.module('myApp', ['ngStorage', 'ui.bootstrap', 'AdalAngular']);
var mycrtl1 = myapp1.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal, $filter, adalAuthenticationService) {
    if ($localStorage.uname == null) {
        window.location.href = "../login.html";
    }

    $scope.userdetails = $localStorage.userdetails;
    $scope.isSuperUser = $localStorage.isSuperUser;
    $scope.isAdminSupervisor = $localStorage.isAdminSupervisor;
    $scope.roleLocations = $localStorage.roleLocation;


    $scope.init = function () {

        $http.get('/api/GetCustomers').then(function (res, data) {
            $scope.Customers = res.data;
        });

        //$http.get('/api/Types/TypesByGroupId?groupid=4').then(function (res, data) {
        //    $scope.jobStatus = res.data;
        //});

        $http.get('/api/location/getlocations').then(function (res, data) {
            $scope.Locations = res.data;
        });
        $scope.getJobsListByStatus();
    }

    $scope.getJobsListByStatus = function () {

        var locId = ($scope.s == null) ? -1 : $scope.s.id;
        var custId = ($scope.c == null) ? -1 : $scope.c.Id;

        $http.get('/api/Jobs/GetJobsByStatus?statusId=9&locationId=' + locId + '&customerId=' + custId).then(function (res, data) {
            $scope.jobsList = res.data;
        });
    }


});
