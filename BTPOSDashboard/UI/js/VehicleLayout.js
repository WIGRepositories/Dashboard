// JavaScript source code
var myapp1 = angular.module('myApp', ['ngStorage'])
var mycrtl1 = myapp1.controller('Mycntrlr', function ($scope, $http, $localStorage, $filter) {
    $scope.uname = $localStorage.uname;

    $scope.GetVehicleConfig = function () {

        var vc = {
            needvehicleType: '1',
            needvehiclelayout: '1'
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

           // rowCount = typeof rowCount === 'number' ? rowCount : 4;
        //  colCount = typeof colCount === 'number' ? colCount : 13;

        rowCount = document.getElementById('rowSelected').value;
        colCount = document.getElementById('colSelected').value;
            var rows = [],
                i,
                j;
            for (i = 0; i < rowCount; i++) {
                var row = [];
                for (j = 0; j < colCount; j++) {
                    row.push({"Id":spreadsheetColumnLabel(j) + (i + 1),"selected":true});
                }
                rows.push(row);
            }
            

            $scope.datarows = rows;

        //function getData(rowCount, colCount) {

        //    rowCount = typeof rowCount === 'number' ? rowCount : 100;
        //    colCount = typeof colCount === 'number' ? colCount : 4;
        //    var rows = [],
        //        i,
        //        j;
        //    for (i = 0; i < rowCount; i++) {
        //        var row = [];
        //        for (j = 0; j < colCount; j++) {
        //            row.push(spreadsheetColumnLabel(j) + (i + 1));
        //        }
        //        rows.push(row);
        //    }
        //    return rows;
        //}

        function spreadsheetColumnLabel(index) {
            var dividend = index + 1;
            var columnLabel = '';
            var modulo;
            while (dividend > 0) {
                modulo = (dividend - 1) % 26;
                columnLabel = String.fromCharCode(65 + modulo) + columnLabel;
                dividend = parseInt((dividend - modulo) / 26, 10);
            }
            return columnLabel;
        }

        //var hot = new Handsontable(container, {
        //    data: getData(3,8),
        //    startRows:8,
        //    height: 396,           
        //    rowHeaders: true,
        //    colHeaders: true,
        //  //  stretchH: 'all',            
        //    columnSorting: true,
        //    contextMenu: true           
        //});
    }

    $scope.saveVehicleLayout = function () {   
     

        var savedata = $scope.datarows;        
        int[0][1];
        //var checkedArr = []
        //var uncheckedArr = [];
        for (i = 0; i <= 20; i++)
        {
            for(j=0; j <= 20; j++)
            {
                if (a[i][j].checked)
                {
                    chkdarr[i][j] = a[i][j];
                }
                else
                {
                    unchkdarr[i][j] = a[i][j];
                }

            }
        }
   
    }


});