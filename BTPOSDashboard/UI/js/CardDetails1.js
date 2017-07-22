// JavaScript source code
var myapp1 = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var mycrtl1 = myapp1.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal, $filter)
{
    //if ($localStorage.uname == null) { window.location.href = "../login.html"; }
    //$scope.uname = $localStorage.uname;
    //$scope.userdetails = $localStorage.userdetails;
    //$scope.isSuperUser = $localStorage.isSuperUser;
    //$scope.roleLocations = $localStorage.roleLocation;
    //$scope.isAdminSupervisor = $localStorage.isAdminSupervisor;
    //$scope.dashboardDS = $localStorage.dashboardDS;
   
    $scope.parseLocation = function (location) {
        var pairs = location.substring(1).split("&");
        var obj = {};
        var pair;
        var i;

        for (i in pairs) 
        {
            if (pairs[i] === "") continue;

            pair = pairs[i].split("=");
            obj[decodeURIComponent(pair[0])] = decodeURIComponent(pair[1]);
        }

        return obj;
    };
    $scope.init = function () {

        $http.get('/api/Cards/GetCustomers').then(function (res, data)
        {
            $scope.Customers = res.data;

           
        });

        $http.get('/api/Cards/GetCardStatus').then(function (res, data) {
            $scope.CardStatus = res.data;
        });
        $http.get('/api/Cards/GetCardNumbers').then(function (res, data) {
            $scope.CardNumbers = res.data;
         });

        $http.get('/api/Cards/GetCardNumbers').then(function (res, data) {
            $scope.effectiveFrom=res.data;
        });

        $http.get('/api/Cards/GetUserids').then(function (res, data) {
            $scope.Userids = res.data;
        });
        
    } 
            $scope.saveCardDetails = function (currCard)
            {
                var currCard = {

                    CardName: currCard.CardName,
                    CardNumber: currCard.CardNumber,
                    NameOnCard: currCard.NameOnCard,
                    ReferenceId: currCard.ReferenceId,
                    EstimatedStartDate: currCard.EstimatedStartDate,
                    EstimatedEndDate: currCard.EstimatedEndDate,
                    EffectiveFrom: currCard.EffectiveFrom,
                    ValidTillDate: currCard.ValidTillDate,
                    CVV: currCard.CVV,
                    CVV2: currCard.CVV2,
                    PIN: currCard.PIN,
                    CardStatus: currCard.cs.StatusId,
                    Customer: currCard.cc.Customer,
                    UserId: currCard.p.UserId,
                    flag: 'I'
                };

                var req = {
                    method: 'POST',
                    url: '/api/Cards/SaveCardDetails',
                    data: currCard
                }
                $http(req).then(function (response) {

                    $scope.showDialog("Saved successfully!");
                    $scope.getCardDetails(currCard.Id);
                    $scope.currCard = null;

                }, function (errres) {
                    var errdata = errres.data;
                    var errmssg = "";
                    errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
                    $scope.showDialog(errmssg);
                });
                //$scope.currGroup = null;
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