
var myapp1 = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])

var mycrtl1 = myapp1.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;
   
    $scope.carouselImages = [{ "ID": 1, "Name": "TRAVEL WITH INTERBUS", "Caption": "Every Journey Matters....", "Path": "http://localhost:1476/UI/images/11.jpg" }
       , { "ID": 2, "Name": "Customer satisfaction", "Caption": "The comfort and convienience of travelling with INTERBUS", "Path": "http://localhost:1476/UI/images/12.png" }
       , { "ID": 3, "Name": "Online Ticket Booking", "Caption": "Automated ticketing increases performance and convienience", "Path": "http://localhost:1476/UI/images/13.jpg" }
       , { "ID": 4, "Name": "Hassel free travel", "Caption": "Get online tickets to make the journey hassel free", "Path": "http://localhost:1476/UI/images/14.jpg" }
       , { "ID": 5, "Name": "Extensive coverage", "Caption": "Wide network taking you to various destinations", "Path": "http://localhost:1476/UI/images/user.jpg" }
    ];

    /*end of  vehicle schedule list*/
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

    $scope.showPreview = function () {

        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: 'myModalContent1.html'            
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

