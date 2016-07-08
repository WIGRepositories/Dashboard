var app = angular.module('myApp', ['ngStorage','ui.bootstrap'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {
   
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;

   

    $scope.GetFleetDetails= function () {

         if ($scope.cmp == null)
        {
            $scope.cmpdata = null;
            return;
        }

        if ($scope.s == null)
        {
          $scope.Fleet = null;
            return;
        }

        $http.get('http://localhost:1476/api/Fleet/getFleetList?cmpId='+ $scope.cmp.Id+ '&fleetOwnerId=' + $scope.s.Id).then(function(res, data) {
            $scope.Fleet = res.data.Table;
      });
    }
   
    $scope.GetCompanies = function ()
    {

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
        $http(req).then(function (res)
        {
            //$scope.initdata = res.data;
            $scope.companies = res.data;
        });

    }

    $scope.GetFleetOwners = function ()
    {
        if ($scope.cmp == null)
        {
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
        $http(req).then(function (res)
        {
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

   /* $scope.GetFleetDetails = function () {

        $http.get('http://localhost:1476/api/Fleet/getFleetList?cmpId=' + $scope.cmp.Id + '&fleetOwnerId=' + $scope.s.Id).then(function (res, data) {
            $scope.Fleet = res.data.Table;
        });
    }*/
   
    $scope.save = function (Fleet) {
        if (Fleet == null) {
            alert('Please enter VehicleRegNo.');
            return;
        }

       if(Fleet.VehicleRegNo == null) {
            alert('Please enter VehicleRegNo.');
            return;
       }
       //if (Fleet.group == null || Fleet.VehicleTypeId.group.Id == null) {
       //    alert('Please select a type group');
       //    return;
       //}
      
                       
        
        var Fleet = {
            Id:Fleet.Id,
            VehicleRegNo: Fleet.VehicleRegNo,
            VehicleTypeId: (Fleet.vt != null) ? Fleet.vt.Id : Fleet.VehicleTypeId,
            VehicleLayoutId: (Fleet.vl != null) ? Fleet.vl.Id : Fleet.VehicleLayoutId,
            FleetOwnerId: $scope.s.Id,
            CompanyId: $scope.cmp.Id,
            ServiceTypeId: (Fleet.st != null) ? Fleet.st.Id : Fleet.ServiceTypeId,
            EngineNo: Fleet.EngineNo,
            FuelUsed: Fleet.FuelUsed,       
            MonthAndYrOfMfr: Fleet.MonthAndYrOfMfr,
            ChasisNo: Fleet.ChasisNo,
            SeatingCapacity: Fleet.SeatingCapacity,
            DateOfRegistration: Fleet.DateOfRegistration
        };
     
        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/Fleet/NewFleetDetails',
            //headers: {
            //    'Content-Type': undefined

            data: Fleet


        }
        $http(req).then(function (res) { });


    }
    
    $scope.savenewfleetdetails = function (initdata) {
        var newVD = initdata.newfleet;
        if (newVD == null) {
            alert('Please enter VehicleRegNo.');
            return;
        }
        /* 
        if (newVD.VehicleRegNo == null) {
            alert('Please enter VehicleRegNo.');
            return;
        }
        if (Fleet.group == null || Fleet.VehicleTypeId.group.Id == null) {
            alert('Please select a type group');
            return;
        }
        */


        var Fleet = {
            Id: -1,
            VehicleRegNo: newVD.VehicleRegNo,
            VehicleTypeId: (newVD.vt != null) ? newVD.vt.Id : newVD.VehicleTypeId,
            VehicleLayoutId: (newVD.vl != null) ? newVD.vl.Id : newVD.VehicleLayoutId,
            FleetOwnerId: newVD.fo.Id,
            CompanyId: $scope.cmp.Id,
            ServiceTypeId: (newVD.st != null) ? newVD.st.Id : newVD.ServiceTypeId,
            EngineNo: newVD.EngineNo,
            FuelUsed: newVD.FuelUsed,
            MonthAndYrOfMfr: newVD.MonthAndYrOfMfr,
            ChasisNo: newVD.ChasisNo,
            SeatingCapacity: newVD.SeatingCapacity,
            DateOfRegistration: newVD.DateOfRegistration,
            Active: 1,

        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/Fleet/NewFleetDetails',
            //headers: {
            //    'Content-Type': undefined

            data: Fleet
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

        $scope.setFleet = function (F) {
            $scope.currVD = F;
        }

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
    

app.controller('ModalInstanceCtrl', function ($scope, $uibModalInstance, mssg) {

    $scope.mssg = mssg;
    $scope.ok = function () {
        $uibModalInstance.close('test');
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});

   

   

