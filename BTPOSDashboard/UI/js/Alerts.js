var app = angular.module('myApp', ['ngStorage','ui.bootstrap'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname
    $scope.dashboardDS = $localStorage.dashboardDS;


    $scope.GetAlert = function () {

        $http.get('http://localhost:1476/api/Alert/GetAlert').then(function (response, req) {
            $scope.Alert = response.data;

        });
    }

});


    //$scope.save = function (A) {

    //    var Alerts = {
    //        Id: -1,
    //        Date: Alerts.Date,
    //        Message: Alerts.Message,
    //        MessageTypeId: Alerts.MessageTypeId,
    //        StatusId: Alerts.StatusId,
    //        UserId: Alerts.UserId,
    //        Name: Alerts.Name




    //    }
    //}
    //});

//        var req = {
//            method: 'POST',
//            url: 'http://localhost:1476/api/alert/savealerts',
//            data: Alerts
//        }
//        $http(req).then(function (response) {
//            alert('saved successfully.');

//        });

//    //    $scope.currRole = null;

//    //};

//    //$scope.setCurrRole = function (grp) {
//    //    $scope.currRole = grp;
//    //};

//    //$scope.clearCurrRole = function () {
//    //    $scope.currRole = null;

//    }
//});







