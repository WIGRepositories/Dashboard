// JavaScript source code
var myapp1 = angular.module('myApp', [])
var mycrtl1 = myapp1.controller('Mycntrlr', function ($scope, $http) {

    $http.get('http://localhost:1476/api/types/users').then(function (res, data) {
        $scope.Types = res.data;


    });
    $scope.save = function (Types) {
        alert("ok");
        var Types = {

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



            Id: Types.Id,
            Name: Types.Name,
            Desc: Types.Desc,
            Active: Types.Active,
            TypeGroupId: Types.TypeGroupId
        };
        $scope.save
        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/types/pos',
            //headers: {
            //    'Content-Type': undefined

            data: Types


        }
        $http(req).then(function (res) { });

    };



});