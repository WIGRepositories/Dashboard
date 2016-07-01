var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname
    $scope.dashboardDS = $localStorage.dashboardDS;

    $scope.cartitem = [];

    //get the items first (based on filters if any)
    $scope.items = [{ "name": "BT POS", "price": "10", "Id": "1" }, { "name": "BT POS1", "price": "11", "Id": "3" }
        , { "name": "BT POS2", "price": "12", "Id": "2" }];



    $scope.increasecart = function (qty) {
        $scope.cartitem.push(qty);

        
            return $scope.cartitem;
     
    }
    $scope.GetItems = function () {
        $http.get('http://localhost:1476/api/ShoppingCart/GetItems').then(function (response, req) {
            $scope.items = response.data;
        });
    }


    $scope.Save = function (items,flag) {

        if (items == null) {
            alert('Please select any item.');
            return;
        }
        var saveitems  = {

            ItemId: items.ItemId,
            ItemName: items.ItemName,
            UnitPrice: items.UnitPrice,
           
            insupddelflag: flag,
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/ShoppingCart/SaveCartItems',
            //headers: {
            //    'Content-Type': undefined
            data: saveitems
        }
        $http(req).then(function (res) {
            alert('saved successfully');

        });
    }
});