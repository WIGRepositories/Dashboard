// JavaScript source code
var myapp1 = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var mycrtl1 = myapp1.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;
    $scope.GetCategories = function () {
        $http.get('/api/subcategory/getcategory').then(function (response, data) {
            $scope.Categories = response.data;
           // $scope.getselectval();
        });
    }

    $scope.GetCategoriesList = function () {
        $http.get('/api/subcategory/getcategory').then(function (response, data) {
            $scope.Categories = response.data;
             $scope.getselectval();
        });
    }


    $scope.getselectval = function (seltype) {
        var grpid = (seltype) ? seltype.Id : -1;

        $http.get('/api/subcategory/getsubcategory?catid=' + grpid).then(function (res, data) {
            $scope.SubCategory = res.data;

        });
    }

    $scope.save = function (SubCategory) {

        if (SubCategory.CATEGORY == null) {
            alert('Please enter Category.');
            return;
        }
        if (SubCategory == null) {
            alert('Please enter values.');
            return;
        }

        if (SubCategory.Name == null) {
            alert('Please enter name.');
            return;
        }
        


        var currSubCategory = {

            Id: SubCategory.Id,
            Name: SubCategory.Name,
            Description: SubCategory.Description,
            Active:  SubCategory.Active,
            TypeGroupId: SubCategory.CategoryId

        };

        var req = {
            method: 'POST',
            url: '/api/subcategory/savesubcategory',
            data: currSubCategory
        }
        $http(req).then(function (response) {

           // $scope.showDialog("Saved successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };

    $scope.saveNewSubCategory = function (SubCategory) {

        if (SubCategory == null) {
            alert('Please enter values.');
            return;
        }

        if (SubCategory.Name == null) {
            alert('Please enter name.');
            return;
        }
        if (SubCategory.Category == null) {
            alert('Please enter Category.');
            return;
        }


        var NewSubCategory = {

            Id: -1,
            Name: SubCategory.Name,
            Description: SubCategory.Description,
            Active: 1,//SubCategory.Active,
            TypeGroupId: SubCategory.Category.Id
        };

        var req = {
            method: 'POST',
            url: '/api/subcategory/savesubcategory',
            data: NewSubCategory
        }

        $http(req).then(function (response) {
            //alert('saved successfully.');
        });


        $scope.currGroup = null;

    };

    $scope.setCompany = function (grp) {
        $scope.currGroup = grp;
    };

    $scope.clearGroup = function () {
        $scope.currGroup = null;
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
 

myapp1.controller('ModalInstanceCtrl', function ($scope, $uibModalInstance, mssg) {

    $scope.mssg = mssg;
    $scope.ok = function () {
        $uibModalInstance.close('test');
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});