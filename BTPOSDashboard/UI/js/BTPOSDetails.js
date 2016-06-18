var app = angular.module('myApp', ['ngStorage'])

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname;

    btposlist = [];

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
            $scope.initdata = res.data;
        });
        $scope.GetBTPOSList();

    } 


    $scope.GetBTPOSList = function () {

        $scope.cmpdata = null;
        $scope.BTPOS1 = null;

        var cmpId = ($scope.cmp == null || $scope.cmp.Id == null) ? -1 : $scope.cmp.Id;
        var fId = ($scope.s == null || $scope.s.Id == null) ? -1 : $scope.s.Id;

        $http.get('http://localhost:1476/api/BTPOSDetails/GetBTPOSDetails?cmpId=' + cmpId + '&fId=-1').then(function (response, req) {
            $scope.BTPOS1 = response.data;
         
            //  $localStorage.BTPOSOld = response.data;
            $scope.setPage();
        })

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
            $scope.cmpdata = res.data;
        });

    };

    $scope.GetBTPOSListByFleetOwner = function () {
               
        $scope.BTPOS1 = null;

        var cmpId = ($scope.cmp == null || $scope.cmp.Id == null) ? -1 : $scope.cmp.Id;
        var fId = ($scope.s == null || $scope.s.Id == null) ? -1 : $scope.s.Id;

        $http.get('http://localhost:1476/api/BTPOSDetails/GetBTPOSDetails?cmpId=' + cmpId + '&fId=' + fId).then(function (response, req) {
            $scope.BTPOS1 = response.data;
            //  $localStorage.BTPOSOld = response.data;
        })
    }

    $scope.addpos = function (pos)
    {
        if (pos == null) {
            alert('Please enter IMEI.');
            return;
        }

        if (pos.IMEI == null) {
            alert('Please enter IMEI.');
            return;
        }
        
        if (pos.CompanyId == null)
        {
            alert('Please enter CompanyId')
            return;
        }
        var found = false;
        for (var i = 0; i < btposlist.length ; i++)
        {
            if(btposlist[i].Id == pos.Id)
            {
                found = true;

                btposlist[i].IMEI = pos.IMEI;
                btposlist[i].ipconfig = pos.ipconfig;
                btposlist[i].insupdflag = 'U';
                break;
            }
        }
        if (!found)
        {
            var Group = {
                Id: pos.Id,
                GroupName: pos.GroupName,
                CompanyId: 1,//pos.CompanyId,
                IMEI: pos.IMEI,
                POSID: pos.POSID,
                StatusId: 4,//pos.StatusId,
                ipconfig: pos.ipconfig,
                active: 1,//Group.ipconfig,
                fleetownerid: null,//pos.FleetOwnerId,
                insupdflag: 'U'
            }

            btposlist.push(Group);
        }
    }

    $scope.saveBTPOSList = function () {

        $http({
            url: 'http://localhost:1476/api/BTPOSDetails/SaveBTPOSDetails',
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            data: btposlist,

        }).success(function (data, status, headers, config) {
            alert('saved btpos details successfully');
        }).error(function (ata, status, headers, config) {
            alert(ata);
        });

   }
        

    $scope.save = function (Group, flag) {
      
                var newpos = {
                    Id: Group.Id,
                    CompanyId: $scope.cmp.Id,
                    GroupId: Group.GroupId,
                    IMEI: Group.IMEI,
                    POSID: Group.POSID,
                    StatusId: Group.StatusId,
                    ipconfig: Group.ipconfig,
                    active: 1,//Group.ipconfig,
                    fleetownerid: $scope.s.Id,
                    insupdflag: flag
                }
                btposlist.push(newpos);

                var req = {
                    method: 'POST',
                    url: 'http://localhost:1476/api/BTPOSDetails/SaveBTPOSDetails',
                    data: btposlist 
                }

                $http(req).then(function (response) {
                    alert('saved btpos details successfully');                    
                });
      
        $scope.currGroup = null;
    };


    $scope.setBTPOS = function (grp) {
        $scope.currGroup = grp;

        $http.get('http://localhost:1476/api/Types/TypesByGroupId?groupid=1').then(function (res, data) {
            $scope.Types = res.data;
        });
    };

    $scope.clearGroup = function () {
        $scope.currGroup = null;
    }


    var columnDefs = [
    // this row just shows the row index, doesn't use any data from the row
    {
        headerName: "#", width: 50, cellRenderer: function (params) {
            return params.node.id + 1;
        }
    },
    { headerName: "POSID", field: "POSID", width: 150 },
    { headerName: "IMEI", field: "IMEI", width: 90 },
    { headerName: "Company Name", field: "Company Name", width: 120 },
    { headerName: "IPConfig", field: "IPConfig", width: 90 },
    { headerName: "FleetOwner", field: "FleetOwner", width: 110 },
    { headerName: "Status", field: "status", width: 110 },
    { headerName: "Update", field: "Update", width: 100 },
   
    ];

    var pageSize = 500;

    var gridOptions = {
        // note - we do not set 'virtualPaging' here, so the grid knows we are doing standard paging
        enableSorting: true,
        enableFilter: true,
        debug: true,
        rowSelection: 'multiple',
        enableColResize: true,
        columnDefs: columnDefs,
        rowModelType: 'pagination'
    };

    function onPageSizeChanged(newPageSize) {
        pageSize = new Number(newPageSize);
        createNewDatasource();
    }

    // when json gets loaded, it's put here, and  the datasource reads in from here.
    // in a real application, the page will be got from the server.
    var allOfTheData;

    function createNewDatasource() {
        if (!allOfTheData) {
            // in case user selected 'onPageSizeChanged()' before the json was loaded
            return;
        }

        var dataSource = {
            //rowCount: ???, - not setting the row count, infinite paging will be used
            pageSize: pageSize, // changing to number, as scope keeps it as a string
            getRows: function (params) {
                // this code should contact the server for rows. however for the purposes of the demo,
                // the data is generated locally, a timer is used to give the experience of
                // an asynchronous call
                console.log('asking for ' + params.startRow + ' to ' + params.endRow);
                setTimeout(function () {
                    // take a chunk of the array, matching the start and finish times
                    var rowsThisPage = allOfTheData.slice(params.startRow, params.endRow);
                    // see if we have come to the last page. if we have, set lastRow to
                    // the very last row of the last page. if you are getting data from
                    // a server, lastRow could be returned separately if the lastRow
                    // is not in the current page.
                    var lastRow = -1;
                    if (allOfTheData.length <= params.endRow) {
                        lastRow = allOfTheData.length;
                    }
                    params.successCallback(rowsThisPage, lastRow);
                }, 500);
            }
        };

        gridOptions.api.setDatasource(dataSource);
    }

    function setRowData(rowData) {
        allOfTheData = rowData;
        createNewDatasource();
    }

    // setup the grid after the page has finished loading
    document.addEventListener('DOMContentLoaded', function () {
        var gridDiv = document.querySelector('#myGrid');
        new agGrid.Grid(gridDiv, gridOptions);

        // do http request to get our sample data - not using any framework to keep the example self contained.
        // you will probably use a framework like JQuery, Angular or something else to do your HTTP calls.
        var httpRequest = new XMLHttpRequest();
        httpRequest.open('GET', '../olympicWinners.json');
        httpRequest.send();
        httpRequest.onreadystatechange = function () {
            if (httpRequest.readyState == 4 && httpRequest.status == 200) {
                var httpResponse = JSON.parse(httpRequest.responseText);
                setRowData(httpResponse);
            }
        };
    });
   

 //  $scope.setPage = function ExampleController(PagerService) {
  //          var vm = this;

  //          vm.dummyItems = _.range(1, 151); // dummy array of items to be paged
  //          vm.pager = {};
  //          vm.setPage = setPage;

  //          initController();

  //          function initController() {
  //              // initialize to page 1
  //              vm.setPage(1);
  //          }

  //          function setPage(page) {
  //              if (page < 1 || page > vm.pager.totalPages) {
  //                  return;
  //              }

  //              // get pager object from service
  //              vm.pager = PagerService.GetPager(vm.dummyItems.length, page);

  //              // get current page of items
  //              vm.items = vm.dummyItems.slice(vm.pager.startIndex, vm.pager.endIndex);
  //          }
  //      }

  //  //    function PagerService() {
  //          // service definition
  //          var service = {};

  //          service.GetPager = GetPager;

  //          return service;

  //          // service implementation
  //          function GetPager(totalItems, currentPage, pageSize) {
  //              // default to first page
  //              currentPage = currentPage || 1;

  //              // default page size is 10
  //              pageSize = pageSize || 10;

  //              // calculate total pages
  //              var totalPages = Math.ceil(totalItems / pageSize);

  //              var startPage, endPage;
  //              if (totalPages <= 10) {
  //                  // less than 10 total pages so show all
  //                  startPage = 1;
  //                  endPage = totalPages;
  //              } else {
  //                  // more than 10 total pages so calculate start and end pages
  //                  if (currentPage <= 6) {
  //                      startPage = 1;
  //                      endPage = 10;
  //                  } else if (currentPage + 4 >= totalPages) {
  //                      startPage = totalPages - 9;
  //                      endPage = totalPages;
  //                  } else {
  //                      startPage = currentPage - 5;
  //                      endPage = currentPage + 4;
  //                  }
  //              }

  //              // calculate start and end item indexes
  //              var startIndex = (currentPage - 1) * pageSize;
  //              var endIndex = startIndex + pageSize;

  //              // create an array of pages to ng-repeat in the pager control
  //              var pages = _.range(startPage, endPage + 1);

  //              // return object with all pager properties required by the view
  //              return {
  //                  totalItems: totalItems,
  //                  currentPage: currentPage,
  //                  pageSize: pageSize,
  //                  totalPages: totalPages,
  //                  startPage: startPage,
  //                  endPage: endPage,
  //                  startIndex: startIndex,
  //                  endIndex: endIndex,
  //                  pages: pages
  //              };
  //          }
  //      }
  ////  })();





});