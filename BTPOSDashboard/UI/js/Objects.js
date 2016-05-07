// JavaScript source code
// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', [])
var ctrl = app.controller('Mycntrlr', function ($scope, $http) {
 
    $http.get('http://localhost:1476/api/objects/getobjects').then(function (res, data) {
        $scope.NewObjects = res.data;
    });
    $scope.save = function (NewObjects) {
        
        if (NewObjects == null)
        {
            alert('please enter Name');
            return;
        }
        if (NewObjects.Name == null)
        {
            alert('Please Enter Nmae');
            return;
        }
       
        if (NewObjects.Path == null)
        {
            alert('Please Enter Path');
            return;
        }
   
        var NewObjects = {
            Id:-1,
            Name: NewObjects.Name,
            Description: NewObjects.Description,
            Path: NewObjects.Path,
            Access: NewObjects.Access,

            Active:1,



        }

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/objects/saveobjects',
            data: NewObjects
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
    
    }
});






