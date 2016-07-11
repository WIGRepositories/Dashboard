// JavaScript source code
var myapp1 = angular.module('myApp', ['ngStorage','ui.bootstrap'])
var mycrtl1 = myapp1.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;
$scope.GetLicenseCat = function () {
    $http.get('http://localhost:1476/api/Types/TypesByGroupId?groupid=3').then(function (res, data) {
        $scope.LicenseCat = res.data;            
    });
}

$scope.getLicenseTypes = function (selCat) {

    if (selCat == null)
    {
        $scope.LicenseTypes = null;
        return;
    }

    $http.get('http://localhost:1476/api/License/GetLicenseTypes?catid=' + selCat.Id).then(function (res, data) {
        $scope.LicenseTypes = res.data;
    });
}

$scope.GetLicenseCategories = function () {

    $http.get('http://localhost:1476/api/subcategory/getsubcategory?catid=' + 6).then(function (res, data) {
        $scope.SubCategories = res.data;
    });
}
    
$scope.saveLicenseType = function (licenseType, flag) {

    if (licenseType == null) {
        alert('Please enter values.');
        return;
    }

    if (licenseType.LicenseType == null) {
        alert('Please enter license type.');
        return;
    }       
    if ($scope.s == null) {
        alert('Please select category.');
        return;
    }


    var currLicenseType = {

        Id: (flag == 'I')?'-1':licenseType.Id,
        LicenseType: licenseType.LicenseType,
        Desc: licenseType.Description,
        LicenseCategoryId: $scope.s.Id,
        Active: 1// licenseType.Active
    };

    var req = {
        method: 'POST',
        url: 'http://localhost:1476/api/License/SaveLicenseType',
        data: currLicenseType
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


    $scope.currLicenseType = null;



$scope.getselectval = function (seltype) {
    var grpid = (seltype) ? seltype.Id : -1;

    $http.get('http://localhost:1476/api/license/getlicense?Subcatid=' + grpid).then(function (res, data) {
        $scope.License = res.data;

    });
}

$scope.save = function (License) {

    if (License == null) {
        alert('Please enter values.');
        return;
    }

    if (License.FeatureName == null) {
        alert('Please enter FeatureName.');
        return;
    }
    if (License.FeatureValue == null) {
        alert('Please enter FeatureValue.');
        return;
    }


    var currLicense = {

        Id: License.Id,
        LicenseTypeId: License.LicenseTypeId,
        FeatureName: License.FeatureName,
        FeatureValue: License.FeatureValue,
        FeatureType: License.FeatureType,
        Description: License.Description,
        effectiveFrom: License.effectiveFrom,
        effectiveTill: License.effectiveTill,
        Label: License.Label,
        labelclass: License.labelclass,
           
    };

    var req = {
        method: 'POST',
        url: 'http://localhost:1476/api/license/savelicense',
        data: currLicense
    }
    $http(req).then(function (response) { });


    $scope.currGroup = null;

};

    

$scope.saveNewLicense = function (License) {

    if (License == null) {
        alert('Please enter values.');
        return;
    }

    if (License.FeatureName == null) {
        alert('Please enter Featurename.');
        return;
    }
    if (License.FeatureValue == null) {
        alert('Please enter Value.');
        return;
    }


    var NewLicense = {

        Id: -1,
        LicenseTypeId: License.LicenseTypeId,
        FeatureName: License.FeatureName,
        FeatureValue: License.FeatureValue,
        FeatureType: License.FeatureType,
        Description: License.Description,
        effectiveFrom: License.effectiveFrom,
        effectiveTill: License.effectiveTill,
        Label: License.Label,
        labelclass: License.labelclass,
    };

    var req = {
        method: 'POST',
        url: 'http://localhost:1476/api/subcategory/savesubcategory',
        data: NewLicense
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

$scope.setCurrLicenseType = function (lt) {
    $scope.currLicenseType = lt;
};

$scope.clearCurrLicenseType = function () {
    $scope.currLicenseType = null;
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


