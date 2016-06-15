// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname;
    $scope.GetCompanys = function () {
        $http.get('http://localhost:1476/api/GetCompanyGroups?userid=-1').then(function (response, data) {
            $scope.Companies = response.data;

        });
    }
    $scope.save = function (Group, flag) {

        if (Group == null) {
            alert('Please enter CompanyName.');
            return;
        }
        if (Group.Name == null) {
            alert('Please enter CompanyName.');
            return;
        }
        if (flag == null) {
            alert('Please enter code.');
            return;
        }
        if (Group.code == null) {
            alert('Please enter code.');
            return;
        }
        var newCmp = {
            Id: Group.Id,
            Name: Group.Name,
            admin: Group.admin,
            code: Group.code,
            descr: Group.desc,
            active: (Group.active==true)?1:0,
            insupdflag:flag 

        }
        

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/CompanyGroups/SaveCompanyGroups',
            data: newCmp
        }
        $http(req).then(function (response) {
            alert('saved successfully.');
            $scope.Group = null;
        });

     
        $scope.currGroup = null;
    };

    $scope.saveCmpChanges = function (Group, flag) {

        var Group = {
            Id: Group.Id,
            Name: Group.Name,
            admin: Group.admin,
            code: Group.code,
            descr: Group.desc,
            active: (Group.active == true) ? 1 : 0,
            insupdflag: flag

        }


        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/CompanyGroups/SaveCompanyGroups',
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