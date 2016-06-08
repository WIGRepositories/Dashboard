var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname

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
       if (Fleet.group == null || Fleet.VehicleTypeId.group.Id == null) {
           alert('Please select a type group');
           return;
       }
      
                       
       
        var Fleet = {
            Id:Fleet.Id,
            VehicleRegNo: Fleet.VehicleRegNo,
            VehicleTypeId: Fleet.VehicleTypeId,
            VehicleLayout: Fleet.VehicleLayout,
            FleetOwnerId: Fleet.FleetOwnerId,
            CompanyId: Fleet.CompanyId,
            ServiceTypeId: Fleet.ServiceTypeId,
            Active: Fleet.Active,
           
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
       /* if (newVD == null) {
            alert('Please enter VehicleRegNo.');
            return;
        }

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
            VehicleTypeId: newVD.vt.Id,
            VehicleLayoutId: newVD.vl.Id,
            FleetOwnerId: newVD.fo.Id,
            CompanyId: $scope.cmp.Id,
            ServiceTypeId: newVD.st.Id,
            Active:1,

        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/Fleet/NewFleetDetails',
            //headers: {
            //    'Content-Type': undefined

            data: Fleet
        }

        $http(req).then(function (res) {
            alert('Sucessfully saved!');
        });
}
 
    $scope.setFleet = function (F) {
        $scope.currVD = F;
             $scope.currVD.VehicleTypeId = 9;
    }
});
   

   

