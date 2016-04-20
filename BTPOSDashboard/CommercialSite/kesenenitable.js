// JavaScript source code
var myapp1 = angular.module('myApp', [])
var mycrtl1 = myapp1.controller('Mycntrlr', function ($scope, $http) {
    
    $http.get('http://localhost:50780/api/KESENINE3/commericialsite').then(function (res, data) {
        $scope.tr= res.data;
        
        
    })

    {    //This will hide the DIV by default.
        $scope.IsHidden = true;
        $scope.ShowHide = function () {
            //If DIV is hidden it will be visible and vice versa.
            $scope.IsHidden = $scope.IsHidden ? false : true;
        }
    }
});
