// JavaScript source code
// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', [])
var ctrl = app.controller('Mycntrlr', function ($scope, $http) {
 
    $http.get('http://localhost:1476/api/objects/getobjects').then(function (res, data) {
        $scope.NewObjects = res.data;
    });
    $scope.save = function (NewObject) {
        
        if (NewObject == null)
        {
            alert('please enter Name');
            return;
        }
        if (NewObject.Name == null)
        {
            alert('Please Enter Nmae');
            return;
        }
       
        if (NewObject.Path == null)
        {
            alert('Please Enter Path');
            return;
        }
   
        var SelNewObjects = {
            Id:-1,
            Name: NewObject.Name,
            Description: NewObject.Description,
            Path: NewObject.Path,
            Access: NewObject.Access,
            insupddelflag:'U',
            Active:1,



        }

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/objects/saveObjects',
            data: SelNewObjects
        }
        $http(req).then(function (response) {
            alert('saved successfully.');

        });



       

        $scope.currRole = null;

    };


    $scope.saveNewObjects = function (NewObject) {

        if (NewObject == null) {
            alert('Please enter name.');
            return;
        }

        if (NewObject.Name == null) {
            alert('Please enter name.');
            return;
        }




        var SelNewObjects = {


            Id: -1,
            Name: NewObject.Name,
            Description: NewObject.Description,
            Path: NewObject.Path,

            Active: 1,
            insupddelflag: 'I'
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/Objects/saveObjects',
            data: SelNewObjects
        }

        $http(req).then(function (res) {
            alert('saved successfully');
        });
    };

    $scope.setCurrRole = function (grp) {
        $scope.currRole = grp;
    };

    $scope.clearCurrRole = function () {
        $scope.currRole = null;

    };
});






