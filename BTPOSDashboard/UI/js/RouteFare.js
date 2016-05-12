// JavaScript source code
var myapp1 = angular.module('myApp', [])

var mycrtl1 = myapp1.controller('Mycntrlr', function ($scope, $http) {

    $scope.routefares = [
        { Source: 'Hyderabad', Dest: 'Dilsuknagar', PricingType: '1', Amount: '10', From: '', To: '' },
        { Source: 'Dilsuknagar', Dest: 'LB Nagar', PricingType: '1', Amount: '10', From: '', To: '' },
        { Source: 'LB Nagar', Dest: 'Choutupal', PricingType: '1', Amount: '10', From: '', To: '' },
        { Source: 'Choutupal', Dest: 'Vijaywada', PricingType: '1', Amount: '10', From: '', To: '' }
    ];

   

});



