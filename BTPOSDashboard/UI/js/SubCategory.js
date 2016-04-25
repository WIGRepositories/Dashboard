// JavaScript source code
var myapp1 = angular.module('myApp', [])
var mycrtl1 = myapp1.controller('Mycntrlr', function ($scope, $http) {

    $http.get('http://localhost:1476/api/subcategory/getcategory').then(function (response, data) {
        $scope.Categories = response.data;
        $scope.getselectval();
    })


    $scope.getselectval = function (seltype) {
        var grpid = (seltype) ? seltype.Id : -1;

        $http.get('http://localhost:1476/api/subcategory/getsubcategory?catid=' + grpid).then(function (res, data) {
            $scope.SubCategory = res.data;

        });
    }

    $scope.save = function (SubCategory) {

        if (SubCategory == null) {
            alert('Please enter values.');
            return;
        }

        if (SubCategory.Name == null) {
            alert('Please enter name.');
            return;
        }
        if (SubCategory.Category == null) {
            alert('Please enter Category.');
            return;
        }


        var currSubCategory = {

            Id: SubCategory.Id,
            Name: SubCategory.Name,
            Description: SubCategory.Description,
            Active:  SubCategory.Active,
            TypeGroupId: SubCategory.Category.Id

        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/subcategory/savesubcategory',
            data: currSubCategory
        }
        $http(req).then(function (response) { });


        $scope.currGroup = null;

    };

    $scope.saveNewSubCategory = function (SubCategory) {

        if (SubCategory == null) {
            alert('Please enter values.');
            return;
        }

        if (SubCategory.Name == null) {
            alert('Please enter name.');
            return;
        }
        if (SubCategory.Category == null) {
            alert('Please enter Category.');
            return;
        }


        var NewSubCategory = {

            Id: -1,
            Name: SubCategory.Name,
            Description: SubCategory.Description,
            Active: 1,//SubCategory.Active,
            TypeGroupId: SubCategory.Category.Id
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/subcategory/savesubcategory',
            data: NewSubCategory
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