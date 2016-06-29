// JavaScript source code
var myapp1 = angular.module('myApp', ['ngStorage'])
var mycrtl1 = myapp1.controller('myCtrl', function ($scope, $http,$localStorage) {
    //$scope.uname = $localStorage.uname;
    $scope.dashboardDS = $localStorage.dashboardDS;

    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;
    $http.get('http://localhost:1476/api/typegroups/gettypegroups').then(function (res, data) {
        $scope.TypeGroups = res.data;
    });

    $scope.save = function (TypeGroup) {
      
        if (TypeGroup == null) {
            alert('Please enter name.');
            return;
        }

        if (TypeGroup.Name == null) {
            alert('Please enter name.');
            return;
        }

        var SelTypeGroup = {
            Name: TypeGroup.Name,
            Description: TypeGroup.Description,
            Active: TypeGroup.Active,
            Update: TypeGroup.Update,
            Id: TypeGroup.Id,
            insupddelflag:'U'
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/typegroups/savetypegroups',
            //headers: {
            //    'Content-Type': undefined
            data: SelTypeGroup
        }
        $http(req).then(function (res) {
            alert('saved successfully');
       
        });

        $scope.currGroup = null;
    };


    $scope.saveNew = function (TypeGroup) {

        if (TypeGroup == null) {
            alert('Please enter name.');
            return;
        }

        if (TypeGroup.Name == null) {
            alert('Please enter name.');
            return;
        }

        var SelTypeGroup = {
            Name: TypeGroup.Name,
            Description: TypeGroup.Description,
            Active: TypeGroup.Active,
            Update: TypeGroup.Update,
            Id: -1,
            insupddelflag:'I'
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/typegroups/savetypegroups',
            //headers: {
            //    'Content-Type': undefined
            data: SelTypeGroup
        }
        $http(req).then(function (response) {

            $scope.showDialog("Saved successfully!");

        }
, function (errres) {
    var errdata = errres.data;
    var errmssg = "";
    errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
    $scope.showDialog(errmssg);

});

        $scope.currGroup = null;
    };


    $scope.setTypeGroup = function (grp) {
    $scope.currGroup = grp;
};

$scope.clearGroup = function () {
    $scope.currGroup = null;
};


});
