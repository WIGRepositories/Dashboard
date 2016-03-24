// JavaScript source code
var myapp1 = angular.module('myApp', [])
var mycrtl1 = myapp1.controller('Mycntrlr', function ($scope, $http) {

    $http.get('http://localhost:8020/api/typegroups/gettypegroups').then(function (res, data) {
        $scope.TypeGroups = res.data;
      
           

    });
    $scope.save = function (TypeGroups) {
       
        var TypeGroups = {

             
            Name: TypeGroups.Name,
            Desc: TypeGroups.Desc,
            Active: TypeGroups.Active
           

     
        };
        $scope.save
        var req = {
            method: 'POST',
            url: 'http://localhost:8020/api/typegroups/savetypegroups',
            //headers: {
            //    'Content-Type': undefined

            data: TypeGroups


        }
        $http(req).then(function (res) { });

    };



});
