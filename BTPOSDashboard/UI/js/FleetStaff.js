// JavaScript source code
// JavaScript source code
var myapp1 = angular.module('myApp', [])
var mycrtl1 = myapp1.controller('Mycntrlr', function ($scope, $http) {


    $http.get('http://localhost:1476/api/FleetStaff/FleetStaff').then(function (res, data) {
        $scope.FleetStaff = res.data;

    })
});


    //$scope.save = function (FleetStaff) {
       


        //var FleetStaff = {

         //   Id: FleetStaff.Id,
            //StaffRole: FleetStaff.StaffRole,
            //UserId: FleetStaff.UserId,
            //FromDate: FleetStaff.FromDate,
            //ToDate: FleetStaff.ToDate
           


        //};

       // var req = {
          //  method: 'POST',
           // url: 'http://localhost:1476/api/fleetstaff/savefleetstaff',
          //  data: FleetStaff
        //}
        //$http(req).then(function (response) {
           // alert('saved successfully.');

        //});
    //    $scope.currRole = null;

    //};

    //$scope.setCurrRole = function (grp) {
    //    $scope.currRole = grp;
    //};

    //$scope.clearCurrRole = function () {
    //    $scope.currRole = null;
    //};

//});

