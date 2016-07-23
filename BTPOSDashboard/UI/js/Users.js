
// JavaScript source code
var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;
    $scope.UserCmpid = $scope.userdetails[0].CompanyId;
    $scope.UserCmp = $scope.userdetails[0].companyName;

    $scope.dashboardDS = $localStorage.dashboardDS;
    $scope.checkedArr = new Array();
    $scope.uncheckedArr = new Array();
    $scope.userRoles = [];

    /* user details functions */
    $scope.GetCompanies = function () {    
        $http.get('http://localhost:1476/api/GetCompanyGroups?userid=-1').then(function (response, data) {
            $scope.Companies = response.data;
        });
        if ($scope.Roleid != 1) { $scope.cmpId = $scope.UserCmpid;}
    }

    $scope.GetUsersForCmp = function () {

        if ($scope.cmp == null) {
            $scope.User = null;
            $scope.MgrUsers = null;
            $scope.cmproles = null;
            return;
        }

        $http.get('http://localhost:1476/api/Users/GetUsers?cmpId=' + $scope.cmp.Id).then(function (res, data) {
            $scope.User = res.data;
            $scope.MgrUsers = res.data;
        });

        $http.get('http://localhost:1476/api/Roles/GetCompanyRoles?companyId=' + $scope.cmp.Id).then(function (res, data) {
            $scope.cmproles = res.data;
        });
    }

    $scope.save = function (User, flag, role) {
        if (User == null) {
            alert('Please enter Email.');
            return;
        }

        if (User.FirstName == null) {
            alert('Please enter first name.');
            return;
        }

        if (User.LastName == null) {
            alert('Please enter last name.');
            return;
        }

        if (User.Email == null) {
            alert('Please enter Email.');
            return;
        }

        if (User.EmpNo == null) {
            alert('Please enter FleetOwnerCode.');
            return;
        }

        if (User.Password != $scope.reenteredPwd) {
            alert('The passwords do not match.');
            return;
        }

        if ($scope.cmp == null)
        {
            alert('Please select a company.');
            return;
        }

        var User = {
            Id: User.Id,
            FirstName: User.FirstName,
            LastName: User.LastName,
            MiddleName: User.MiddleName,
            EmpNo: User.EmpNo,
            Email: User.Email,
            AdressId: User.AdressId,
            MobileNo: User.MobileNo,
            RoleId: (role == -1) ? $scope.r.RoleId : 6,
            companyId: $scope.cmp.Id,
            Active: 1,
            UserName: User.UserName,
            Password: User.Password,
            mgrId: ($scope.mgr == null )? null: $scope.mgr.Id,
            insupdflag: flag
        }

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/users/saveusers',
            data: User
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

    $scope.User1 = null;


    $scope.setUsers = function (usr) {
        $scope.User1 = usr;
    }

    $scope.clearUsers = function () {
        $scope.User1 = null;
    }

    /*end of user details functions */

    $scope.getUserRolesForCompany = function (cmp) {

        if (cmp == null) {
            $scope.userRoles = null;
            return;
        }

        $http.get('http://localhost:1476/api/Users/GetUserRoles?cmpId=' + $scope.cmp.Id).then(function (res, data) {
            $scope.userRoles = res.data;
        });
    }

    $scope.GetUsersinitData = function () {
        //get companies list   
        $http.get('http://localhost:1476/api/GetCompanyGroups?userid=-1').then(function (response, data) {
            $scope.Companies = response.data;
        });
    }

    $scope.getRolesForCompany = function (seltype) {
        if (seltype == null) {
            $scope.cmproles = null;
            $scope.MgrUsers = null;
            return;
        }
        var cmpId = (seltype) ? seltype.Id : -1;

        $http.get('http://localhost:1476/api/Roles/GetCompanyRoles?companyId=' + cmpId).then(function (res, data) {
            $scope.cmproles = res.data;
        });

        $http.get('http://localhost:1476/api/Users/GetUsers?cmpId=' + cmpId).then(function (res, data) {
            $scope.MgrUsers = res.data;
        });
        //get users for the company or all users based on company
    }

    $scope.getUsersnRoles = function () {
        if ($scope.s == null) {
            $scope.cmproles1 = null;
            $scope.cmpUsers1 = null;
            return;
        }
        var cmpId = ($scope.s == null) ? -1 : $scope.s.Id;

        $http.get('http://localhost:1476/api/Roles/GetCompanyRoles?companyId=' + cmpId).then(function (res, data) {
            $scope.cmproles1 = res.data;
        });

        $http.get('http://localhost:1476/api/Users/GetUsers?cmpId=' + cmpId).then(function (res, data) {
            $scope.cmpUsers1 = res.data;
        });
    }
    $scope.saveUserRoles = function (flag) {

        if ($scope.s.Id == null) {
            alert('Please select company.');
            return;
        }

        if ($scope.ur.RoleId == null) {
            alert('Please select role.');
            return;
        }
        if ($scope.uu.Id == null) {
            alert('Please select user.');
            return;
        }
        var userrole = {
            Id: -1,
            UserId: $scope.uu.Id,
            CompanyId: $scope.s.Id,
            RoleId: $scope.ur.RoleId,
            insupdflag:'I'
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/Users/SaveUserRoles',
            //headers: {
            //    'Content-Type': undefined
            data: userrole
        }

        $http(req).then(function (res) {
            alert('Saved successfully');
            $scope.s = null;
            $scope.ur = null;
            $scope.uu = null;
        });

    }
   
    $scope.setUserRoles = function (ur) {
        $scope.UserRoles = ur;
    }

    $scope.clearUsers = function () {
        $scope.UserRoles = null;
    }

    $scope.testdel = function (ur,flag) {
        var userrole = {

            RoleId: ur.RoleId,
            UserId: ur.Id,
            CompanyId: ur.Id,
            Active: 1,
            insupdflag: 'D'
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/Users/GetUsers?cmpId=-1',
            data: userrole
        }
        $http(req).then(function (response) {
            alert('Removed successfully.');

            $http.get('http://localhost:1476/api/Users/GetUsers?cmpId=' + cmpId).then(function (res, data) {
                $scope.userRoles = res.data;
            });

        });
        $scope.currRole = null;
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
        if ($scope.checkedArr.length === $scope.userRoles.length) {
            $scope.uncheckedArr = $scope.checkedArr.slice(0);
            $scope.checkedArr = [];

        } else if ($scope.checkedArr.length === 0 || $scope.userRoles.length > 0) {
            $scope.checkedArr = $scope.userRoles.slice(0);
            $scope.uncheckedArr = [];
        }

    };

    $scope.exists = function (item, list) {
        return list.indexOf(item) > -1;
    };


    $scope.isChecked = function () {
        return $scope.checkedArr.length === $scope.userRoles.length;
    };



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

        

