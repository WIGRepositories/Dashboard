
var app = angular.module('myApp', [])
var ctrl = app.controller('myCtrl', function ($scope, $http) {

    $http.get('http://localhost:1476/api/Notifications/getNotification').then(function (res, data) {
        $scope.Notifications = res.data;
    })
 
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
        //    url: 'http://localhost:1476/api/notifications/savenotification',
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








