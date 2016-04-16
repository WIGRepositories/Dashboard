// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', []);
var ctrl = app.controller('myCtrl', function ($scope, $http) {
    $http.get('http://localhost:1476/api/Inventory/GetInventory').then(function (response, req) {
        $scope.Group = response.data;

    });
    $scope.sample = [{
        id: '29',
        name: 'BTPOS'
    }, {
        id: '29',
        name: 'Paper Rolls'
    },{
        id: '29',
        name:'Aaptors'
    }];
    $scope.getselectval = function (seltype) {
        var grpid = (seltype) ? seltype.id : -1;

        $http.get('http://localhost:1476/api/Inventory/GetInventory?groupid=' + grpid).then(function (res, data) {
            $scope.Group = res.data;

        });

        $scope.selectedvalues = 'Name: ' + $scope.selitem.name + ' Id: ' + $scope.selitem.id;

    }
    $scope.sample1 = [{
        id: '30',
        name: 'POS8100'
    }, {
        id: '30',
        name: 'Wireless Adaptor'
    },{
        id:'30',
        name:'SoftpaperRolls'
    
    }];
    $scope.getselectval1 = function (seltype1) {
        var grpid = (seltype1) ? seltype1.id : -1;

        $http.get('http://localhost:1476/api/Inventory/GetInventory?groupid=' + grpid).then(function (res, data) {
            $scope.Group = res.data;

        });

        $scope.selectedvalues = 'Name: ' + $scope.selitem.name + ' Id: ' + $scope.selitem.id;

    }




    $scope.save = function (Group, flag) {

        var Group = {
            Name: Group.Name,
            Code: Group.Code,
            Description: Group.Description,
            AvailableQty: Group.AvailableQty,
            Category: Group.CategoryId,
            SubCategory: Group.SubCategoryId,
            PerUnitPrice: Group.PerUnitPrice,
            ReorderPont: Group.ReorderPont,
            Active: (Group.Active == true) ? 0 : 1,
            insupdflag: flag


            // "Id": 1, "Name": "hyioj", "Records": "bfdfsg",

        }


        var req = {

            method: 'POST',
            url: 'http://localhost:1476/api/Inventory/SaveInventory',
            data: Group
        }
        $http(req).then(function (response) {
            alert('saved successfully.');
        });


        $scope.Inventory = null;
    };

    $scope.setInventory = function (usr) {
        $scope.Inventory = usr;

    };

    $scope.clearInventory = function () {
        $scope.Inventory = null;



    };
});