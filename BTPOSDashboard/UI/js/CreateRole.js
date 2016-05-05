// JavaScript source code
var myapp1 = angular.module('myApp', [])
var mycrtl1 = myapp1.controller('Mycntrlr', function ($scope, $http) {
    $http.get('http://localhost:1476/api/GetCompanyGroups?userid=-1').then(function (response, data) {
        $scope.Companies = response.data;
        $scope.getselectval();
    });

    $scope.getselectval = function (seltype) {
        var cmpId = (seltype) ? seltype.Id : -1;
        $http.get('http://localhost:1476/api/Roles/getroles?companyId=' + cmpId).then(function (res, data) {
            $scope.newrole = res.data;

        });

    }

    $scope.save = function (newrole) {
        if (newrole == null) {
            alert('Please enter role name.');
            return;
        }
        if (newrole.Name == null) {
            alert('Please enter role name.');
            return;
        }


        var newrole = {

            Id: newrole.Id,
            Name: newrole.Name,
            Description: newrole.Description,
            Active: 1, //newrole.Active,
            IsPublic: 1
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/roles/saveroles',
            data: newrole
        }
        $http(req).then(function (response) {
            alert('saved successfully.');

        });
        $scope.currRole = null;

    };

    $scope.setCurrRole = function (grp) {
        $scope.currRole = grp;
    };

    $scope.clearCurrRole = function () {
        $scope.currRole = null;
    };
    
});
