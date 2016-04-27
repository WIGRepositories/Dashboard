// JavaScript source code
var myapp1 = angular.module('myApp', ['ngStorage'])
var mycrtl1 = myapp1.controller('Mycntrlr', function ($scope, $http,$localStorage) {
    $scope.uname = $localStorage.uname;
    $http.get('http://localhost:1476/api/typegroups/gettypegroups').then(function (res, data) {
        $scope.TypeGroups = res.data;
    });

    $scope.save = function (TypeGroup) {
      
        var SelTypeGroup = {
            Name: TypeGroup.Name,
            Description: TypeGroup.Description,
            Active: TypeGroup.Active,
            Update: TypeGroup.Update,
            Id: TypeGroup.Id
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/typegroups/savetypegroups',
            //headers: {
            //    'Content-Type': undefined
            data: SelTypeGroup
        }
        $http(req).then(function (res) {
            alert('saved successfully');
       
        });

        $scope.currGroup = null;
    };

    $scope.setTypeGroup = function (grp) {
    $scope.currGroup = grp;
};

$scope.clearGroup = function () {
    $scope.currGroup = null;
};


});
