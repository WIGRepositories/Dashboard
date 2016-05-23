
// JavaScript source code
// JavaScript source code
var myapp1 = angular.module('myApp', ['ngStorage'])
var mycrtl1 = myapp1.controller('Mycntrl', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname

    $scope.GetVehicleConfig = function () {

        var vc = {           
            needCompanyName: '1',
            needvehicleRegno: '1',            
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/VehicleConfig/VConfig',
            //headers: {
            //    'Content-Type': undefined

            data: vc


        }
        $http(req).then(function (res) {
            $scope.initdata = res.data;
        });

    }

    

    $scope.getUsersnRoles = function () {
        if ($scope.cmp == null) {
            $scope.cmproles1 = null;
            $scope.cmpUsers1 = null;
            return;
        }
        var cmpId = ($scope.cmp == null) ? -1 : $scope.cmp.Id;

        $http.get('http://localhost:1476/api/Roles/GetCompanyRoles?companyId=' + cmpId).then(function (res, data) {
            $scope.cmproles1 = res.data;
        });

        $http.get('http://localhost:1476/api/Users/GetUsers?cmpId=' + cmpId).then(function (res, data) {
            $scope.cmpUsers1 = res.data;
        });
    }

});

   

