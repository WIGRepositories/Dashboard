// JavaScript source code

var myapp1 = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var mycrtl1 = myapp1.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;
    $scope.GetRoutes = function () {
        $http.get('http://localhost:1476/api/Routes/GetRoutes').then(function (res, data) {
            $scope.routes = res.data;
        });
    }
    //This will hide the DIV by default.
    $scope.IsVisible = false;
    $scope.ShowHide = function () {
        //If DIV is visible it will be hidden and vice versa.
        $scope.IsVisible = $scope.ShowPassport;
    }
    $scope.GetStops = function () {
        $http.get('http://localhost:1476/api/Stops/GetStops').then(function (res, data) {          
            $scope.Stops = res.data;
        });
    }

    //$scope.myVar = false;
    //$scope.toggle = function () {
    //    $scope.myVar = !$scope.myVar;
    //};
    $scope.save = function (routes) {

        if (routes == null) {
            alert('Please enter Route');
            return;
        }
        if (routes.RouteName == null) {
            alert('plaease enter Route');
            return;

        }

        if (routes.Code == null) {
            alert('Please enter Code');
            return;
        }

        if (routes.Source == null) {
            alert('Please enter Source');
            return;
        }

        if (routes.Destination == null) {
            alert('Please enter Destination');
            return;
        }

        if (routes.Distance == null) {
            alert('Please enter Distance');
            return;
        }


        var newroute = {
            RouteName: routes.RouteName,
            Code: routes.Code,
            Description: routes.Description,
            Active: 1,//(routes.Active==true)?1:0,
            //BTPOSGroupId: routes.BTPOSGroupId,
            SourceId: routes.Source.Id,
            DestinationId: routes.Destination.Id,
            Distance: routes.Distance
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/Routes/SaveRoutes',
            //headers: {
            //    'Content-Type': undefined
            data: newroute
        }

        $http(req).then(function (res) {
            // alert('Route created successfully');
            $scope.GetRoutes();
        });

        //insert the return route details if provided
        var needReturnRoute = document.getElementById('rtn').checked;

        if (needReturnRoute) {
            var retroutes = {
                RouteName: routes.ReturnRouteName,
                Code: routes.ReturnCode,
                Description: routes.Description,
                Active: 1,//(routes.Active==true)?1:0,
                //BTPOSGroupId: routes.BTPOSGroupId,
                SourceId: routes.Destination.Id,
                DestinationId: routes.Source.Id,
                Distance: routes.Distance
            };

            var req = {
                method: 'POST',
                url: 'http://localhost:1476/api/Routes/SaveRoutes',
                //headers: {
                //    'Content-Type': undefined
                data: retroutes
            }

            $http(req).then(function (res) {
                // alert('Route created successfully');
            });
        }
        $http(req).then(function (response) {

            $scope.showDialog("Saved successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };
    //    alert('saved successfully.');
    //    $scope.routes = null;
    //};
    $scope.showDialog = function (message) {

        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: 'myModalContent.html',
            controller: 'ModalInstanceCtrl',
            resolve: {
                mssg: function () {
                    return message;
                }
            }
        });
    }


    //var map;
    //$(document).ready(function () {
    //    prettyPrint();
    //    map = new GMaps({
    //        div: '#map',
    //        lat: -12.043333,
    //        lng: -77.028333
    //    });
    //    map.setContextMenu({
    //        control: 'map',
    //        options: [{
    //            title: 'Add marker',
    //            name: 'add_marker',
    //            action: function (e) {
    //                this.addMarker({
    //                    lat: e.latLng.lat(),
    //                    lng: e.latLng.lng(),
    //                    title: 'New marker'
    //                });
    //                this.hideContextMenu();
    //            }
    //        }, {
    //            title: 'Center here',
    //            name: 'center_here',
    //            action: function (e) {
    //                this.setCenter(e.latLng.lat(), e.latLng.lng());
    //            }
    //        }]
    //    });
    //});

    $scope.SetMap = function () {
        $scope.map = new GMaps({
            div: '#map',
            lat: -20.1325066,
            lng: 28.626479000000018,
            enableNewStyle: true
        });

        $scope.map.setContextMenu({
            control: 'map',
            options: [{
                title: 'Add Stop',
                name: 'add_marker',
                action: function (e) {

                    this.addMarker({
                        lat: e.latLng.lat(),
                        lng: e.latLng.lng(),
                        title: 'New marker'
                        //,icon : {
                        //    size : new google.maps.Size(32, 32),
                        //    url : icon
                        //}
                       , click: function(e){
                        if(console.log)
                            console.log(e);
                        alert('You clicked in this marker');
                    }

                    });
                }
            }, {
                title: 'Center here',
                name: 'center_here',
                action: function(e) {
                    this.setCenter(e.latLng.lat(), e.latLng.lng());
                }
            }]
        });

       // angular.getElementById('map') = $scope.map;
        //lat : item.location.lat,
        //lng : item.location.lng,
        //title : item.name,
        //icon : {
        //    size : new google.maps.Size(32, 32),
        //    url : icon
        //}

       
        

    }

    $scope.test = function () {
        alert();
    }

   
});
myapp1.controller('ModalInstanceCtrl', function ($scope, $uibModalInstance, mssg) {

    $scope.mssg = mssg;
    $scope.ok = function () {
        $uibModalInstance.close('test');
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});
