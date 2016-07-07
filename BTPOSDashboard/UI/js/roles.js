// JavaScript source code
var myapp1 = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var mycrtl1 = myapp1.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;
    $scope.dashboardDS = $localStorage.dashboardDS;
    $scope.GetRoles = function()
    {
        $http.get('http://localhost:1476/api/Roles/GetRoles?allroles=-1').then(function (response, data) {
            $scope.roles = response.data;            
        });
    }    

    $scope.saveNewRole = function (selectedRole) {

        if (selectedRole == null) {
            alert('Please enter role name.');
            return;
        }
        if (selectedRole.Name == null) {
            alert('Please enter role name.');
            return;
        }


        var selRole = {
            Id: -1,
            Name: selectedRole.Name,
            Description: selectedRole.Description,
            Active: 1,//selectedRole.Active,
            IsPublic:1
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/roles/saveroles',
            data: selRole
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
        $scope.currRole = null;

    };
    
    $scope.saveRole = function (currRole) {
        if (currRole == null) {
            alert('Please enter role name.');
            return;
        }
        if (currRole.Name == null) {
            alert('Please enter role name.');
            return;
        }


        var selRole = {

            Id: currRole.Id,
            Name: currRole.Name,
            Description: currRole.Description,
            Active: (currRole.Active == true) ? "1" : "0",
            IsPublic: (currRole.IsPublic == true) ? "1" : "0"
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/roles/saveroles',
            data: selRole
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
        $scope.currGroup = null;
    };

    $scope.setCurrRole = function (grp) {
        $scope.currRole = grp;
    };

    $scope.clearCurrRole = function () {
        $scope.currRole = null;
    };
    
    $scope.GetCompanies = function () {

        $http.get('http://localhost:1476/api/GetCompanyGroups?userid=-1').then(function (res, data) {
            $scope.Companies = res.data;
        });

    }


    $scope.getRolesForCompany = function (seltype) {
        if (seltype == null) {
            $scope.cmproles = null;
            return;
        }
        var cmpId = (seltype) ? seltype.Id : -1;        

        $http.get('http://localhost:1476/api/Roles/GetCompanyRoles?companyId=' + cmpId).then(function (res, data) {
            $scope.cmproles = res.data;
        });
    }

    $scope.GetRolesToAssign = function (seltype) {
        if (seltype == null) {
            $scope.roles = null;
            return;
        }
        var cmpId = (seltype.Id == 1) ? 0 : 1;

        $http.get('http://localhost:1476/api/Roles/GetRoles?allroles=' + cmpId).then(function (response, data) {
            $scope.roles = response.data;
        });
    }

    $scope.AssignRole = function () {
        if ($scope.r == null) {
            alert('Please select role name.');
            return;
        }
        if ($scope.r.Id == null) {
            alert('Please select role name.');
            return;
        }

        if ($scope.s == null) {
            alert('Please select company.');
            return;
        }
        if ($scope.s.Id == null) {
            alert('Please select company.');
            return;
        }

        var cmprole = {

            RoleId: $scope.r.Id,
            CompanyId: $scope.s.Id,
            Active: 1,
            insdelflag: 0
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/AssignDelRoles',
            data: cmprole
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
        $scope.currGroup = null;
    };

    $scope.testdel = function (role)
    {       
        var cmprole = {

            RoleId: role.RoleId,
            CompanyId: role.CompanyId,
            Active: 1,
            insdelflag: 1
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/AssignDelRoles',
            data: cmprole
        }
        $http(req).then(function (response) {
            alert('Removed successfully.');
            
            $http.get('http://localhost:1476/api/Roles/GetCompanyRoles?companyId=' + role.CompanyId).then(function (res, data) {
                $scope.cmproles = res.data;
            });

        });
        $scope.currRole = null;
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
   

myapp1.controller('ModalInstanceCtrl', function ($scope, $uibModalInstance, mssg) {

    $scope.mssg = mssg;
    $scope.ok = function () {
        $uibModalInstance.close('test');
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});
