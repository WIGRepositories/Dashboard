/// <reference path="DataLoad.js" />
var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])

app.directive('fileReader', function () {
    return {
        scope: {
            fileReader: "="
        },
        link: function (scope, element) {
            $(element).on('change', function (changeEvent) {
                var files = changeEvent.target.files;
                if (files.length) {
                    var r = new FileReader();
                    r.onload = function (e) {
                        var contents = e.target.result;
                        scope.$apply(function () {
                            scope.fileReader = contents;
                        });
                    };

                    r.readAsText(files[0]);
                }
            });
        }
    };
});

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {

    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;
    $scope.GetDataLoad = function () {

        $http.get('/api/DataLoad/GetDataLoad').then(function (response, req) {
            $scope.GetDataLoad = response.data;
        });
    }
    $scope.csv_link = 'DataUploadTemplates/CompanyList.csv';// + $window.location.search;



    $scope.saveJSON = function () {
        var blob = new Blob([$scope.logdata], { type: "application/csv;charset=utf-8;" });
        var downloadLink = angular.element('<a></a>');
        downloadLink.attr('href', window.URL.createObjectURL(blob));
        switch ($scope.selectedvalue) {
            case 1:
                downloadLink.attr('download', 'CompanyList_log.csv');
                break;
            case 2:
                downloadLink.attr('download', 'UsersList_log.csv');
                break;
            case 3:
                downloadLink.attr('download', 'UsersList_log.csv');
                break;

            case 4:
                downloadLink.attr('download', 'UsersList_log.csv');
                break;
            case 5:
                downloadLink.attr('download', 'UsersList_log.csv');
                break;
            case 6:
                downloadLink.attr('download', 'UsersList_log.csv');
                break;
            case 7:
                downloadLink.attr('download', 'UsersList_log.csv');
                 break;

        }
        
        downloadLink[0].click();
    };

    $scope.importData = function () {

        alert($scope.selectedvalue);
        switch ($scope.selectedvalue) {
            case 1:
                  //read the file and prepare array for company and call company saving webapi
                break;
            case 2:
                //read the file and prepare array for user and call user saving webapi
                break;
        }

        $scope.processData($scope.fileContent)
    }




    $scope.processData = function (allText) {
        // split content based on new line
        var allTextLines = allText.split(/\r\n|\n/);

        var headers = allTextLines[0].split(',');

        //validate header

        var lines = [];

        for (var i = 0; i < allTextLines.length; i++) {
            // split content based on comma
            var data = allTextLines[i].split(',');
            if (data.length == headers.length) {
                var tarr = [];
                for (var j = 0; j < headers.length; j++) {
                    tarr.push(data[j]);
                }
                lines.push(tarr);
            }
        }
        $scope.logdata = lines;
    };

    //$scope.setValue = function (selectedvalue) {
    //    alert(selectedvalue);
    //}


  var options =  [
        {
            "1": { "Col1": "CompanyName", "Col2": "Active" }
        },
    {
        "2": { "Col1": "FirstName", "Col2": "LastName" }
    },

  {
            "3": { "Col1": "UserId", "Col2": "RoleId" }
  },

{
    "4": { "Col1": "VehicleRegno", "Col2": "CompanyId", "Col2": "Active" }
},
{
    "5": { "Col1": "Name",  "Col2": "Active" }
},
{
    "6": { "Col1": "Routename", "Col2": "Active" }
},

{
    "7": { "Col1": "CompanyId", "Col2": "FleetownerId" }
},

{
    "8": { "Col1": "itemname", "Col2": "CategoryId" }
},
    ]

});