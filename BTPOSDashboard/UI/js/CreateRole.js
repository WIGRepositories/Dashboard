// JavaScript source code
var myapp1 = angular.module('myApp', [])
var mycrtl1 = myapp1.controller('Mycntrlr', function ($scope, $http) {

    $scope.GetRoles = function () {
        //get the roles as per the company that user has permission to 
        $http.get('http://localhost:1476/api/Roles/getroles?companyId=-1').then(function (res, data) {
            $scope.newrole = res.data;
        });
    }

    $scope.getselectval = function (seltype) {

        if (seltype == null) {
            $scope.newrole = null;
            return;
        }


        //var cmpId = (seltype) ? seltype.Id : -1;

        //var filterFlag = (cmpId == 1) ? 0 : 1;

        $http.get('http://localhost:1476/api/Roles/getroles?companyId=-1&rolesFilter='+filterFlag).then(function (res, data) {
            $scope.newrole = res.data;

        });

    }

    $scope.saveNewRole = function (newrole) {
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

    $scope.saveRole = function (currRole) {
        if (currRole == null) {
            alert('Please enter role name.');
            return;
        }
        if (currRole.Name == null) {
            alert('Please enter role name.');
            return;
        }


        var selRole = {

            Id: currRole.Id,
            Name: currRole.Name,
            Description: currRole.Description,
            Active: (currRole.Active == true) ? "1" : "0",
            IsPublic: (currRole.IsPublic == true) ? "1" : "0"
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/roles/saveroles',
            data: selRole
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

    $scope.AssignRole = function () {
        if ($scope.r == null) {
            alert('Please select role name.');
            return;
        }
        if ($scope.r.Id == null) {
            alert('Please select role name.');
            return;
        }

        if ($scope.s == null) {
            alert('Please select company.');
            return;
        }
        if ($scope.s.Id == null) {
            alert('Please select company.');
            return;
        }

        var cmprole = {

            RoleId: $scope.r.Id,
            CompanyId: $scope.s.Id,
            Active: 1
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/AssignRoles',
            data: cmprole
        }
        $http(req).then(function (response) {
            alert('saved successfully.');

        });
        $scope.currRole = null;

    };

    
});
