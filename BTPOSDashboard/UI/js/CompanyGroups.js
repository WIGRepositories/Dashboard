// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', [])
var ctrl = app.controller('myCtrl', function ($scope, $http) {

    $scope.GetUsers = function () {

        $http.get('http://localhost:1476/api/Users/GetUsers').then(function (res, data) {
            $scope.Users = res.data;
        });
    }

    $scope.GetCompanys = function () {
        $http.get('http://localhost:1476/api/GetCompanyGroups').then(function (response, data) {
            $scope.Group = response.data;

        });
    }
    $scope.save = function (Group, flag) {
        
        var Group = {
            Id: Group.Id,
            Name: Group.Name,
            admin: Group.admin,
            code: Group.code,
            descr: Group.descr,
            active: (Group.active==true)?1:0,
            insupdflag:flag 

        }
        

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/CompanyGroups/CompanyGroups2',
            data: Group
        }
        $http(req).then(function (response) {
            alert('saved successfully.');
        });

     
        $scope.currGroup = null;
    };
   

    $scope.setCompany = function (grp) {
        $scope.currGroup = grp;
    };

    $scope.clearGroup = function () {
        $scope.currGroup = null;
    };
});