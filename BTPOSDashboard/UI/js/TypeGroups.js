// JavaScript source code
var myapp1 = angular.module('myApp', [])
var mycrtl1 = myapp1.controller('Mycntrlr', function ($scope, $http) {

    $http.get('http://localhost:1476/api/typegroups/users').then(function (res, data) {
        $scope.TypeGroups = res.data;
      
           

    });
    $scope.save = function (TypeGroups) {
        alert("ok");
        var TypeGroups = {

            //        SNo: DailyExpr.SNO,
            //        Incomee: DailyExp.Income,
            //        Bonus: DailyExp.Bonus,
            //        Loss: DailyExp.Loss
            //"Id":"sadsad",
            // "ItemId":1000,
            // "ItemTypeId":"th",
            // "Formdate":"bb",
            // "Todate":"kk",
            // "Active":"dsaasda",
            // "Desc":"sadsada",
            // "Reason":"th",
            // "Blockedby":"bb",
            // "UnBlockedby":"kk",
            //"Blockedon":1000,
            // "UnBlockedon":"th",



          
            Name: TypeGroups.Name,
            Desc: TypeGroups.Desc,
            Active: TypeGroups.Active
           

     
        };
        $scope.save
        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/typegroups/pos',
            //headers: {
            //    'Content-Type': undefined

            data: TypeGroups


        }
        $http(req).then(function (res) { });

    };



});
