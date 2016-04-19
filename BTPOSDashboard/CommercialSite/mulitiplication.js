// JavaScript source code
var myapp1 = angular.module('myApp', [])
var mycrtl1 = myapp1.controller('Mycntrlr', function ($scope, $http) {

    $scope.save = function () {
        $scope.albumNameArray = [];
        angular.forEach($scope.albums,function(album){
            if(!!album.selected)$scope.albumNameArray.push(album.name);
        })
    }
        alert("testing")
        $http.post('http://localhost:49272/api/mulitiplicationsave/mulitiplication').success(function (data) {
            console.log(data);
            alert("saved successfully!!");


      
       
         
    }).error(function (data) {
        $scope.error = "An error has occured while saving! " + data;
    });
});


