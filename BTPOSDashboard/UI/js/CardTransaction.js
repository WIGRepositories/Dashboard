// javascript source code
var myapp2 = angular.module('myapp', ['ngstorage', 'ui.bootstrap']);
var mycrtl1 = myapp2.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal, $filter) {
    if ($localStorage.uname == null) {
        window.location.href = "../login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.isSuperUser = $localStorage.isSuperUser;
    $scope.roleLocations = $localStorage.roleLocation;
    $scope.isAdminSupervisor = $localStorage.isAdminSupervisor;


    //$scope.init = function () {

    //    $scope.CardUsers = $http.get('http://localhost:1476/api/Cards/GetCardUsers')
    //                       .then(function (res, data) {
    //                           $scope.CardType = res.data.Table;
    //                           $scope.CardNumber = res.data.Table1;
    //                       });
    //}

    // $scope.selCardId = $scope.parseLocation(Window.location.search)['Id'];

    //$http.get('http://localhost:1476/api/Cards/DisplayUserInfo').then(function (res, data) {
    //    $scope.CardsList = res.data;
    //    $scope.CardsList1 = $scope.CardsList;

    //    //if no selected job, then populate first job by default
    //    //if ($scope.selCardId == null) {
    //    //    if ($scope.CardsList.length > 0) {
    //    //        $scope.getCardDetails($scope.CardsList[0].Id);
    //    //        $scope.selCardId = $scope.CardsList[0].Id;
    //    //        return;
    //    //    }
    //    //}
    //    //else {
    //    //    $scope.getCardDetails($scope.selCardId);
    //    //}
    //});


    //$scope.CardListData = function () {
    //    $http.get('/api/Cards/CardListData').then(function (res, data) {
    //        $scope.CardListData = res.data;
    //        $scope.CardList = res.data;
    //    });
    //}

    //$scope.CardListData1 = function () {
    //    $scope.CardList = null;

    //    // var locId = ($scope.s == null || $scope.s.id == null) ? -1 : $scope.s.id;
    //    var Id = ($scope.c == null || $scope.c.Id == null) ? -1 : $scope.c.Id;
    //    var statusId = ($scope.a == null || $scope.a.Id == null) ? -1 : $scope.a.Id;



    //    $http.get('/api/Cards/GetCardList?statusId=' + statusId +/* '&locationId=' + locId + */'&Id=' + custId).then(function (res, data) {
    //        $scope.CardList1 = res.data;
    //        $scope.CardList = res.data;
    //    });
    //    //  $scope.CheckCanCreate(locId);   
    //}

    // JavaScript source code





    //    }

    //    $scope.getJobsListByStatus = function () {

    //        $scope.jobsList1 = null;
    //    }

    //    $scope.getJobDetails = function (selJobId) {

    //        $scope.currJob = null;
    //        $scope.jobusers = [];
    //        $scope.resources = [];
    //        $scope.tresources = [];
    //        $scope.jobdocs = [];
    //        if (selJobId == null) {
    //            return;
    //        }

    //        $http.get('/api/Jobs/GetJobDetails?jobId=' + selJobId).then(function (res, data) {
    //            $scope.currJob = res.data.Table[0];

    //            $scope.currJob.EstStartDt = getdateFormat($scope.currJob.EstStartDt);
    //            $scope.currJob.EstEndDt = getdateFormat($scope.currJob.EstEndDt);
    //            $scope.currJob.ActualEndDt = getdateFormat($scope.currJob.ActualEndDt);
    //            $scope.currJob.ActualStartDt = getdateFormat($scope.currJob.ActualStartDt);

    //            $scope.resources = res.data.Table1;
    //            $scope.jobusers = res.data.Table2;
    //            $scope.tresources = res.data.Table3;
    //            $scope.jobdocs = res.data.Table4;
    //            $scope.assetHistory = res.data.Table5;

    //            if ($scope.jobdocs) {
    //                if ($scope.jobdocs.length > 0) {
    //                    for (i = 0; i < $scope.jobdocs.length; i++) {
    //                        $scope.jobdocs[i].expiryDate = getdateFormat($scope.jobdocs[i].expiryDate);

    //                    }
    //                }
    //            }

    //            if ($scope.jobsList != null && $scope.jobsList.length > 0) {
    //                for (i = 0; i < $scope.jobsList.length; i++) {
    //                    if ($scope.jobsList[i].ID == $scope.currJob.ID) {
    //                        $scope.j = $scope.jobsList[i];
    //                        break;
    //                    }
    //                }
    //            }

    //            //set job status
    //            if ($scope.jobStatus) {
    //                if ($scope.jobStatus.length > 0) {
    //                    for (i = 0; i < $scope.jobStatus.length; i++) {
    //                        if ($scope.jobStatus[i].Id == $scope.currJob.StatusId) {
    //                            $scope.js = $scope.jobStatus[i];
    //                            $scope.a = $scope.jobStatus[i];
    //                            break;
    //                        }
    //                    }
    //                }
    //            }
    //            //set customer
    //            if ($scope.Customers) {
    //                if ($scope.Customers.length > 0) {
    //                    for (i = 0; i < $scope.Customers.length; i++) {
    //                        if ($scope.Customers[i].Id == $scope.currJob.CustomerID) {
    //                            $scope.jc = $scope.Customers[i];
    //                            $scope.c = $scope.Customers[i];
    //                            break;
    //                        }
    //                    }
    //                }
    //            }

    //            //set location
    //            if ($scope.Locations) {
    //                if ($scope.Locations.length > 0) {
    //                    for (i = 0; i < $scope.Locations.length; i++) {
    //                        if ($scope.Locations[i].id == $scope.currJob.LocationID) {
    //                            $scope.jl = $scope.Locations[i];
    //                            $scope.s = $scope.Locations[i];
    //                            break;
    //                        }
    //                    }
    //                }
    //            }

    //            //check if he is a location admin and accordingly enable assets and jobs creation for his location
    //            //check the loction of the selected asset
    //            //if user is not super user then compare with the location of the user
    //            //if location is mismatching then disable the save button
    //            $scope.CanEdit = ($scope.isSuperUser == 1) ? 1 : 0;
    //            if ($scope.isSuperUser == 0 && $scope.roleLocations != null) {

    //                $scope.CanEdit = 0;

    //                for (cnt = 0; cnt < $scope.roleLocations.length; cnt++) {
    //                    if ($scope.jl.id == $scope.roleLocations[cnt].LocationId) {
    //                        $scope.CanEdit = ($scope.roleLocations[cnt].roleid == 2) ? 1 : 0;
    //                        break;
    //                    }
    //                }
    //            }
    //        });
    //    }

    //    $scope.jobusers = [];
    //    $scope.resources = [];
    //    $scope.tresources = [];
    //    $scope.comments = [];
    //    $scope.pre = [];
    //    $scope.post = [];
    //    $scope.jobdocs = [];

    //    $scope.deletedDocs = [];
    //    $scope.addedUpdatedDocs = [];

    //    function getdateFormat(date) {
    //        var formateddate = date;

    //        if (date) {
    //            formateddate = $filter('date')(date, 'yyyy-MM-dd');
    //        }

    //        return formateddate;
    //    }

    //    $scope.Editresources = function (u) {
    //        $scope.currUser = u;
    //        $scope.currUser.FromDate = (u.FromDate == null) ? null : getdateFormat(u.FromDate);
    //        $scope.currUser.ToDate = (u.ToDate == null) ? null : getdateFormat(u.ToDate);
    //    }

    //    $scope.AddUser = function (addUser, selU) {
    //        //var fromdate = null;
    //        //var todate = null;
    //        //if ($scope.JobUsers && $scope.JobUsers.fromDt) {
    //        //    fromdate = GetFormattedDate($scope.JobUsers.fromDt);
    //        //}

    //        //if ($scope.JobUsers && $scope.JobUsers.toDt) {
    //        //    todate = GetFormattedDate($scope.JobUsers.toDt);
    //        //}
    //        $scope.currUser = null;
    //        switch (addUser) {
    //            //insertion
    //            case 1:
    //                if ($scope.ju == null) {
    //                    alert('Please select a user to add.');
    //                    $event.stopPropagation();
    //                    $event.preventDefault();
    //                    return;
    //                }
    //                var idx = IsExists($scope.ju.Id, $scope.jobusers);
    //                if (idx == -1) {
    //                    var nuser = {
    //                        "Name": $scope.ju.Name
    //                        , "JobId": $scope.currJob.ID
    //                         , "UserId": $scope.ju.Id
    //                         , "CreatedById": ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id
    //                         , "UpdatedById": ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id
    //                         , "FromDate": ($scope.JobUsers == null) ? null : getdateFormat($scope.JobUsers.fromDt)
    //                         , "ToDate": ($scope.JobUsers == null) ? null : getdateFormat($scope.JobUsers.toDt)
    //                         , "insupddelflag": "I"
    //                    };
    //                    // $scope.jobusers.push(nuser);
    //                }
    //                $scope.currUser = nuser;
    //                break;
    //                //updation
    //            case 2:
    //                // selU.insupddelflag = 'U';
    //                var idx = IsExists(selU.UserId, $scope.jobusers);
    //                if (idx > -1) {
    //                    selU.CreatedById = ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id
    //                    selU.UpdatedById = ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id
    //                    selU.JobId = $scope.currJob.ID;
    //                    $scope.currUser = selU;
    //                    $scope.currUser.insupddelflag = 'U';
    //                }

    //                // $scope.currUser = null;

    //                break;
    //                //deletion
    //            case 0:
    //                var idx = IsExists(selU.UserId, $scope.jobusers);
    //                if (idx > -1) {
    //                    selU.CreatedById = ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id
    //                    selU.UpdatedById = ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id
    //                    selU.JobId = $scope.currJob.ID;
    //                    $scope.currUser = selU;
    //                    $scope.currUser.insupddelflag = 'D';
    //                }
    //                break;
    //        }

    //        if ($scope.currUser != null) {
    //            var req = {
    //                method: 'POST',
    //                url: '/api/Jobs/SaveJobUsers',
    //                data: $scope.currUser
    //            }
    //            $http(req).then(function (response) {

    //                //$scope.showDialog("Saved successfully!");
    //                // $scope.getJobDetails($scope.modifiedJob.JobId);

    //                $scope.jobusers = response.data.Table;
    //                $scope.assetHistory = response.data.Table1;

    //                if ($scope.jobusers) {
    //                    if ($scope.jobusers.length > 0) {
    //                        for (i = 0; i < $scope.jobusers.length; i++) {
    //                            $scope.jobusers[i].expiryDate = getdateFormat($scope.jobusers[i].expiryDate);

    //                        }
    //                    }
    //                }

    //                $scope.currUser = null;
    //                $scope.ju = null;

    //            }, function (errres) {
    //                var errdata = errres.data;
    //                var errmssg = "";
    //                errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
    //                $scope.currUser = null;
    //                $scope.ju = null;
    //                $scope.showDialog(errmssg);
    //            });
    //        }
    //    }

    //    $scope.EditJobEquipment = function (equip) {
    //        $scope.CurrJobResources = equip;

    //        $scope.CurrJobResources.FromDate = (equip.FromDate == null) ? null : getdateFormat(equip.FromDate);
    //        $scope.CurrJobResources.ToDate = (equip.ToDate == null) ? null : getdateFormat(equip.ToDate);

    //    }
    //    $scope.Addresources = function (addres, selU) {

    //        var fromdate = null;
    //        var todate = null;
    //        if ($scope.JobResources && $scope.JobResources.fromDt) {
    //            fromdate = GetFormattedDate($scope.JobResources.fromDt);
    //        }

    //        if ($scope.JobResources && $scope.JobResources.toDt) {
    //            todate = GetFormattedDate($scope.JobResources.toDt);
    //        }

    //        var nuser = null;
    //        switch (addres) {
    //            //insertion
    //            case 1:
    //                var idx = IsExists($scope.jr.ID, $scope.resources);
    //                if (idx == -1) {
    //                    nuser = {
    //                        "Name": $scope.jr.Name
    //                        , "JobId": $scope.currJob.ID
    //                        , "AssetModel": $scope.amid.name
    //                        , "AssetId": $scope.jr.ID
    //                        , "CreatedById": ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id
    //                        , "UpdatedById": ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id
    //                        , "FromDate": fromdate
    //                        , "ToDate": todate
    //                        , "insupddelflag": "I"
    //                    };
    //                    $scope.JobResources = nuser;
    //                }
    //                //$scope.JobEquip = null;
    //                break;
    //                //updation
    //            case 2:
    //                selU.insupddelflag = 'U';
    //                var idx = IsAExists(selU.AssetId, $scope.resources);
    //                if (idx > -1) {
    //                    selU.CreatedById = ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id
    //                    selU.UpdatedById = ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id
    //                    selU.JobId = $scope.currJob.ID;
    //                    $scope.JobResources = selU;
    //                }

    //                //$scope.JobEquip = null;

    //                break;
    //                //deletion
    //            case 0:
    //                var idx = IsAExists(selU.AssetId, $scope.resources);
    //                if (idx > -1) {
    //                    selU.CreatedById = ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id
    //                    selU.UpdatedById = ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id
    //                    selU.JobId = $scope.currJob.ID;
    //                    $scope.JobResources = selU;
    //                    $scope.JobResources.insupddelflag = "D";
    //                }
    //                break;
    //        }

    //        if ($scope.JobResources != null) {
    //            var req = {
    //                method: 'POST',
    //                url: '/api/Jobs/SaveJobEquipment',
    //                data: $scope.JobResources
    //            }
    //            $http(req).then(function (response) {

    //                //$scope.showDialog("Saved successfully!");
    //                // $scope.getJobDetails($scope.modifiedJob.JobId);

    //                $scope.resources = response.data.Table;
    //                $scope.assetHistory = response.data.Table1;

    //                if ($scope.resources) {
    //                    if ($scope.resources.length > 0) {
    //                        for (i = 0; i < $scope.resources.length; i++) {
    //                            $scope.resources[i].expiryDate = getdateFormat($scope.resources[i].expiryDate);

    //                        }
    //                    }
    //                }

    //                $scope.JobResources = null;
    //                $scope.jr = null;

    //            }, function (errres) {
    //                var errdata = errres.data;
    //                var errmssg = "";
    //                errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
    //                $scope.JobResources = null;
    //                $scope.jr = null;
    //                $scope.showDialog(errmssg);
    //            });
    //        }
    //    }

    //    $scope.Delresources = function (addres, selU) {
    //        selU.insupddelflag = 'D';
    //        //var fromdate = null;
    //        //var todate = null;
    //        //if ($scope.JobResources.fromDt) {
    //        //    fromdate = getdateFormat($scope.JobResources.fromDt);
    //        //}

    //        //if ($scope.JobResources.toDt) {
    //        //    todate = getdateFormat($scope.JobResources.toDt);
    //        //}


    //        //var nuser = (addres == 0) ? selU : { "Name": $scope.jr.Name, "AssetModel": $scope.amid.name, "AssetId": $scope.jr.ID, "CreatedById": $scope.UserId, "UpdatedById": $scope.UserId, "FromDate": fromdate, "ToDate": todate, "insupddelflag": "I" };

    //        //var idx = IsAExists(nuser.AssetId, $scope.resources);

    //        //if (idx == -1) {
    //        //    if (addres == 1)
    //        //        $scope.resources.push(nuser);
    //        //}

    //        //if (addres == 0) {
    //        //    $scope.resources.splice(idx, 1);
    //        //}
    //    }

    //    $scope.EditTPresources = function (u) {
    //        $scope.currtpRes = u;
    //        $scope.currtpRes.FromDate = (u.FromDate == null) ? null : getdateFormat(u.FromDate);
    //        $scope.currtpRes.ToDate = (u.ToDate == null) ? null : getdateFormat(u.ToDate);
    //    }
    //    $scope.AddTresources = function (addTres, selU) {

    //        var fromdate = null;
    //        var todate = null;
    //        if ($scope.tpRes && $scope.tpRes.fromDt) {
    //            fromdate = GetFormattedDate($scope.tpRes.fromDt);
    //        }

    //        if ($scope.tpRes && $scope.tpRes.toDt) {
    //            todate = GetFormattedDate($scope.tpRes.toDt);
    //        }

    //        var nuser = null;
    //        switch (addTres) {
    //            //insertion
    //            case 1:

    //                if ($scope.tpRes.Name == null) {
    //                    alert('Please enter Third party resource name.');
    //                    return;
    //                }
    //                if ($scope.tpRes.VName == null) {
    //                    alert('Please enter Third party resource name.');
    //                    return;
    //                }

    //                var idx = IsTExists($scope.tpRes, $scope.tresources);
    //                if (idx == -1) {
    //                    nuser = {
    //                        "Name": $scope.tpRes.Name
    //                        , "VName": $scope.tpRes.VName
    //                         , "JobId": $scope.currJob.ID
    //                        , "TPResourceId": $scope.tpRes.Id
    //                        , "CreatedById": ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id
    //                        , "UpdatedById": ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id
    //                        , "FromDate": fromdate
    //                        , "ToDate": todate
    //                        , "insupddelflag": "I"
    //                    };
    //                    $scope.currtpRes = nuser;
    //                }

    //                break;
    //                //updation
    //            case 2:

    //                if (selU.Name == null) {
    //                    alert('Please enter Third party resource name.');
    //                    return;
    //                }
    //                if (selU.VName == null) {
    //                    alert('Please enter Third party resource name.');
    //                    return;
    //                }

    //                selU.insupddelflag = 'U';
    //                var idx = IsTExists(selU, $scope.tresources);
    //                if (idx > -1) {
    //                    selU.CreatedById = ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id
    //                    selU.UpdatedById = ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id
    //                    selU.JobId = $scope.currJob.ID;
    //                    $scope.JobResources = selU;
    //                }

    //                break;
    //                //deletion
    //            case 0:
    //                var idx = IsTExists(selU, $scope.tresources);
    //                if (idx > -1) {
    //                    selU.CreatedById = ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id
    //                    selU.UpdatedById = ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id
    //                    selU.JobId = $scope.currJob.ID;
    //                    $scope.currtpRes = selU;
    //                    $scope.currtpRes.insupddelflag = "D";
    //                }
    //                break;
    //        }

    //        if ($scope.currtpRes != null) {
    //            var req = {
    //                method: 'POST',
    //                url: '/api/Jobs/SaveJobTPResource',
    //                data: $scope.currtpRes
    //            }
    //            $http(req).then(function (response) {

    //                $scope.tresources = response.data.Table;
    //                $scope.assetHistory = response.data.Table1;

    //                if ($scope.tresources) {
    //                    if ($scope.tresources.length > 0) {
    //                        for (i = 0; i < $scope.tresources.length; i++) {
    //                            $scope.tresources[i].expiryDate = getdateFormat($scope.tresources[i].expiryDate);

    //                        }
    //                    }
    //                }

    //                $scope.currtpRes = null;
    //                $scope.tpRes = null;

    //            }, function (errres) {
    //                var errdata = errres.data;
    //                var errmssg = "";
    //                errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
    //                $scope.currtpRes = null;
    //                $scope.tpRes = null;
    //                $scope.showDialog(errmssg);
    //            });
    //        }
    //    }

    //    function IsAExists(itemId, arr) {
    //        var idx = -1;
    //        for (i = 0; i < arr.length; i++) {
    //            if (arr[i].AssetId == itemId) {
    //                idx = i;
    //                break
    //            }
    //        }
    //        return idx;
    //    }
    //    function IsTExists(itemId, arr) {
    //        var idx = -1;
    //        for (i = 0; i < arr.length; i++) {
    //            if (arr[i].Name == itemId.Name && arr[i].VName == itemId.VName) {
    //                idx = i;
    //                break
    //            }
    //        }
    //        return idx;
    //    }

    //    function IsExists(itemId, arr) {
    //        var idx = -1;
    //        for (i = 0; i < arr.length; i++) {
    //            if (arr[i].UserId == itemId) {
    //                idx = i;
    //                break
    //            }
    //        }
    //        return idx;
    //    }

    //    $scope.AddNewJob = function () {
    //        $scope.Jobs = null;
    //        $scope.jobname = null;
    //    }

    //    $scope.addComments = function () { $scope.comments.push({ "Name": $scope.comment }); }
    //    $scope.addPreComments = function () { $scope.pre.push({ "Name": $scope.prec }); }
    //    $scope.addPostComments = function () { $scope.post.push({ "Name": $scope.postc }); }

    //    $scope.saveJobDetails = function () {
    //        var newJob = $scope.currJob;
    //        if (newJob == null) {
    //            alert('Please enter Job name.');
    //            return;
    //        }
    //        //job name
    //        if (newJob.Name == null) {
    //            alert('Please enter job name.');
    //            return;
    //        }
    //        //job#
    //        if (newJob.JobID == null) {
    //            alert('Please enter Job Id.');
    //            return;
    //        }
    //        //WellNo
    //        if (newJob.WellNo == null) {
    //            alert('Please enter Well#.');
    //            return;
    //        }
    //        //  CustomerID
    //        if ($scope.jc == null || $scope.jc.Id == null) {
    //            alert('Please select Customer.');
    //            return;
    //        }

    //        // LocationID
    //        if ($scope.jl == null || $scope.jl.id == null) {
    //            alert('Please select location.');
    //            return;
    //        }
    //        //CustPOC
    //        if (newJob.CustPOC == null) {
    //            alert('Please enter Customer POC.');
    //            return;
    //        }
    //        // EstStartDt
    //        if (newJob.EstStartDt == null) {
    //            alert('Please select estimated start date.');
    //            return;
    //        }
    //        //  EstEndDt
    //        if (newJob.EstEndDt == null) {
    //            alert('Please select estimated end date.');
    //            return;
    //        }
    //        //ProjDesc
    //        if (newJob.ProjDesc == null) {
    //            alert('Please enter project description.');
    //            return;
    //        }
    //        // StatusId
    //        if ($scope.js == null || $scope.js.Id == null) {
    //            alert('Please select status.');
    //            return;
    //        }



    //        var job = {

    //            Id: newJob.ID,
    //            Name: newJob.Name,
    //            JobID: newJob.JobID,
    //            WellNo: newJob.WellNo,
    //            AFE: newJob.AFE,
    //            Trucking: newJob.Trucking,
    //            Dock: newJob.Dock,
    //            CustPOC: newJob.CustPOC,
    //            LocationID: $scope.jl.id,
    //            CustomerID: $scope.jc.Id,
    //            Bid: newJob.BidID,
    //            StatusId: $scope.js.Id,
    //            JobType: newJob.JobType,
    //            POCPh: newJob.POCPh,
    //            RIG: newJob.RIG,
    //            OCSG: newJob.OCSG,
    //            ProjDesc: newJob.ProjDesc,
    //            EstStartDt: GetFormattedDate(newJob.EstStartDt),
    //            EstEndDt: GetFormattedDate(newJob.EstEndDt),
    //            ActualStartDt: GetFormattedDate(newJob.ActualStartDt),
    //            ActualEndDt: GetFormattedDate(newJob.ActualEndDt),
    //            changedById: $scope.userdetails.Id,
    //            insupddelflag: 'U'//,
    //            // JobUsers: $scope.jobusers,
    //            //  JobResouces: $scope.resources,
    //            //  JobTPResources: $scope.tresources,
    //            //  JobDocuments:$scope.jobdocs
    //        }

    //        var req = {
    //            method: 'POST',
    //            url: '/api/Jobs/SaveJobDetails',
    //            data: job
    //        }
    //        $http(req).then(function (response) {

    //            $scope.showDialog("Saved successfully!");
    //            $scope.getJobDetails(newJob.ID);
    //            $scope.currJob = null;

    //        }, function (errres) {
    //            var errdata = errres.data;
    //            var errmssg = "";
    //            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
    //            $scope.showDialog(errmssg);
    //        });
    //        $scope.currGroup = null;
    //    }

    //    $scope.showDialog = function (message) {

    //        var modalInstance = $uibModal.open({
    //            animation: $scope.animationsEnabled,
    //            templateUrl: 'myModalContent.html',
    //            controller: 'ModalInstanceCtrl',
    //            resolve: {
    //                mssg: function () {
    //                    return message;
    //                }
    //            }
    //        });
    //    }

    //    $scope.GetUsersForJob = function () {
    //        $http.get('/api/Jobs/GetUsersForJob?jobId=' + $scope.j.ID).then(function (res, data) {
    //            $scope.Users = res.data;
    //        });
    //    }

    //    $scope.GetAssetsModels = function () {
    //        $http.get('/api/AssetModel/GetAssetModels?locId=-1').then(function (res, data) {
    //            $scope.Models = res.data;
    //        });
    //    }

    //    $scope.GetAssets = function () {
    //        $http.get('/api/Jobs/GetEquipmentForJob?modelId=' + $scope.amid.id + '&locationId=' + $scope.currJob.LocationID + '&jobId=' + $scope.j.ID).then(function (res, data) {
    //            $scope.Assets = res.data;
    //        });
    //    }

    //    $scope.validateFile = function ($event) {
    //    }

    //    $scope.onFileSelect = function (files, $event) {
    //        $scope.modifiedJob = null;
    //        var found = false;
    //        //check if job already exists 
    //        for (cnt = 0; cnt < $scope.jobdocs.length; cnt++) {
    //            if ($scope.jobdocs[cnt].DocName == files[0].name) {
    //                found = true;
    //            }
    //        }

    //        if (found) {
    //            alert('Cannot add duplicte documents. Document with the same name already exists.');
    //            $event.stopPropagation();
    //            $event.preventDefault();
    //            return;
    //        }

    //        var ext = files[0].name.split('.').pop();
    //        fileReader.readAsDataUrl(files[0], $scope, (ext == 'csv') ? 1 : 4).then(function (result) {

    //            if (result.length > 2097152) {
    //                alert('Cannot upload file greater than 2 MB.');
    //                $event.stopPropagation();
    //                $event.preventDefault();
    //                return;
    //            }

    //            var doc =
    //                {
    //                    Id: ($scope.jobDoc == null) ? -1 : $scope.jobDoc.Id,
    //                    JobId: $scope.currJob.ID,
    //                    createdById: ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id,
    //                    UpdatedById: ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id,
    //                    FromDate: null,
    //                    ToDate: null,
    //                    //  docCatId: $scope.currobj.Id,
    //                    docTypeId: ($scope.jobDoc == null || $scope.jobDoc.docType == null) ? null : $scope.jobDoc.docType.Id,
    //                    DocType: ($scope.jobDoc == null || $scope.jobDoc.docType == null) ? null : $scope.jobDoc.docType.Name,//
    //                    DocName: files[0].name,
    //                    docContent: result,

    //                    ExpiryDate: ($scope.jobDoc == null || $scope.jobDoc.ExpiryDate == null) ? null : GetFormattedDate($scope.jobDoc.ExpiryDate),
    //                    DueDate: ($scope.jobDoc == null || $scope.jobDoc.DueDate == null) ? null : GetFormattedDate($scope.jobDoc.DueDate),

    //                    insupddelflag: 'I'
    //                }
    //            $scope.modifiedJob = doc;

    //        });
    //    };

    //    $scope.EditJobDoc = function (f) {

    //        for (cnt = 0; cnt < $scope.jobdocs.length; cnt++) {
    //            if ($scope.jobdocs[cnt].DocName == f.DocName) {
    //                $scope.assetDoc = $scope.jobdocs[cnt];
    //                $scope.assetDoc.ExpiryDate = getdateFormat(f.ExpiryDate);
    //                for (dcnt = 0; dcnt < $scope.docTypes.length; dcnt++) {
    //                    if ($scope.docTypes[dcnt].Id == f.DocTypeId) {
    //                        {
    //                            $scope.assetDoc.dt = $scope.docTypes[dcnt];
    //                        }
    //                    }
    //                }
    //                break;
    //            }
    //        }
    //    }

    //    $scope.cancelNewDoc = function () {
    //        $scope.jobDoc = null;
    //    }

    //    $scope.updateDoc = function () {
    //        if ($scope.assetDoc.dt != null) {
    //            $scope.assetDoc.docTypeId = $scope.assetDoc.dt.Id;
    //            $scope.assetDoc.DocType = $scope.assetDoc.dt.Name;
    //        }
    //        $scope.assetDoc.insupddelflag = ($scope.assetDoc.Id == -1) ? 'I' : 'U';
    //        $scope.modifiedJob = $scope.assetDoc;
    //        $scope.SaveJobDoc();
    //    }

    //    $scope.DeleteDoc = function (d) {

    //        if (d == -1) {
    //            $scope.assetDoc.slice(d);
    //        }
    //        else {
    //            d.insupddelflag = "D";
    //            $scope.modifiedJob = d;
    //            $scope.SaveJobDoc();
    //        }


    //    }
    //    $scope.updateDocType = function () {
    //        if ($scope.jobDoc != null) {
    //            $scope.jobDoc.docTypeId = $scope.jobDoc.docType.Id;
    //            $scope.jobDoc.DocType = $scope.jobDoc.docType.Name;

    //            $scope.modifiedJob.docTypeId = $scope.jobDoc.docType.Id;
    //            $scope.modifiedJob.DocType = $scope.jobDoc.docType.Name;
    //        }
    //    }
    //    $scope.updateDocExpDate = function () {

    //        if ($scope.jobDoc != null) {
    //            $scope.jobDoc.ExpiryDate = getdateFormat($scope.jobDoc.ExpiryDate);
    //            $scope.modifiedJob.ExpiryDate = getdateFormat($scope.jobDoc.ExpiryDate);
    //        }
    //    }

    //    $scope.GetFileContent = function (f) {
    //        // var data = $scope.currobj.files1[0];  
    //        if (f.DocContent != null) {
    //            openPDF(f.DocContent, f.DocName);
    //            return;
    //        }
    //        else {
    //            //get the file content from db
    //            $http.get('/api/Jobs/GetJobFileContent?docId=' + f.Id).then(function (res, data) {
    //                $scope.docDetails = res.data[0];
    //                openPDF($scope.docDetails.DocContent, res.data[0].DocName);
    //            });
    //        }
    //    }

    //    function openPDF(resData, fileName) {

    //        var blob = null;
    //        var ext = fileName.split('.').pop();
    //        if (ext == 'csv') {
    //            blob = new Blob([resData], { type: "text/csv" });
    //            saveAs(blob, fileName);
    //        }
    //        else {

    //            var ieEDGE = navigator.userAgent.match(/Edge/g);
    //            var ie = navigator.userAgent.match(/.NET/g); // IE 11+
    //            var oldIE = navigator.userAgent.match(/MSIE/g);

    //            if (ie || oldIE || ieEDGE) {
    //                blob = b64toBlob(resData, (ext == 'csv') ? 'text/csv' : 'application/pdf');
    //                // window.open(blob, '_blank');
    //                //  window.navigator.msSaveBlob(blob, fileName);
    //                saveAs(blob, fileName);
    //                //openReportWindow('test', resData, 1000, 700);
    //                //window.open(resData, '_blank');
    //                //  var a = document.createElement("a");
    //                //  document.body.appendChild(a);
    //                //  a.style = "display: none";
    //                //  a.href = resData;
    //                //  a.download = fileName;
    //                ////  a.onclick = "window.open(" + fileURL + ", 'mywin','left=200,top=20,width=1000,height=800,toolbar=1,resizable=0')";
    //                //  a.click(); 

    //            }
    //            else {

    //                openReportWindow(fileName, resData, 1000, 700);
    //                // newWindow =   window.open(resData, 'newwin', 'left=200,top=20,width=1000,height=700,toolbar=1,resizable=0');
    //                //   timerObj = window.setInterval("ResetTitle('"+fileName+"')", 10);
    //            }
    //        }
    //    }

    //    var winLookup;
    //    var showToolbar = false;
    //    function openReportWindow(m_title, m_url, m_width, m_height) {
    //        var strURL;
    //        var intLeft, intTop;

    //        strURL = m_url;

    //        // Check if we've got an open window.
    //        if ((winLookup) && (!winLookup.closed))
    //            winLookup.close();

    //        // Set up the window so that it's centered.
    //        intLeft = (screen.width) ? ((screen.width - m_width) / 2) : 0;
    //        intTop = 20;//(screen.height) ? ((screen.height - m_height) / 2) : 0;

    //        // Open the window.
    //        winLookup = window.open('', 'winLookup', 'scrollbars=no,resizable=yes,toolbar=' + (showToolbar ? 'yes' : 'no') + ',height=' + m_height + ',width=' + m_width + ',top=' + intTop + ',left=' + intLeft);
    //        checkPopup(m_url, m_title);

    //        // Set the window opener.
    //        if ((document.window != null) && (!winLookup.opener))
    //            winLookup.opener = document.window;

    //        // Set the focus.
    //        if (winLookup.focus)
    //            winLookup.focus();
    //    }

    //    function checkPopup(m_url, m_title) {
    //        if (winLookup.document) {
    //            //identify the file type and display accordingly
    //            var ext = m_title.split('.').pop();
    //            switch (ext) {
    //                case 'pdf':
    //                    winLookup.document.write('<html><head><title>' + m_title + '</title></head><body height="100%" width="100%"><embed type="application/pdf" src="' + m_url + '" height="100%" width="100%" /></body></html>');
    //                    break;
    //                default:
    //                    winLookup.document.write('<html><head><title>' + m_title + '</title></head><body height="100%" width="100%"><img src="' + m_url + '" height="100%" width="100%" /></body></html>');
    //                    break;
    //            }

    //        } else {
    //            // if not loaded yet
    //            setTimeout(checkPopup(m_url, m_title), 10); // check in another 10ms
    //        }
    //    }

    //    function b64toBlob(b64Data, contentType) {
    //        contentType = contentType || '';
    //        var sliceSize = 512;
    //        b64Data = b64Data.replace(/^[^,]+,/, '');
    //        b64Data = b64Data.replace(/\s/g, '');
    //        var byteCharacters = window.atob(b64Data);
    //        var byteArrays = [];

    //        for (var offset = 0; offset < byteCharacters.length; offset += sliceSize) {
    //            var slice = byteCharacters.slice(offset, offset + sliceSize);

    //            var byteNumbers = new Array(slice.length);
    //            for (var i = 0; i < slice.length; i++) {
    //                byteNumbers[i] = slice.charCodeAt(i);
    //            }

    //            var byteArray = new Uint8Array(byteNumbers);

    //            byteArrays.push(byteArray);
    //        }

    //        var blob = new Blob(byteArrays, { type: contentType });
    //        return blob;
    //    }

    //    function GetFormattedDate(date) {
    //        if (date == null) return '';
    //        var todayTime = new Date(date);
    //        var month = todayTime.getMonth() + 1;
    //        var day = todayTime.getDate();
    //        var year = todayTime.getFullYear();
    //        return new Date(month + "/" + day + "/" + year);
    //    }

    //    function getdateFormat(date) {
    //        var formateddate = date;

    //        if (date) {
    //            formateddate = $filter('date')(date, 'MM-dd-yyyy');
    //        }

    //        return formateddate;
    //    }

    //    $scope.GetDetailsEditHistory = function (hist) {
    //        $http.get('/api/Jobs/GetJobHistoryDetails?ehId=' + hist.Id).then(function (res, data) {
    //            $scope.detailedhist = res.data;
    //        });
    //    }

    //    /*save job documents */
    //    $scope.SaveJobDoc = function (jdoc) {

    //        if ($scope.modifiedJob == null) {

    //            alert('Select a job to modify.');
    //            return;
    //        }

    //        // $scope.modifiedJob.createdById = ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id;
    //        $scope.modifiedJob.UpdatedById = ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id;

    //        var req = {
    //            method: 'POST',
    //            url: '/api/Jobs/SaveJobDocs',
    //            data: $scope.modifiedJob
    //        }
    //        $http(req).then(function (response) {

    //            //$scope.showDialog("Saved successfully!");
    //            // $scope.getJobDetails($scope.modifiedJob.JobId);

    //            $scope.jobdocs = response.data.Table;
    //            $scope.assetHistory = response.data.Table1;

    //            if ($scope.jobdocs) {
    //                if ($scope.jobdocs.length > 0) {
    //                    for (i = 0; i < $scope.jobdocs.length; i++) {
    //                        $scope.jobdocs[i].expiryDate = getdateFormat($scope.jobdocs[i].expiryDate);

    //                    }
    //                }
    //            }

    //            $scope.modifiedJob = null;
    //            $scope.assetDoc = null;

    //        }, function (errres) {
    //            var errdata = errres.data;
    //            var errmssg = "";
    //            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
    //            $scope.modifiedJob = null;
    //            $scope.assetDoc = null;
    //            $scope.showDialog(errmssg);
    //        });
    //    }

    //});

    myapp1.controller('ModalInstanceCtrl', function ($scope, $uibModalInstance, mssg) {

        $scope.mssg = mssg;
        $scope.ok = function () {
            $uibModalInstance.close('test');
        };

        $scope.cancel = function () {
            $uibModalInstance.dismiss('cancel');
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
});

