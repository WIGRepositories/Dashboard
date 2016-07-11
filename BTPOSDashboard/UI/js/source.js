var app = angular.module('myApp', ['ngStorage']);
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {    
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;

    //if ($localStorage.userdetails && $localStorage.userdetails.length > 0 && $localStorage.userdetails[0])
    //$scope.userid = $localStorage.userdetails[0].userid;

    //now call GetDashboardDetails and pass userid as parameter


    $scope.GetFleetDetails = function () {

        if ($scope.cmp == null) {
            $scope.cmpdata = null;
            return;
        }

        if ($scope.s == null) {
            $scope.Fleet = null;
            return;
        }

        $http.get('http://localhost:1476/api/Fleet/getFleetList?cmpId=' + $scope.cmp.Id + '&fleetOwnerId=' + $scope.s.Id).then(function (res, data) {
            $scope.Fleet = res.data.Table;
        });
    }

    $scope.GetCompanies = function () {

        var vc = {
            needCompanyName: '1'
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/VehicleConfig/VConfig',
            //headers: {
            //    'Content-Type': undefined
            data: vc
        }
        $http(req).then(function (res) {
            //$scope.initdata = res.data;
            $scope.companies = res.data;
        });

    }

    $scope.GetFleetOwners = function () {
        if ($scope.cmp == null) {
            $scope.cmpdata = null;
            $scope.Fleet = null;
            return;
        }
        var vc = {
            needfleetowners: '1',
            cmpId: $scope.cmp.Id
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/VehicleConfig/VConfig',
            //headers: {
            //    'Content-Type': undefined

            data: vc


        }
        $http(req).then(function (res) {
            $scope.cmpdata = res.data.Table;
        });
    }

    $scope.GetVehicleConfig = function () {

        var vc = {
            // needfleetowners:'1',
            needvehicleType: '1',
            needServiceType: '1',
            needvehiclelayout: '1',
            needCompanyName: '1'
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

    $scope.displocations = function (){
        var maplocations = $scope.locations;

                   var map = new google.maps.Map(document.getElementById('gmap_canvas'), {
                       zoom: 15,
                       center: new google.maps.LatLng(-17.8252, 31.0335), //17.8252° S, 31.0335° E
                       mapTypeId: google.maps.MapTypeId.ROADMAP
                   });
                                                       

                   var infowindow = new google.maps.InfoWindow();


                   var marker, i;


                   for (i = 0; i < maplocations.length; i++) {
                       marker = new google.maps.Marker({
                           position: new google.maps.LatLng(maplocations[i]['Xcoordinate'], maplocations[i]['Ycoordinate']),
                           map: map
                       });


                       google.maps.event.addListener(marker, 'click', (function (marker, i) {
                           return function () {
                               infowindow.setContent(maplocations[i][0]);
                               infowindow.open(map, marker);
                           }
                       })(marker, i));
                   }

    }


    $scope.getBTPOSMonitoring = function () {
        $http.get('http://localhost:1476/api/BTPOSMonitoringPage/GetBTPOSMonitoring').then(function (response, data) {
            $scope.BTPOSMonitoring = response.data;

            $scope.locations = response.data;
            $scope.displocations();
        });
    }
  

    $scope.GetDashboardDS = function ()
    {
        $http.get('http://localhost:1476/api/dashboard/getdashboard?userid=-1&roleid=-1').then(function (res, data)
        {
            $scope.dashboardDS = res.data;
            $localStorage.dashboardDS = res.data;
        });
    }
    $scope.myVar = false;
    $scope.toggle = function () {
        $scope.myVar = !$scope.myVar;
        document.getElementById('btposstatus').innerHTML = ($scope.myVar) ? "Hide" : "Show";
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






