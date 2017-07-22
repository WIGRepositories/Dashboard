// JavaScript source code
var myapp1 = angular.module('myApp', ['ngStorage', 'ui.bootstrap']);


var mycrtl1 = myapp1.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal, $filter) {
    if ($localStorage.uname == null) {
        window.location.href = "../login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.isSuperUser = $localStorage.isSuperUser;
    $scope.roleLocations = $localStorage.roleLocation;
    $scope.isAdminSupervisor = $localStorage.isAdminSupervisor;


    $scope.CardModelData = function ()
    {
        $http.get('/api/Cards/CardModelData').then(function (res, data) {
            $scope.CardModelData = res.data;
            $scope.CardList = res.data;
        });
    }

    $scope.CardModelData = function()
    {
        $scope.CardList = null;

        // var locId = ($scope.s == null || $scope.s.id == null) ? -1 : $scope.s.id;
        var Id = ($scope.c == null || $scope.c.Id == null) ? -1 : $scope.c.Id;
        var statusId = ($scope.a == null || $scope.a.Id == null) ? -1 : $scope.a.Id;



        $http.get('/api/Cards/GetCardList?statusId=' + statusId +/* '&locationId=' + locId + */'&Id=' + custId).then(function (res, data)
        {
            $scope.CardList1 = res.data;
            $scope.CardList = res.data;
        });
        /*   $scope.CheckCanCreate(locId);   
        }
   
       $scope.CardModelData = function ()
       {
           $http.get('/api/Cards/CardModelData').then(function (res, data)
           {
               $scope.CardModelData = res.data;
               $scope.CardList = res.data;
           });
       }
   
       $scope.CardModelData = function ()
       {
           $scope.CardList = null;
   
           var locId = ($scope.s == null || $scope.s.id == null) ? -1 : $scope.s.id;
           var Id = ($scope.c == null || $scope.c.Id == null) ? -1 : $scope.c.Id;
           var statusId = ($scope.a == null || $scope.a.Id == null) ? -1 : $scope.a.Id;
                     
          $http.get('/api/Cards/GetCardList?statusId=' + statusId +/*'&locationId=' + locId + *//*'&Id=' + custId).then(function (res, data) 
       {
             $scope.CardList1 = res.data;
             $scope.CardList = res.data;
       }); 
      // $scope.CheckCanCreate(locId); */   
    } 
 
    $scope.CardTypeData = function ()
    {
        $http.get('/api/Cards/CardTypeData').then(function (res, data)
        {
            $scope.CardTypeData = res.data;
            $scope.CardList = res.data;
        });
    }

    $scope.CardTypeData = function ()
    {
        $scope.CardList = null;

        // var locId = ($scope.s == null || $scope.s.id == null) ? -1 : $scope.s.id;
        var Id = ($scope.c == null || $scope.c.Id == null) ? -1 : $scope.c.Id;
        var statusId = ($scope.a == null || $scope.a.Id == null) ? -1 : $scope.a.Id;

        $http.get('/api/Cards/GetCardList?statusId=' + statusId +/* '&locationId=' + locId + */'&Id=' + custId).then(function (res, data)
        {
            $scope.CardList1 = res.data;
            $scope.CardList = res.data;
        });
        //  $scope.CheckCanCreate(locId);   
    }

    $scope.GetCategoriesLists = function ()
    {
        $http.get('/api/Cards/GetCategoriesLists').then(function (res, data) {
            $scope.GetCategoriesLists = res.data;
            $scope.CardList = res.data;
        });
    }

    $scope.GetCategoriesLists = function () {
        $scope.CardList = null;

        var locId = ($scope.s == null || $scope.s.id == null) ? -1 : $scope.s.id;
        var Id = ($scope.c == null || $scope.c.Id == null) ? -1 : $scope.c.Id;
        var statusId = ($scope.a == null || $scope.a.Id == null) ? -1 : $scope.a.Id;



        $http.get('/api/Cards/GetCardList?statusId=' + statusId +/* '&locationId=' + locId + */'&Id=' + custId).then(function (res, data) {
            $scope.CardList1 = res.data;
            $scope.CardList = res.data;
        });
        //  $scope.CheckCanCreate(locId);   
    }

    // $scope.CheckCanCreate(locId);   
    
});

//$scope.AddNewCardData2 = function (newCard)
//{
//    /* var newCard = $scope.newCard;
//    if (newCard == null) {
//        alert('Please enter Card name.');
//        return;
//    }
//   //Cardname
//    if (newCard.CardName == null) {
//        alert('Please enter Card name.');
//        return;
//    }
//    //CardId#
//    if (newCard.Id == null) {
//        alert('Please enter Id');
//        return;
//    }  
//    //CardNo
//    if(newCard.CardNumber == null)
//    {
//        alert('Please enter CardNumber');
//        return;
//    }
//    //  CustomerID
//    if (newCard.Customer == null) {
//        alert('Please select Customer.');
//        return;
//    }

//    // CardModel
//    if (newCard.CardModel == null) {
//        alert('Please select Model.');
//        return;
//    }
//    //CardType
//    if (newCard.CardType == null) {
//        alert('Please enter CardType ');
//        return;
//    }
//    //CardCategory
//    if (newCard.CardCategory == null) {
//        alert('Please Select CardCategory ');
//        return;
//    }
//    // EstStartDt
//    if (newCard.EffectiveFrom == null) {
//        alert('Please select Effective From date.');
//        return;
//    }
//    //  EstEndDt
//    if (newCard.EffectiveTo == null) {
//        alert('Please select EffectiveTo date.');
//        return;
//    }
//    /*ProjDesc
//    if (newCard.ProjDesc == null) {
//        alert('Please enter project description.');
//        return;
//    }*/

//    var Cards = {

//        CardNumber: newCard.CardNumber,
//        CardType:   newCard.CardType,
//        CardModel:  newCard.CardModel,
//        CardCategory: newCard.CardCategory,
//        flag: 'I'
//    }

//    var req = {
//        method: 'POST',
//        url: '/api/Cards/SavePostCardDetails',
//        data: Cards
//    }
//    $http(req).then(function (response)
//    {

//        $scope.showDialog("Saved successfully!");
//        $scope.GetCardList();
//        $scope.newCard = null;
//        $('#Modal-header-new').modal('hide');
//    }, function (errres) {
//        var errdata = errres.data;
//        var errmssg = "";
//        errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
//        $scope.showDialog(errmssg);
//    });
//    $scope.currGroup = null;
//}

//$scope.showDialog = function (message)
//{

//    var modalInstance = $uibModal.open(
//        {
//            animation: $scope.animationsEnabled,
//            templateUrl: 'myModalContent.html',
//            controller: 'ModalInstanceCtrl',
//            resolve:
//            {
//                mssg: function () {
//                    return message;
//                }
//            }
//        });
//}
//  myapp1.controller('ModalInstanceCtrl', function ($scope, $uibModalInstance, mssg)
//{

//    $scope.mssg = mssg;
//    $scope.ok = function () {
//        $uibModalInstance.close('test');
//    };

//    $scope.cancel = function () {
//        $uibModalInstance.dismiss('cancel');
//    };

//    $scope.showDialog = function (message) {

//        var modalInstance = $uibModal.open(
//            {
//                animation: $scope.animationsEnabled,
//                templateUrl: 'myModalContent.html',
//                controller: 'ModalInstanceCtrl',
//                resolve: {
//                    mssg: function ()
//                    {
//                        return message;
//                    }
//                }
//            });
//    }
//});
