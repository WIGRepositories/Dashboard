
// JavaScript source code
// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])



app.directive('onFinishRender', function ($timeout) {

    return {
        restrict: 'A',
        link: function (scope, element, attr) {
            if (scope.$last === true) {
                $timeout(function () {
                    scope.$emit('ngRepeatFinished');
                });
            }
        }
    }
});


var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.isSuperUser = ($scope.Roleid == 1) ? 1 : 0;

    $scope.dashboardDS = $localStorage.dashboardDS;
 
    $http.get('/api/objects/getObjects').then(function (res, data) {
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
            alert('Please Enter Name');
            return;
        }
       
        if (NewObject.ParentId == null)
        {
            alert('Please Enter ParentId');
            return;
        }

        

        if (NewObject.RootObjectId == null) {
            alert('Please Enter RootObjectId');
            return;
        }
   
        var SelNewObjects = {
            Name: NewObject.Name,
            Description: NewObject.Description,
            ParentId: NewObject.ParentId,
            
            RootObjectId:NewObject.RootObjectId,
            Access: NewObject.Access,
            insupdflag: 'I',
            Active:1,



        }

        var req = {
            method: 'POST',
            url: '/api/objects/saveObjects',
            data: SelNewObjects
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
        $scope.currRole = null;
    };



    $scope.newChildObject = function (NewObject) {

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
            ParentId: $scope.ParentId,

            Active: 1,
            insupdflag: 'U'
        };

        var req = {
            method: 'POST',
            url: '/api/Objects/saveObjects',
            data: SelNewObjects
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
    $scope.$on('ngRepeatFinished', function (ngRepeatFinishedEvent) {
        //you also get the actual event object
        //do stuff, execute functions -- whatever...
        //alert("ng-repeat finished");
        $("#example-advanced").treetable({ initialState: 'expanded', expandable: true }, true);
        $("#example-advanced tbody tr:first").toggleClass("selected");


    });

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





