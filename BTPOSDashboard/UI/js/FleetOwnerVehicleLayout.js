// JavaScript source code
var myapp1 = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var mycrtl1 = myapp1.controller('myCtrl', function ($scope, $http, $localStorage, $filter, $uibModal) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;



    $scope.GetCompanies = function () {

        var vc = {
            needCompanyName: '1'
        };

        var req = {
            method: 'POST',
            url: '/api/VehicleConfig/VConfig',
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
            url: '/api/VehicleConfig/VConfig',
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
            needvehicleType: '1',
            needvehiclelayout: '1',
            needCompanyName: '1'

        };

        var req = {
            method: 'POST',
            url: '/api/VehicleConfig/VConfig',
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
                row.push({ "Id": spreadsheetColumnLabel(j) + (i + 1), "selected": true });
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
    $scope.save = function (currFR) {
        var FleetRoute = currFR.newfleet;

        if (FleetRoute == null || FleetRoute.v == null) {
            alert('Please select a type VehicleId');
            return;
        }
        if (FleetRoute.v == null) {
            alert('Please select Vehicle.');
            return;
        }
        if (FleetRoute.r == null) {
            alert('Please select a type  RouteId ');
            return;
        }

        var FleetRoutes = {
            Id: -1,
            VehicleId: FleetRoute.v.Id,
            RouteId: FleetRoute.r.RouteId,
            EffectiveFrom: FleetRoute.EffectiveFrom,
            EffectiveTill: FleetRoute.EffectiveTill,
            Active: FleetRoute.Active,
            insupddelflag: 'U'

        };

        var req = {
            method: 'POST',
            url: '/api/FleetRoutes/NewFleetRoutes',
            //headers: {
            //    'Content-Type': undefined

            data: FleetRoutes


        }
        $http(req).then(function (res) { });


    }
    $scope.SaveFleetOwnerVehicleLayout = function () {

            var savedata = $scope.datarows;
            //var Vl = {
            //    Id: -1,
            //    RowNo: $scope.Id,
            //    VehicleId: $scope.V.Id,
            //    VehicleITypeId: $scope.checkedArr[cnt].VehicleITypeId,
            //    ColNo: $scope.checkedArr[cnt].ColNo,
            //    label: $scope.checkedArr[cnt].lbl,
            
            //    insupddelflag: 'I'
            
            //}

            //rowCount = document.getElementById('rowSelected').value;
            //colCount = document.getElementById('colSelected').value;
      
            ////var checkedArr = []
            ////var uncheckedArr = [];
            var checkedArr = new Array();
            var uncheckedArr = new Array();
            //var rows = [];
            //i;      
            //var col = [];
            //j;
            for (i = 0; i < savedata.length; i++)
            {
                for(j=0; j < savedata[i].length; j++)
                {                

                    var item = {
                        "label": savedata[i][j].Id, 
                        "RowNo": i,
                        "ColNo": j,
                        "VehicleLayoutTypeId": $scope.layout.vl.Id,
                        "VehicleTypeId": $scope.layout.vt.Id,                    
                    }                
                    item.insupdflag = (savedata[i][j].selected == true) ? "I" : "D";
                    checkedArr.push(item)                
                }
            }
       
            //write the post logic and test
            var req = {
                method: 'POST',
                url: '/api/VehicleLayout/SaveFleetOwnerVehicleLayout',
                data: checkedArr

            }
            $http(req).then(function (response) {

               // $scope.showDialog("Saved successfully!");

                $scope.Group = null;

            }, function (errres) {
                var errdata = errres.data;
                var errmssg = "";
                errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
                $scope.showDialog(errmssg);
            });
            $scope.currGroup = null;
    };

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