var app = angular.module('myApp', ['ngStorage']);
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $filter) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;
    $scope.checkedArr = new Array();
    $scope.uncheckedArr = new Array();
    $scope.Blist = [];


    //$scope.Getblocklist = function () {

    //    //$http.get('/api/blocklistnew/Getblocklist').then(function (response, req) {
    //        $scope.blocklist = response.data;

    //    });
    //}

    $scope.GetBlockDetails = function () {

        if ($scope.selectedId == null) {
            $scope.blocklist = null;
            $scope.checkedArr = [];
            $scope.uncheckedArr = [];
            return;
        }
       

        $http.get('/api/Blocklist/GetBlockDetails?selectedId=' + $scope.selectedId).then(function (res, data) {
            
            $scope.blocklist = res.data;
            $scope.checkedArr = $filter('filter')($scope.Blist, { assigned: "1" });
            $scope.uncheckedArr = $filter('filter')($scope.Blist, { assigned: "0" });
          
        });
    }

    

   
    $scope.saveBTPOSList = function () {

        var BlockLt = [];

        for (var cnt = 0; cnt < $scope.checkedArr.length; cnt++) {

          //  if ($scope.checkedArr[cnt].assigned == 0) {
                var fr = {
                    Id: -1,
                    //FleetOwnerId: $scope.s.Id,
                    ItemTypeId: $scope.selectedId,
                    ItemId: $scope.checkedArr[cnt].ItemId,
                    Reason: $scope.checkedArr[cnt].Reason,
                    //From: $scope.checkedArr[cnt].FromDate,
                    //To: $scope.checkedArr[cnt].ToDate,
                    //Active: 1,
                    insupddelflag: 'I'
                }

                BlockLt.push(fr);
           // }
        }
        $http({
            url: '/api/Blocklist/saveBocklist',
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            data: BlockLt,

        }).success(function (data, status, headers, config) {
            //alert('Saved successfully');
            $scope.GetBlockDetails();
        }).error(function (ata, status, headers, config) {
            alert(ata);
        });
    };
    


    $scope.toggle = function (item) {
        var idx = $scope.checkedArr.indexOf(item);
        if (idx > -1) {
            $scope.checkedArr.splice(idx, 1);
        }
        else {
            $scope.checkedArr.push(item);
        }

        var idx = $scope.uncheckedArr.indexOf(item);
        if (idx > -1) {
            $scope.uncheckedArr.splice(idx, 1);
        }
        else {
            $scope.uncheckedArr.push(item);
        }
    };
    
    

    $scope.toggleAll = function () {
        if ($scope.checkedArr.length === $scope.Blist.length) {
            $scope.uncheckedArr = $scope.checkedArr.slice(0);
            $scope.checkedArr = [];

        } else if ($scope.checkedArr.length === 0 || $scope.Blist.length > 0) {
            $scope.checkedArr = $scope.Blist.slice(0);
            $scope.uncheckedArr = [];
        }
      
    };

    $scope.exists = function (item, list) {
        return list.indexOf(item) > -1;
    };
  
   
    $scope.isChecked = function () {
        return $scope.checkedArr.length === $scope.Blist.length;
    };

  
});


