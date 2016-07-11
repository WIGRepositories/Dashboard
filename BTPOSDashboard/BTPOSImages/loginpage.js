// JavaScript source code
var app = angular.module('myApp', [])
var ctrl = app.controller('myCtrl', function ($scope, $http) {
    //$http.get('http://154.120.237.198:1476/api/loginpage/log').then(function (response, req) {
    //    $scope.Group = response.data;

    //});

    $scope.save = function (Group) {
        alert("saved");

        $http.get('http://154.120.237.198:1476/api/loginpage/saveloginpage?userid=' + Group.userid + '&pwd=' + Group.password).then(function (response, req) {
            $scope.Group = response.data;

        });


        //var Group1 = {

        //    userid: Group.userid,
        //    password: Group.password

        //  }

        //var req = {
        //    method: 'POST',
        //    url: 'http://154.120.237.198:1476/api/loginpage/saveloginpage',

        //    data: Group1

        //}

        //$http(req).then(function (response) { });
    };
});