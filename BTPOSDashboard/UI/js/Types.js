// JavaScript source code
var myapp1 = angular.module('myApp', ['ngStorage'])
var mycrtl1 = myapp1.controller('Mycntrlr', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname;
        
    $http.get('http://localhost:1476/api/typegroups/gettypegroups').then(function (res, data) {
        $scope.TypeGroups = res.data;
        $scope.getselectval();
    });

    $scope.getselectval = function (seltype) {
        var grpid = (seltype) ? seltype.Id: -1;

        $http.get('http://localhost:1476/api/Types/TypesByGroupId?groupid=' + grpid).then(function (res, data) {
            $scope.Types = res.data;

        });

       // $scope.selectedvalues = 'Name: ' + $scope.selitem.name + ' Id: ' + $scope.selitem.Id;
        
    }

    $scope.save = function (Types) {       

        if (Types == null) {
            alert('Please enter name.');
            return;
        }

        if (Types.Name == null)
        {
            alert('Please enter name.');
            return;
        }
        if (Types.TypeGroupId == null) {
            alert('Please select a type group');
            return;
        }

        var Types = {

            Id:Types.Id,
            Name: Types.Name,
            Description: Types.Description,
            Active: Types.Active,
            TypeGroupId: Types.TypeGroupId,
            ListKey: Types.ListKey,
            Listvalue: Types.Listvalue
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/Types/SaveType',
            //headers: {
            //    'Content-Type': undefined
            data: Types
        }

        $http(req).then(function (res) {
            alert('Saved successfully');
        
        });

        $scope.currGroup = null;

    };

    $scope.saveNewType = function (newType) {

        if (newType == null) {
            alert('Please enter name.');
            return;
        }

        if (newType.Name == null) {
            alert('Please enter name.');
            return;
        }

        if (newType.group ==null || newType.group.Id == null) {
            alert('Please select a type group');
            return;
        }       

        var newTypeData = {

            Id: '-1',
            Name: newType.Name,
            Description: newType.Description,
            Active: 1,//newType.Active,
            TypeGroupId: newType.group.Id,
            ListKey: newType.ListKey,
            Listvalue: newType.Listvalue
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/Types/SaveType',           
            data: newTypeData
        }

        $http(req).then(function (res) {
            alert('Saved successfully');
            newType = null;
        }); 
    };

    $scope.setCompany = function (grp) {
        $scope.currGroup = grp;
    };

    $scope.clearGroup = function () {
        $scope.currGroup = null;
    };    
});