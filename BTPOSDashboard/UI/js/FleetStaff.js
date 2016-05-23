
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
//    //code for post and save with changes

//    $scope.GetVehicleConfig = function () {

//        var vc = {
//            needRoles:'1',	
//            needfleetowners:'1'
       
//        };

//        var req = {
//            method: 'POST',
//            url: 'http://localhost:1476/api/VehicleConfig/VConfig',
//            //headers: {
//            //    'Content-Type': undefined

//            data: vc


//        }
//        $http(req).then(function (res) {
//            $scope.initdata = res.data;
//        });

//    }

//    $scope.GetFleetStaff = function () {

//        $http.get('http://localhost:1476/api/FleetStaff/getFleetStaffList?roleid=-1').then(function (res, data) {
//            $scope.FleetStaff = res.data.Table;
//        });
//    }
//    $scope.GetFleetRouteInit = function () {

//        $http.get('http://localhost:1476/api/FleetStaff/GetFleetList').then(function (res, data) {
//            $scope.FleetStaffinit = res.data.Table;
//        });
//    }
   
//    $scope.save = function (FleetStaff) {
//        if (FleetStaff== null || FleetStaff.RoleId == null) {
//            alert('Please select a type RoleId');
//            return;
//        }
//        if (FleetStaff == null || FleetStaff.UserId == null) {
//            alert('Please select a type  UserId ');
//            return;
//        }
      
                       
       
//        var FleetStaff = {
//            Id:FleetStaff.Id,
//            RoleId: FleetStaff.RoleId,
//            UserId: FleetStaff.UserId,
//            FromDate: FleetStaff.FromDate,
//            ToDate: FleetStaff.ToDate,
//            Active: Fleet.Active,
           
//        };
     
//        var req = {
//            method: 'POST',
//            url: 'http://localhost:1476/api/FleetStaff/NewFleetStaff',
//            //headers: {
//            //    'Content-Type': undefined

//            data: FleetStaff


//        }
//        $http(req).then(function (res) { });


//    }
    
//    $scope.savenewfleetstaff = function (initdata) {
//        var newfs = initdata.newfleet;
//        /* if (newVD == null) {
//             alert('Please enter VehicleRegNo.');
//             return;
//         }
    
//         if (newVD.VehicleRegNo == null) {
//             alert('Please enter VehicleRegNo.');
//             return;
//         }
//         if (Fleet.group == null || Fleet.VehicleTypeId.group.Id == null) {
//             alert('Please select a type group');
//             return;
//         }
//         */


//        var FleetStaff = {
//            Id: -1,
//            RoleId: newVD.s.RoleId,
//            UserId: newVD.u.UserId,
//            FromDate: newVD.FromDate,
//            ToDate: newVD.ToDate
//            Active: 1

//    };

//    var req = {
//        method: 'POST',
//        url: 'http://localhost:1476/api/Fleet/NewFleetDetails',
//        //headers: {
//        //    'Content-Type': undefined

//        data: Fleet
//    }

//    $http(req).then(function (res) {
//        alert('Sucessfully saved!');
//    });




//});   

   

