
// JavaScript source code
// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;
 
    $http.get('http://localhost:1476/api/objects/getobjects').then(function (res, data) {
        $scope.NewObjects = res.data;
    });
    $scope.save = function (NewObject,flag) {
        
        if (NewObject == null)
        {
            alert('please enter Name');
            return;
        }
        if (NewObject.Name == null)
        {
            alert('Please Enter Nmae');
            return;
        }
       
        if (NewObject.Path == null)
        {
            alert('Please Enter Path');
            return;
        }
   
        var SelNewObjects = {
            Id:1,
            Name: NewObject.Name,
            Description: NewObject.Description,
            Path: NewObject.Path,
            Access: NewObject.Access,
            insupdflag: 'I',
            Active:1,



        }

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/objects/saveObjects',
            data: SelNewObjects
        }
        $http(req).then(function (response) {

            $scope.showDialog("Saved successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currRole = null;
    };



    $scope.saveNewObjects = function (NewObject) {

        if (NewObject == null) {
            alert('Please enter name.');
            return;
        }

        if (NewObject.Name == null) {
            alert('Please enter name.');
            return;
        }




        var SelNewObjects = {


            Id: -1,
            Name: NewObject.Name,
            Description: NewObject.Description,
            Path: NewObject.Path,

            Active: 1,
            insupdflag: 'U'
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/Objects/saveObjects',
            data: SelNewObjects
        }

        $http(req).then(function (response) {

            $scope.showDialog("Saved successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currRole = null;
    };

    $scope.setCurrRole = function (grp) {
        $scope.currRole = grp;
    };

    $scope.clearCurrRole = function () {
        $scope.currRole = null;

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

app.controller('ModalInstanceCtrl', function ($scope, $uibModalInstance, mssg) {

    $scope.mssg = mssg;
    $scope.ok = function () {
        $uibModalInstance.close('test');
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});





