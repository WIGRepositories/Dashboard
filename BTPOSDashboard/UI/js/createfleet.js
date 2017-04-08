// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {

    $scope.dashboardDS = $localStorage.dashboardDS;

    //app.controller('showHide', function ($scope) {
    //  $scope.toggle = function () {
    //    if (!$scope.myForm.email - input.$valid) {
    //     alert(valid);
    //}
    //};

    $scope.save = function (Fleet, flag) {

        var Fleet = {
            Id: Fleet.Id,
            FirstName: Fleet.FirstName,
            LastName: Fleet.LastName,

            //UserTypeId: (role) ? 2 : User.UserType,

            Email: Fleet.Email,

            MobileNo: Fleet.MobileNo,
            //RoleId: (role) ? 2 : User.Role,

            CompanyName: Fleet.CompanyName,
            Description: Fleet.Description,
            insupdflag: flag

        }

        var req = {
            method: 'POST',
            url: '/api/CreateFleetOwner/Savenewfleet',
            data: Fleet
        }
        $http(req).then(function (response) {

           // $scope.showDialog("Saved successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });

        $scope.User1 = null;
    };

    $scope.setUsers = function (usr) {
        $scope.User1 = usr;

    };

    $scope.clearUsers = function () {
        $scope.User1 = null;
    }


});
