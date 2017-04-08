var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {
    $scope.currpagefirst = 1;
    //$scope.currpage = 0;
    $scope.totalRecords = 0;
    // $scope.totalpages = 12;
    $scope.pagesize = 5;

    $scope.myFunction = function () {
        if ($scope.currpage >= 1) {
            $scope.currpage++;
        }
        else ($scope.currpage <= $scope.totalpages)

        $scope.currpage--;
    }
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.userCmpId = $scope.userdetails[0].CompanyId;
    $scope.userSId = $scope.userdetails[0].UserId;
    $scope.Roleid = $scope.userdetails[0].roleid;

   

    $scope.decPageNo = function () {
        $scope.currpagefirst = $scope.currpagefirst - 1;

        if ($scope.currpagefirst <= 0)
        {
            $scope.currpagefirst = 1;
            return;
        }

        var cmpId = ($scope.cmp == null || $scope.cmp.Id == null) ? -1 : $scope.cmp.Id;
        var fId = ($scope.s == null || $scope.s.Id == null) ? -1 : $scope.s.Id;

        $http.get('/api/BTPOSDetails/GetBTPOSDetails?cmpId=' + cmpId + '&fId=-1' + '&pageno=' + $scope.currpagefirst + '&pagesize=' + $scope.pagesize).then(function (response, req) {
            $scope.BTPOS1 = response.data;
            $scope.totalRecords = $scope.BTPOS1.Table[0].Row_count;
            $scope.totalpages = Math.ceil($scope.totalRecords / $scope.pagesize);
            
            //  $scope.btpossize.push(BTPOSdetails);
            //  $localStorage.BTPOSOld = response.data;
            // $scope.setPage();
        })

    }
 //   $scope.totalpages = $scope.totalRecords;

  

    $scope.IncPageNo = function () {
        if ($scope.currpagefirst < $scope.totalpages)//$scope.pagecount();
        {
            $scope.currpagefirst = $scope.currpagefirst + 1;

        }
        var cmpId = ($scope.cmp == null || $scope.cmp.Id == null) ? -1 : $scope.cmp.Id;
        var fId = ($scope.s == null || $scope.s.Id == null) ? -1 : $scope.s.Id;

        $http.get('/api/BTPOSDetails/GetBTPOSDetails?cmpId=' + cmpId + '&fId=-1' + '&pageno=' + $scope.currpagefirst + '&pagesize=' + $scope.pagesize).then(function (response, req) {
            $scope.BTPOS1 = response.data;
            $scope.totalRecords = $scope.BTPOS1.Table[0].Row_count;
            $scope.totalpages = Math.ceil($scope.totalRecords / $scope.pagesize);
            //  $scope.btpossize.push(BTPOSdetails);
            //  $localStorage.BTPOSOld = response.data;
            // $scope.setPage();
        })

    }


    $scope.dashboardDS = $localStorage.dashboardDS;

    btposlist = [];

    //$scope.GetCompanies = function () {

    //    var vc = {
    //        needCompanyName: '1'
    //    };

    //    var req = {
    //        method: 'POST',
    //        url: '/api/VehicleConfig/VConfig',
    //        //headers: {
    //        //    'Content-Type': undefined
    //        data: vc
    //    }
    //    $http(req).then(function (res) {
    //        $scope.initdata = res.data;
    //    });
    //    $scope.GetBTPOSList();

    //}
    $scope.GetCompanies = function () {

        $http.get('/api/GetCompanyGroups?userid=-1').then(function (res, data) {
            $scope.Companies = res.data;
            //  $scope.Companies1 = res.data;
            var cmpId = ($scope.cmp == null || $scope.cmp.Id == null) ? -1 : $scope.cmp.Id;
            var fId = ($scope.s == null || $scope.s.Id == null) ? -1 : $scope.s.Id;

            //$http.get('/api/BTPOSDetails/GetBTPOSDetails?cmpId=' + cmpId + '&fId=-1' + '&pageno=1' + '&pagesize=' + $scope.pagesize).then(function (response, req) {
            //    $scope.BTPOS1 = response.data;

            //});
            if ($scope.userCmpId != 1) {
                //loop throug the companies and identify the correct one
                for (i = 0; i < res.data.length; i++) {
                    if (res.data[i].Id == $scope.userCmpId) {
                        $scope.cmp = res.data[i];
                        document.getElementById('test').disabled = true;
                        break
                    }
                }
            }
            else {
                document.getElementById('test').disabled = false;
            }

            

            $scope.GetFleetOwners($scope.cmp);

            if ($scope.cmp == null)
            $scope.FirstPage();
        });


    }
    $scope.GetFleetOwners = function () {
        if ($scope.cmp == null)
        {
            $scope.cmpdata = null;
            $scope.cmpdata1 = null;
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
            $scope.cmpdata = res.data;
            $scope.cmpdata1 = res.data;

            if ($scope.userSId != 1) {
                //loop throug the fleetowners and identify the correct one
                for (i = 0; i < res.data.Table.length; i++) {
                    if (res.data.Table[i].UserId == $scope.userSId) {
                        $scope.s = res.data.Table[i];
                        document.getElementById('test1').disabled = true;
                        break
                    }
                }
            }
            else {
                document.getElementById('test1').disabled = false;
            }
            //  $scope.GetBTPOSListByFleetOwner($scope.s);
            $scope.FirstPage(1);

        });
    }
    $scope.GetPopupFleetOwners = function (cid) {

        var vc = {
            needfleetowners: '1',
            cmp1Id: cid
        };

        var req = {
            method: 'POST',
            url: '/api/VehicleConfig/VConfig',
            //headers: {
            //    'Content-Type': undefined

            data: vc


        }
        $http(req).then(function (res) {
            $scope.fdata = res.data;
        });

    };

    $scope.GetBTPOSList = function () {

        $scope.cmpdata = null;
        $scope.BTPOS1 = null;

        var cmpId = ($scope.cmp == null || $scope.cmp.Id == null) ? -1 : $scope.cmp.Id;
        var fId = ($scope.s == null || $scope.s.Id == null) ? -1 : $scope.s.Id;

        //$http.get('/api/BTPOSDetails/GetBTPOSDetails?cmpId=' + cmpId + '&fId=' + fId).then(function (response, req) {
        //    $scope.BTPOS1 = response.data;
        //    $scope.totalRecords = $scope.BTPOS1.Table[0].Row_count;
        //    $scope.totalpages = Math.ceil($scope.totalRecords / $scope.pagesize);
        //    //  $localStorage.BTPOSOld = response.data;
        //    // $scope.setPage();
        //})

        var vc = {
            needfleetowners: '1',
            cmpId: ($scope.cmp == null) ? '-1' : $scope.cmp.Id
        };

        var req = {
            method: 'POST',
            url: '/api/VehicleConfig/VConfig',
            //headers: {
            //    'Content-Type': undefined

            data: vc


        }
        $http(req).then(function (res) {
            $scope.cmpdata = res.data;
        });
        $scope.FirstPage(1);
    };

    $scope.btpossize = [];
    $scope.GetBTPOSDetails = function () {

        var cmpId = ($scope.cmp == null || $scope.cmp.Id == null) ? -1 : $scope.cmp.Id;
        var fId = ($scope.s == null || $scope.s.Id == null) ? -1 : $scope.s.Id;        

        $http.get('/api/BTPOSDetails/GetBTPOSDetails?cmpid=' + cmpId + '&fId=-1' + '&pageno=1' + '&pagesize=5').then(function (response, req) {
            $scope.BTPOSdetails1 = response.data;
            $scope.totalrec = $scope.BTPOSdetails1;
            $scope.totalpages = Math.ceil($scope.totalRecords / $scope.pagesize);
            // $scope.pcnt = $scope.totalrec / $scope.pagesize;
        })


    };


    //$scope.GetBTPOSDetailslist = function (pageno) {
    //    //$scope.cmpdata = null;
    //    //$scope.BTPOSdetails = null;

    //    var cmpId = ($scope.cmp == null || $scope.cmp.Id == null) ? -1 : $scope.cmp.Id;
    //    var fId = ($scope.s == null || $scope.s.Id == null) ? -1 : $scope.s.Id;
    //    if ($scope.pageno == 1) {
    //        $http.get('/api/BTPOSDetails/GetBTPOSDetails?cmpid=' + cmpId + '&fId=-1' + '&pageno=1' + '&pagesize=5').then(function (response, req) {
    //            $scope.BTPOSdetailsl = response.data;
    //            //  $scope.btpossize.push(BTPOSdetails);
    //            //  $localStorage.BTPOSOld = response.data;
    //            // $scope.setPage();
    //        })
    //    }
    //    else if ($scope.pageno == 2) {
    //        $http.get('/api/BTPOSDetails/GetBTPOSDetails?cmpid=' + cmpId + '&fId=-1' + '&pageno=2' + '&pagesize=5').then(function (response, req) {
    //            $scope.BTPOSdetails2 = response.data;
    //            //  $scope.btpossize.push(BTPOSdetails);
    //            //  $localStorage.BTPOSOld = response.data;
    //            // $scope.setPage();
    //        })
    //    }

    //    else if ($scope.pageno == 3) {
    //        $http.get('/api/BTPOSDetails/GetBTPOSDetails?cmpid=' + cmpId + '&fId=-1' + '&pageno=3' + '&pagesize=5').then(function (response, req) {
    //            $scope.BTPOSdetails3 = response.data;
    //            //  $scope.btpossize.push(BTPOSdetails);
    //            //  $localStorage.BTPOSOld = response.data;
    //            // $scope.setPage();
    //        })
    //    }
    //    else if ($scope.pageno == 4) {
    //        $http.get('/api/BTPOSDetails/GetBTPOSDetails?cmpid=' + cmpId + '&fId=-1' + '&pageno=4' + '&pagesize=5').then(function (response, req) {
    //            $scope.BTPOSdetails4 = response.data;
    //            //  $scope.btpossize.push(BTPOSdetails);
    //            //  $localStorage.BTPOSOld = response.data;
    //            // $scope.setPage();
    //        })
    //    }
    //    else ($scope.pageno == 5)
    //    {
    //        $http.get('/api/BTPOSDetails/GetBTPOSDetails?cmpid=' + cmpId + '&fId=-1' + '&pageno=5' + '&pagesize=5').then(function (response, req) {
    //            $scope.BTPOSdetails5 = response.data;
    //            //  $scope.btpossize.push(BTPOSdetails);
    //            //  $localStorage.BTPOSOld = response.data;
    //            // $scope.setPage();
    //        })
    //    }
    //};


    //  $scope.Paging = function ( cmpId,  fId,  pageno,  pagesize) {
    //      //$scope.cmpdata = null;
    //      //$scope.BTPOSdetails = null;

    //      //var cmpId = ($scope.cmp == null || $scope.cmp.Id == null) ? -1 : $scope.cmp.Id;
    //      //var fId = ($scope.s == null || $scope.s.Id == null) ? -1 : $scope.s.Id;

    //      $http.get('/api/BTPOSDetails/Paging?').then(function (response, req) {
    //          $scope.paging = response.data;
    //          //  $scope.btpossize.push(BTPOSdetails);
    //          //  $localStorage.BTPOSOld = response.data;
    //          // $scope.setPage();
    //      })


    //  };
    //  $scope.currpage = 1;
    //$scope.pagesize = 10;
    //$scope.totalRecords = 100;
    //$scope.totalpages = 10;



    //   $scope.count = 0;

    //   $scope.increase = function () {

    //      count = count + 1;
    //   }

    //   $scope.count = 0;
    //   $scope.decrease = function () {

    //     count = count - 1;
    //   }

    //   $scope.pagearr = [{ "p1": "1", "p2": "2", "p3": "3", "p4": "4", "p5": "5" }];
    //   $scope.nextPage = function () {
    //       if ($scope.isLastPage()) {
    //           return;
    //       }

    //       $scope.page++;
    //   };

    //   $scope.setPage = function (currpage) {
    //       if (currpage > $scope.pageCount()) {
    //           return;
    //       } $scope.pageCount = function (pagesize) {
    //return Math.ceil(parseInt($scope.totalpages) / parseInt($scope.pagesize));
    //  $scope.result = (parseInt($scope.totalpages) / parseInt($scope.pagesize));
    //};

    //       $scope.currpage = currpage;
    //   };


    //   $scope.nextPage = function () {
    //       if ($scope.isLastPage()) {
    //           return;
    //       }

    //       $scope.currpage++;
    //   };
    $scope.pageCount = function (pagesize) {
        return Math.ceil(parseInt($scope.totalRecords) / parseInt($scope.pagesize));
    };


    $scope.FirstPage = function (pageno) {
        $scope.currpagefirst = 1;
        var cmpId = ($scope.cmp == null || $scope.cmp.Id == null) ? -1 : $scope.cmp.Id;
        var fId = ($scope.s == null || $scope.s.Id == null) ? -1 : $scope.s.Id;
        $http.get('/api/BTPOSDetails/GetBTPOSDetails?cmpId=' + cmpId + '&fId=-1' + '&pageno=1' + '&pagesize=' + $scope.pagesize).then(function (response, req) {
            $scope.BTPOS1 = response.data;
            $scope.totalRecords = $scope.BTPOS1.Table[0].Row_count;
            $scope.totalpages = Math.ceil($scope.totalRecords / $scope.pagesize);
        });
    };

    //   $scope.firstPage = function () {
    //       $scope.currpage = 1;
    //   };

    //   //$scope.firstPage = function () {
    //   //    $scope.currpage = 0;
    //   //};

    //for (ps = 5; ps <= 150; ps + 5)
    //{
    //  $scope.totalpages = 
    //}

    $scope.lastPage = function () {
        $scope.currpagefirst = $scope.totalpages - 1;
        var cmpId = ($scope.cmp == null || $scope.cmp.Id == null) ? -1 : $scope.cmp.Id;
        var fId = ($scope.s == null || $scope.s.Id == null) ? -1 : $scope.s.Id;
        $http.get('/api/BTPOSDetails/GetBTPOSDetails?cmpId=' + cmpId + '&fId=-1' + '&pageno=' + ($scope.totalpages) + '&pagesize=' + $scope.pagesize).then(function (response, req) {
            $scope.BTPOS1 = response.data;
            $scope.totalRecords = $scope.BTPOS1.Table[0].Row_count;
            $scope.totalpages = Math.ceil($scope.totalRecords / $scope.pagesize);
        });
    };

    $scope.isFirstPage = function () {

        return $scope.currpagefirst == 1;

    };

    //   $scope.isLastPage = function () {
    //       return $scope.currpage == $scope.pageCount() - 1;
    //   };
    //  // $scope.length = $scope.pagearr.length;



    $scope.GetBTPOSListByFleetOwner = function () {

        $scope.BTPOS1 = null;

        var cmpId = ($scope.cmp == null || $scope.cmp.Id == null) ? -1 : $scope.cmp.Id;
        var fId = ($scope.s == null || $scope.s.Id == null) ? -1 : $scope.s.Id;

        $http.get('/api/BTPOSDetails/GetBTPOSDetails?cmpId=' + cmpId + '&fId=' + fId).then(function (response, req) {
            $scope.BTPOS1 = response.data;
            $scope.totalRecords = $scope.BTPOS1.Table[0].Row_count;
            $scope.totalpages = Math.ceil($scope.totalRecords / $scope.pagesize);
            //  $localStorage.BTPOSOld = response.data;
        })
    }

    $scope.addpos = function (pos) {
        if (pos == null) {
            alert('Please enter IMEI.');
            return;
        }

        if (pos.IMEI == null) {
            alert('Please enter IMEI.');
            return;
        }

        if (pos.CompanyId == null) {
            alert('Please enter CompanyId')
            return;
        }
        var found = false;
        for (var i = 0; i < btposlist.length ; i++) {
            if (btposlist[i].Id == pos.Id) {
                found = true;

                btposlist[i].IMEI = pos.IMEI;
                btposlist[i].ipconfig = pos.ipconfig;
                btposlist[i].insupdflag = 'U';
                break;
            }
        }
        if (!found) {
            //var Group = {
            //    Id: pos.Id,
            //    GroupName: pos.GroupName,
            //    CompanyId: pos.CompanyId,
            //    IMEI: pos.IMEI,
            //    POSID: pos.POSID,
            //    StatusId: pos.StatusId,
            //    ipconfig: pos.ipconfig,
            //    active: 1,//Group.ipconfig,
            //    fleetownerid: pos.fleetownerid,
            //    insupdflag: 'U'
            //}
            pos.StatusId = 4,
            pos.insupdflag = 'U';

            btposlist.push(pos);
        }
    }

    $scope.saveBTPOSList = function () {

        $http({
            url: '/api/BTPOSDetails/SaveBTPOSDetails',
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            data: btposlist,

        }).success(function (data, status, headers, config) {
            // $scope.showDialog('saved btpos details successfully');
            // $scope.GetBTPOSListByFleetOwner();
            $scope.FirstPage(1);
            btposlist = [];
        }).error(function (ata, status, headers, config) {
            var errdata = ata;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });

    }

    $scope.save = function (Group, flag) {

        var newpos = {
            Id: (flag == 'I') ? '-1' : Group.Id,
            CompanyId: (flag == 'I') ? '1' : $scope.cmp1.Id,
            //GroupId: Group.GroupId,
            IMEI: Group.IMEI,
            POSID: Group.POSID,
            StatusId: (flag == 'I') ? '1' : Group.StatusId,
            ipconfig: Group.ipconfig,
            active: 1,//Group.ipconfig,
            fleetownerid: (flag == 'I') ? null : $scope.s1.Id,
            insupdflag: flag
        }
        btposlist.push(newpos);

        var req = {
            method: 'POST',
            url: '/api/BTPOSDetails/SaveBTPOSDetails',
            data: btposlist
        }

        $http(req).then(function (response) {

            //$scope.showDialog("Saved successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };

    $scope.setBTPOS = function (grp) {
        $scope.currGroup = grp;

        $http.get('/api/Types/TypesByGroupId?groupid=1').then(function (res, data) {
            $scope.Types = res.data;
        });
    };

    $scope.clearGroup = function () {
        $scope.currGroup = null;
    }



    //$scope.setPage = function () {

    //    $scope.cmpdata = null;
    //    $scope.BTPOS1 = null;

    //    var cmpId = ($scope.cmp == null || $scope.cmp.Id == null) ? -1 : $scope.cmp.Id;
    //    var fId = ($scope.s == null || $scope.s.Id == null) ? -1 : $scope.s.Id;

    //    $http.get('/api/BTPOSDetails/GetBTPOSDetails1?fId=-1').then(function (response, req) {
    //        $scope.BTPOS1 = response.data;
    //    })

    //    var vc = {
    //        needfleetowners: '1',
    //        cmpId: $scope.cmp.Id
    //    };

    //    var req = {
    //        method: 'POST',
    //        url: '/api/VehicleConfig/VConfig',
    //        //headers: {
    //        //    'Content-Type': undefined

    //        data: vc


    //    }
    //    $http(req).then(function (res) {
    //        $scope.cmpdata = res.data;
    //    });

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

    //$scope.next() = function (currpage) {
    //    for(i=currpage ; i<= result ; i++)
    //    {
    //        currpage = i + 1;
    //    }

    //}

    $scope.GetInventoryItems = function () {
        $scope.Group = null;
        $http.get('/api/InventoryItem/GetInventoryItem?subCatId=1').then(function (response, req) {
            $scope.InventoryItem = response.data;

        });
    }

    $scope.savepurchases = function (Group) {
        if (Group == null) {
            alert('please select Item')
            return;
        }
        if (Group.Item.ItemName == null) {
            alert('please enter Item name')
            return;
        }
        if (Group.PerUnitPrice == null)
        {
            alert('please enter the Per Unit Price');
            return;
        }
        if (Group.Quantity == null) {
            alert('please enter the quantity');
            return;
        }
        if (Group.PurchaseOrderNumber == null) {
            alert('please enter Purchase Order Number');
            return;
        }
        
        if (Group.PurchaseDate == null)
        {
            alert('please enter the purchase order date');
            return;
        }
        var Group = {
            Id: -1,
            ItemName: Group.Item.ItemName,
            subCategoryId: Group.Item.SubCategoryId,
            Quantity: Group.Quantity,
            PerUnitPrice: Group.PerUnitPrice,
            PurchaseDate: Group.PurchaseDate,
            PurchaseOrderNumber: Group.PurchaseOrderNumber,
            ItemTypeId: Group.Item.Id
        }

        var req = {
            method: 'POST',
            url: '/api/InventoryPurchase/SaveInventoryPurchases',
            data: Group
        }
        $http(req).then(function (response) {

           // $scope.showDialog("Saved successfully! " + Group.Quantity + " no of POS units created");

            $scope.Group = null;
            $scope.FirstPage();

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };


});


app.controller('ModalInstanceCtrl', function ($scope, $uibModalInstance, mssg) {

    $scope.mssg = mssg;
    $scope.ok = function () {
        $uibModalInstance.close('test');
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});