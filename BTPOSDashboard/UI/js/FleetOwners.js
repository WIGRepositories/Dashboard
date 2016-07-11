var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;   
    $scope.dashboardDS = $localStorage.dashboardDS;
    
   // $scope.EmpNo = $localStorage.eno;
    $scope.GetFleetOwner = function () {

        $http.get('http://localhost:1476/api/FleetOwner/getFleetOwner').then(function (res, data) {
            $scope.FleetOwner = res.data;

        });
    }

    $scope.setUsers = function (usr) {
        $scope.User1 = usr;
    };

    $scope.clearUsers = function () {
        $scope.User1 = null;
    }

    

    $scope.saveCmpChanges = function (FleetOwner) {

       
        var FleetOwner = {
            Id: FleetOwner.Id,
            FirstName: FleetOwner.FirstName,
            LastName: FleetOwner.LastName,
            MiddleName: FleetOwner.MiddleName,
           EmpNo: FleetOwner.EmpNo,
            Email: FleetOwner.Email,
            MobileNo: FleetOwner.MobileNo,
            Active: FleetOwner.Active,
            UserName: FleetOwner.UserName,
            Password: FleetOwner.Password,
            RePassword: FleetOwner.Password,
            insupdflag: 'U'


        }

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/users/saveusers',
            data:  FleetOwner
        }
        //        $http(req).then(function (response) {

        //            $scope.showDialog("Saved successfully!");


        //        })
        //    }
        //}
        //});

        $http(req).then(function (response) {

           

        })
     , function (errres) {
         var errdata = errres.data;
         var errmssg = "";
         errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
         $scope.showDialog(errmssg);


         $scope.GetFleetOwner();
         $scope.User1 = null;
     };


        $scope.setCompany = function (grp) {
            $scope.User1 = grp;
        };
    }
    //$scope.getEmpNo = function () {
      //  if( eno== null)
        //{
          //  alert("enter EmpNo");
            //return;
        //}

       // else
        //{
          //  $http.get('http://localhost:1476/api/FleetOwner/getFleetOwner?EmpNo=' + $scope.EmpNo).then(function (res, data) {
            //    $scope.FleetOwner = res.data;
            //})

            //}
    //}
});




      

    

   