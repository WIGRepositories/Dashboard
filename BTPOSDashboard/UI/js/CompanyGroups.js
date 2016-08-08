var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap', 'angularFileUpload', 'ngFileUpload'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal,$upload) {
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
        //if (!angular.element('EmailId').$valid)
        //{
        //    alert('invalid email id');
        //}
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
            Address: Group.Address,
            ContactNo1: Group.ContactNo1,
            ContactNo2: Group.ContactNo2,
            Fax:Group.Fax,
            EmailId:Group.EmailId,
            Title:Group.Title,
            Caption:Group.Caption,
            Country:Group.Country,
            ZipCode:Group.ZipCode,
            State: Group.State,
            Logo: Group.Logo,
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
            $scope.GetCompanys();

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
            State: Group.State,
            Logo:Group.Logo,
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
            backdrop:false,
            templateUrl: 'SavePopup.html',
          //  controller: 'ModalInstanceCtrl',            
            resolve: {
                mssg: function () {
                    return message;
                }
            }
        });
    }

    $scope.filterValue = function ($event) {
        if (isNaN(String.fromCharCode($event.keyCode))) {
            $event.preventDefault();
        }
    };

    //$scope.uploadFile = function () {
    //    var file = $scope.Logo;
    //    console.log('file is ' + JSON.stringify(file));
        
    //};

});

var filectrl = app.controller('UploadCtrl', function ($scope, $http, $timeout, $upload ) {
    $scope.upload = [];
    $scope.fileUploadObj = { testString1: "Test string 1", testString2: "Test string 2" };

    var UploadDataModel = { testString1: "Test string 1", testString2: "Test string 2" };

    $scope.upload = function (file) {
        Upload.upload({
            url: "http://localhost:1476/api/files/upload",
            data: { file: file, 'username': $scope.username }
        }).then(function (resp) {
            console.log('Success ' + resp.config.data.file.name + 'uploaded. Response: ' + resp.data);
        }, function (resp) {
            console.log('Error status: ' + resp.status);
        }, function (evt) {
            var progressPercentage = parseInt(100.0 * evt.loaded / evt.total);
            console.log('progress: ' + progressPercentage + '% ' + evt.config.data.file.name);
        });
    };

    $scope.onFileSelect = function ($files) {
        //$files: an array of files selected, each file has name, size, and type.
        for (var i = 0; i < $files.length; i++) {
            var $file = $files[i];
            (function (index) {
                $scope.upload[index] = $upload.upload({
                    url: "http://localhost:1476/api/files/upload", // webapi url
                    method: "POST",
                    contentType: 'application/json; charset=utf-8',
                   // data: UploadDataModel,
                    file: $file
                }).progress(function (evt) {
                    // get upload percentage
                    console.log('percent: ' + parseInt(100.0 * evt.loaded / evt.total));
                }).success(function (data, status, headers, config) {
                    // file is uploaded successfully
                    console.log(data);
                }).error(function (data, status, headers, config) {
                    // file failed to upload
                    console.log(data);
                });
            })(i);
        }
    }

    $scope.abortUpload = function (index) {
        $scope.upload[index].abort();
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
