var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {
    if ($localStorage.uname == null)
    {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;    

    $scope.GetCompanys = function () {
        $http.get('http://localhost:1476/api/GetCompanyGroups?userid=-1').then(function (response, data) {
            $scope.Companies = response.data;

        });
    }
    $scope.save = function (Group, flag) {

        if (Group == null) {
            alert('Please enter CompanyName.');
            return;
        }
        if (Group.Name == null || Group.Name == "") {
            alert('Please enter CompanyName.');
            return;
        }        
        if (Group.code == null || Group.code == "") {
            alert('Please enter code.');
            return;
        }
        var newCmp = {

            Id: Group.Id,
            Name: Group.Name,
            admin: Group.admin,
            code: Group.code,
            desc: Group.desc,            
            Address:Group.Address,
            ContactNo1: Group.ContactNo1,
            ContactNo2: Group.ContactNo2,
            Fax:Group.Fax,
            EmailId:Group.EmailId,
            Title:Group.Title,
            Caption:Group.Caption,
            Country:Group.Country,
            ZipCode:Group.ZipCode,
            State:Group.State,
            active: (Group.active==true)?1:0,
            insupdflag:flag 
        }
        

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/CompanyGroups/SaveCompanyGroups',
            data: newCmp
        }
        $http(req).then(function (response) {

            $scope.showDialog("Saved successfully!!");
            
            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });

     
        $scope.currGroup = null;
    };

    $scope.saveCmpChanges = function (Group, flag) {

        if (Group == null) {
            alert('Please enter CompanyName.');
            return;
        }
        if (Group.Name == null || Group.Name == "") {
            alert('Please enter CompanyName.');
            return;
        }
        if (Group.code == null || Group.code == "") {
            alert('Please enter code.');
            return;
        }
        var Group = {
            Id: Group.Id,
            Name: Group.Name,
            admin: Group.admin,
            code: Group.code,
            desc: Group.desc,
            Address:Group.Address,
            EmailId:Group.EmailId,
            ContactNo1:Group.ContactNo1,
            ContactNo2:Group.ContactNo2,
            Fax:Group.Fax,
            Title:Group.Title,
            Caption:Group.Caption,
            Country:Group.Country,
            ZipCode:Group.ZipCode,
            State:Group.State,
            active: (Group.active == true) ? 1 : 0,
            insupdflag: flag

        }


        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/CompanyGroups/SaveCompanyGroups',
            data: Group
        }
        $http(req).then(function (response) {

            $scope.showDialog("Saved successfully!!");
            
        }
        , function (errres) {
            var errdata = errres.data;
            var errmssg = "";            
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;            
            $scope.showDialog(errmssg);
           
        });
        $scope.GetCompanys(cmp);
        $scope.currGroup = null;
    };
      

    $scope.setCompany = function (cmp) {
        $scope.currGroup = cmp;
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

app.controller('ModalInstanceCtrl', function ($scope, $uibModalInstance, mssg) {

    $scope.mssg = mssg;
    $scope.ok = function () {
        $uibModalInstance.close('test');
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});
