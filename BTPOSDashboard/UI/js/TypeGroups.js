// JavaScript source code
var myapp1 = angular.module('myApp', [])
var mycrtl1 = myapp1.controller('Mycntrlr', function ($scope, $http) {

    $http.get('http://localhost:1476/api/typegroups/gettypegroups').then(function (res, data) {
        $scope.TypeGroups = res.data;
      
           

    });
    $scope.save = function (TypeGroups) {
      
        var TypeGroups = {


            Name: TypeGroups.Name,
            Description: TypeGroups.Description,
            Active: TypeGroups.Active,
            Update:TypeGroups.Update


        };
        $scope.save
        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/typegroups/savetypegroups',
            //headers: {
            //    'Content-Type': undefined

            data: TypeGroups


        }
        $http(req).then(function (res) { });



        $scope.currGroup = null;

    };

$scope.setCompany = function (grp) {
    $scope.currGroup = grp;
};

$scope.clearGroup = function () {
    $scope.currGroup = null;
};


});
