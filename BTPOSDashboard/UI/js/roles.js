// JavaScript source code
var myapp1 = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var mycrtl1 = myapp1.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;
    $scope.userCmpId = $scope.userdetails[0].CompanyId;
    $scope.dashboardDS = $localStorage.dashboardDS;
    $scope.checkedArr = new Array();
    $scope.uncheckedArr = new Array();
    $scope.cmproles = [];
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

            if ($scope.userCmpId != 1) {
                //loop throug the companies and identify the correct one
                for (i = 0; i < res.data.length; i++) {
                    if (res.data[i].Id == $scope.userCmpId) {
                        $scope.s = res.data[i];
                        document.getElementById('test').disabled = true;
                        break
                    }
                }
            }
            else {
                document.getElementById('test').disabled = false;
            }
            $scope.getRolesForCompany($scope.s);
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


    //$scope.saveRoles = function () {

    //    //from the checked and unchecked array get the actuallly records to be saved
    //    //from checked array take the records which have assigned = 0 as there are new assignements
    //    //from unchecked array take assgined = 1 as these need to be removed


    //    var cmproles = [];

    //    for (var cnt = 0; cnt < $scope.checkedArr.length; cnt++) {

    //        if ($scope.checkedArr[cnt].assigned == 0) {
    //            var fr = {
    //                Id: -1,
    //                rolename: $scope.s.Id,
    //                description: $scope.cmp.Id,
    //                RouteId: $scope.checkedArr[cnt].RouteId,
    //                From: $scope.checkedArr[cnt].FromDate,
    //                To: $scope.checkedArr[cnt].ToDate,
    //                Active: 1,
    //                insupddelflag: 'I'
    //            }

    //            FleetOwnerRoutes.push(fr);
    //        }
    //    }

    //    for (var cnt = 0; cnt < $scope.uncheckedArr.length; cnt++) {

    //        if ($scope.uncheckedArr[cnt].assigned == 1) {
    //            var fr = {
    //                Id: -1,
    //                FleetOwnerId: $scope.s.Id,
    //                CompanyId: $scope.cmp.Id,
    //                RouteId: $scope.uncheckedArr[cnt].RouteId,
    //                From: $scope.uncheckedArr[cnt].FromDate,
    //                To: $scope.uncheckedArr[cnt].ToDate,
    //                Active: 1,
    //                insupddelflag: 'D'
    //            }

    //            FleetOwnerRoutes.push(fr);
    //        }
    //    }

    //    $http({
    //        url: 'http://localhost:1476/api/FleetOwnerRoute/saveFleetOwnerRoute',
    //        method: 'POST',
    //        headers: { 'Content-Type': 'application/json' },
    //        data: FleetOwnerRoutes,

    //    }).success(function (data, status, headers, config) {
    //        alert('Fleet owner routes successfully');
    //        $scope.getFleetOwnerRoute();
    //    }).error(function (ata, status, headers, config) {
    //        alert(ata);
    //    });
    //};
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
        if ($scope.checkedArr.length === $scope.cmproles.length) {
            $scope.uncheckedArr = $scope.checkedArr.slice(0);
            $scope.checkedArr = [];

        } else if ($scope.checkedArr.length === 0 || $scope.cmproles.length > 0) {
            $scope.checkedArr = $scope.cmproles.slice(0);
            $scope.uncheckedArr = [];
        }

    };

    $scope.exists = function (item, list) {
        return list.indexOf(item) > -1;
    };


    $scope.isChecked = function () {
        return $scope.checkedArr.length === $scope.cmproles.length;
    };


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
