var app = angular.module('myApp', ['ngStorage'])

var ctrl = app.controller('Myctrlr', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname;

    /* user details functions */
    $scope.uname = $localStorage.uname;
    $http.get('http://localhost:1476/api/GetLicensePayments').then(function (response, req) {
        $scope.Group = response.data;

    });


    $scope.gridOptions = {
        data: 'sampledata',
        columnDefs: [
        { field: 'name' },
        { field: 'gender' },
        { field: 'company' },
        { field: 'click', cellTemplate: '<button class="btn primary" ng-click="grid.appScope.sampledetails()">Click Me</button>' }
        ]
    };

});
   
