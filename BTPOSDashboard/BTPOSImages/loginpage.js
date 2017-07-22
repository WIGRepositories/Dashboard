// javaScript source code
var app = angular.module('myApp', [])
var ctrl = app.controller('myCtrl', function ($scope, $http) {
    //$http.get('/api/loginpage/log').then(function (response, req) {
    //    $scope.Group = response.data;

    //});

    $scope.save = function (Group) {
        alert("saved");

        $http.get('/api/loginpage/saveloginpage?userid=' + Group.userid + '&pwd=' + Group.password).then(function (response, req) {
            $scope.Group = response.data;

        });


        //var Group1 = {

        //    userid: Group.userid,
        //    password: Group.password

        //  }

        //var req = {
        //    method: 'POST',
        //    url: '/api/loginpage/saveloginpage',

        //    data: Group1

        //}

        //$http(req).then(function (response) { });
    };
});