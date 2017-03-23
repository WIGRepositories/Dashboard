var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname
    $scope.dashboardDS = $localStorage.dashboardDS; if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;

    $scope.getNotification = function () {

        $http.get('/api/Notifications/getNotification').then(function (response, req) {
            $scope.Notifications = response.data;

        });
    }

});
//    $scope.save = function (Notifications) {

//        var Notifications = {
//            Id: -1,
//            Date: Notifications.Date,
//            Message: Notifications.Message,
//            MessageTypeId: Notifications.MessageTypeId,
//            StatusId: Notifications.StatusId,
//            UserId: Notifications.UserId,
//            Name: Notifications.Name
//        }
//    }
   
  
//});

        //var req = {
        //    method: 'POST',
        //    url: '/api/notifications/savenotification',
        //    data: Notifications
        //}
        //$http(req).then(function (response) {
        //    alert('saved successfully.');

        //});

        ////    $scope.currRole = null;

        ////};

        ////$scope.setCurrRole = function (grp) {
        ////    $scope.currRole = grp;
        ////};

        ////$scope.clearCurrRole = function () {
        ////    $scope.currRole = null;








