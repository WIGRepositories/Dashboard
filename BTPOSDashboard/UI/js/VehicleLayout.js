// JavaScript source code
var myapp1 = angular.module('myApp', ['ngStorage'])
var mycrtl1 = myapp1.controller('Mycntrlr', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname;

    $scope.GetVehicleConfig = function () {

        var vc = {
            needvehicleType: '1',
            needvehiclelayout: '1',
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


    $scope.getselectval = function (vlType) {
        if (vlType == null) {
            $scope.vlConfig = null;
            return;
        }     
    }

    $scope.displayLayout = function () {
        var container = document.getElementById('basic_example');

        var data = function () {
            return Handsontable.helper.createSpreadsheetData(eval($scope.rows), eval($scope.cols));
        };

        var hot = new Handsontable(container, {
            data: data(),
            height: 396,
            colHeaders: false,
            rowHeaders: false,
            stretchH: 'all',
            columnSorting: true,
            contextMenu: true
        });
    }


});