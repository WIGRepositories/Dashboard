// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', [])
var ctrl = app.controller('myCtrl', function ($scope, $http) {

    $scope.GetCompanys = function () {
        $http.get('http://localhost:1476/api/GetCompanyGroups').then(function (response, data) {
            $scope.Group = response.data;

        });
    }
    $scope.save = function (Group) {
        
        var Group = {
            Id: Group.Id,
            Name: Group.Name,
            admin: Group.admin,
            code: Group.code,
            descr: Group.descr,
            active: Group.active
            // "Id": 1, "Name": "hyioj", "Records": "bfdfsg",

        }
        

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/CompanyGroups/CompanyGroups2',
            data: Group
        }
        $http(req).then(function (response) { });

     
        $scope.currGroup = null;
    };
   

    $scope.setCompany = function (grp) {
        $scope.currGroup = grp;
    };

    $scope.clearGroup = function () {
        $scope.currGroup = null;
    };
});