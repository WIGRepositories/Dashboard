var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {
    //$scope.uname = $localStorage.uname
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;
   // $scope.EmpNo = $localStorage.eno;
    $scope.GetFleetOwner = function () {

        $http.get('http://localhost:1476/api/FleetOwner/getFleetOwner?EmpNo=').then(function (res, data) {
            $scope.FleetOwner = res.data;
        });
    }

    $scope.setUsers = function (usr) {
        $scope.User1 = usr;
    };

    $scope.clearUsers = function () {
        $scope.User1 = null;
    }

    

    $scope.saveCmpChanges = function (Fleet, flag) {

        // if( eno== null)
        //{
        //  alert("enter EmpNo");
        //return;
        //}
        //if (Fleet.FirstName == null || Group.FirstName == "") {
        //  alert('Please enter CompanyName.');
        //  return;
        //}

        var Fleet = {
            Id: Fleet.Id,
            FirstName: Fleet.FirstName,
            LastName: Fleet.LastName,
            MiddleName: Fleet.MiddleName,
            EmployeeNo: Fleet.EmpNo,
            Email: Fleet.Email,
            MobileNo: Fleet.MobileNo,
            Active: Fleet.Active,
            UserName: Fleet.UserName,
            Password: Fleet.Password,
            RePassword: Fleet.Password,
            insupdflag: flag


        }

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/users/saveusers',
            data: Fleet
        }
        //        $http(req).then(function (response) {

        //            $scope.showDialog("Saved successfully!");


        //        })
        //    }
        //}
        //});

        $http(req).then(function (response) {

            $scope.showDialog("Saved successfully!");

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




      

    

   