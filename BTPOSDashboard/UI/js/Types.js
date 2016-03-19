// JavaScript source code
var myapp1 = angular.module('myApp', [])
var mycrtl1 = myapp1.controller('Mycntrlr', function ($scope, $http) {

    $http.get('http://localhost:1476/api/Types/Type1').then(function (res, data) {
        $scope.Types = res.data;


    });
    $scope.save = function (Types) {
        alert("ok");
        var Types = {

         Id:Types.Id,
            Name: Types.Name,
            Desc: Types.Desc,
            Active: Types.Active,
            TypeGroup: Types.TypeGroup
        };
        $scope.save
        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/Types/Type2',
            //headers: {
            //    'Content-Type': undefined

            data: Types


        }
        $http(req).then(function (res) { });
      
    };
    
});