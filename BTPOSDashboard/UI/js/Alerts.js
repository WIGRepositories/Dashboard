var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;

    $scope.GetAlerts = function () {

        $http.get('/api/Alerts/GetAlerts').then(function (response, req) {
            $scope.GetAlerts = response.data;

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
//            url: '/api/alert/savealerts',
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







