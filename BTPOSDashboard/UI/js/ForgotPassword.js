var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage,$uibModal) {

    $scope.RetrivePassword = function () {

        if ($scope.email == null) {
            $scope.showDialog("Please enter registered email-id.");
            return
        }
        //if ($scope.UserName == null) {
        //    $scope.showDialog("Please enter user name.");
        //    return
        //}

        //if ($scope.email == null && $scope.mobileno == null) {
        //    $scope.showDialog("Please enter either email id or mobile number.");
        //    return
        //}

        $http.get('/api/LOGIN/RetrivePassword?email='+$scope.email).then(function (response, data) {
            $scope.result = response.data;        
       
            if ($scope.result.length == 0)
        {
                $scope.showDialog("Invalid email id or email id not registered. Please contact administrator.")
        }else
            $scope.showDialog("Temporary password has been sent to the registerd email-id:" + $scope.email)
        }, function () {
            $scope.showDialog("Invalid email id or email id not registered. Please contact administrator.")
        });
    }
        //send the details to db for validation

        $scope.showDialog = function (message) {

            var modalInstance = $uibModal.open({
                animation: $scope.animationsEnabled,
                backdrop:false,
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

        

