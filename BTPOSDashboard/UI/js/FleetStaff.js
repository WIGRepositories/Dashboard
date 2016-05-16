// JavaScript source code
// JavaScript source code
var myapp1 = angular.module('myApp', ['ngStorage'])
var mycrtl1 = myapp1.controller('Mycntrl', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname

    $scope.GetFleetStaff = function () {

        $http.get('http://localhost:1476/api/FleetStaff/GetFleetStaff').then(function (res, data) {
            $scope.FleetStaff = res.data.Table;
        });
    }

    //$http.get('http://localhost:1476/api/FleetStaff/GetFleetstDetails').then(function (res, data) {
    //    $scope.FleetStaff = res.data;

    //})
});


  // $scope.save = function (FleetStaff) {
       


//    {   var FleetStaff = {

//           Id: FleetStaff.Id,
//            StaffRole: FleetStaff.StaffRole,
//            UserId: FleetStaff.UserId,
//            FromDate: FleetStaff.FromDate,
//            ToDate: FleetStaff.ToDate
           


//        };

//       var req = {
//           method: 'POST',
//            url: 'http://localhost:1476/api/fleetstaff/savefleetstaff',
//           data: FleetStaff
//        }
//        $http(req).then(function (response) {
//            alert('saved successfully.');

//        });
//       $scope.currRole = null;

//    };

//    $scope.setCurrRole = function (grp) {
//        $scope.currRole = grp;
//    };

//    $scope.clearCurrRole = function () {
//       $scope.currRole = null;
//    };

//});}//


