var app = angular.module('myApp', ['ngStorage']);
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname;
    //if ($localStorage.userdetails && $localStorage.userdetails.length > 0 && $localStorage.userdetails[0])
    //$scope.userid = $localStorage.userdetails[0].userid;

    //now call GetDashboardDetails and pass userid as parameter
    $http.get('http://localhost:1476/api/dashboard/getdashboard?userid=-1&roleid=-1').then(function (res, data) {
        $scope.Group = res.data;
    });

    $scope.myVar = false;
    $scope.toggle = function () {
        $scope.myVar = !$scope.myVar;
      
    };
    $scope.show = function () {
        
    }

});



//var myApp = angular.module('myApp', []);
//myApp.controller('mainCtrl', ['$scope', function ($scope) {

//     Set the default value of inputType
//    $scope.inputType = 'password';

//     Hide & show password function
//    $scope.hideShowPassword = function () {
//        if ($scope.inputType == 'password')
//            $scope.inputType = 'text';
//        else
//            $scope.inputType = 'password';
//    };

//}]);






