
var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('Mycntrl', function ($scope, $http,$localStorage) {
    $scope.uname = $localStorage.uname

    $scope.GetFleetAvailability = function () {

        $http.get('http://localhost:1476/api/FleetAvailability/GetFleetAvailability').then(function (res, data) {
            $scope.FleetAvailability = res.data.Table;
        
    });

}

 
        
    });

//    $scope.save = function (FleetAvailability) {
//        if (FleetAvailability == null) {
//            alert('Please  enter values:');
//            return;
//        }

//        if (FleetAvailability.Vehicle == null) {
//            alert('Please enter Vehicle name:');
//            return;
//        }
//        if (FleetAvailability.ServiceType == null) {
//            alert('Please enter ServiceType:');
//            return;
//        }
//        var FleetAvailability = {
//            Id: -1,
//            Vehicle: FleetAvailability.Vehicle,
//            ServiceType: FleetAvailability.ServiceType,
//            FromDate: FleetAvailability.FromDate,
//            ToDate: FleetAvailability.ToDate
//        }

//        var req = {
//            method: 'POST',
//            url: 'http://localhost:1476/api/fleetavailability/AddFleetAvailability',

//            data: FleetAvailability
//        }


//        $http(req).then(function (res) {

//            alert('saved successfully.');

//        });

//        $scope.currRole = null;

//    };

//    $scope.setCurrRole = function (grp) {
//        $scope.currRole = grp;
//    };

//    $scope.clearCurrRole = function () {
//        $scope.currRole = null;
//    };
//});






