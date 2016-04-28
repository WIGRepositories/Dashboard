// JavaScript source code
var myapp1 = angular.module('myApp', [])
var mycrtl1 = myapp1.controller('Mycntrlr', function ($scope, $http) {

    $http.get('http://localhost:1476/api/Notifications/Notification').then(function (res, data) {
        $scope.type = res.data;


    });
    $scope.save = function (type) {




        var type = {



            Id: type.Id,
            Date: type.Date,
            Message: type.Message,
            MessageType: type.MessageType,
            MessageTypeId: type.MessageTypeId,
            Status: type.Status


        };
        $scope.save
        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/Notifications/Notification',
            //headers: {
            //    'Content-Type': undefined

            data: type


        }
        $http(req).then(function (res) { });

    };



});
