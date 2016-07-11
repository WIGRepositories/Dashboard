
var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {

    customers = [
  {
      "active": 0,
      "code": "brc1",
      "desc": "travels",
      "Id": 9,
      "Name": "BRCR",
      "ContactNo1": "955052020",
      "ContactNo2": "55221100",
      "Fax": "0401211",
      "EmailId": "brcr@gm",
      "Title": "happy",
      "Address": "hyd",
      "Caption": "goodnight",
      "State": "Ts",
      "Country": "Australia",
      "ZipCode": 521000
  },
  {
      "active": 1,
      "code": "INTERBUS",
      "desc": "INTERBUS company",
      "Id": 1,
      "Name": "INTERBUS",
      "ContactNo1": "9502022",
      "ContactNo2": "9502056374",
      "Fax": "0104101",
      "EmailId": "Lok@sww",
      "Title": "WebIngate",
      "Address": "hyd",
      "Caption": "Pvt.Lmtd",
      "State": "AndhraPradesh",
      "Country": "India",
      "ZipCode": 510010
  },
  {
      "active": 0,
      "code": "RB",
      "desc": "travels",
      "Id": 7,
      "Name": "RedBus",
      "ContactNo1": "950200",
      "ContactNo2": "81414555",
      "Fax": "040110",
      "EmailId": "red@ma",
      "Title": "happy journy",
      "Address": "Hyd",
      "Caption": "travel",
      "State": "Ts",
      "Country": "Australia",
      "ZipCode": 5100078
  },
  {
      "active": 0,
      "code": "VCR1",
      "desc": "Travel",
      "Id": 8,
      "Name": "VRCR",
      "ContactNo1": "95220220",
      "ContactNo2": "84141122",
      "Fax": "040",
      "EmailId": "VRC@hm",
      "Title": "travels",
      "Address": "ts",
      "Caption": "trust us",
      "State": "andj",
      "Country": "Armenia",
      "ZipCode": 5210
  },
  {
      "active": 1,
      "code": "WEBINGATE",
      "desc": "WEBINGATE company",
      "Id": 2,
      "Name": "WEBINGATE",
      "ContactNo1": "95020200",
      "ContactNo2": "850005855",
      "Fax": "040140",
      "EmailId": "loki@gmail",
      "Title": "Thomson",
      "Address": "HYD",
      "Caption": "Pvt.Lmtd",
      "State": "T.S",
      "Country": "U.S",
      "ZipCode": 514141
  },
  {
      "active": 1,
      "code": "ZUPCO",
      "desc": "ZUPCO company",
      "Id": 3,
      "Name": "ZUPCO",
      "ContactNo1": "95020200",
      "ContactNo2": "58552220",
      "Fax": "040151",
      "EmailId": "zipu@gmail",
      "Title": "Zipco",
      "Address": "GTR",
      "Caption": "Pvt.Lmtd",
      "State": "T.S",
      "Country": "India",
      "ZipCode": 514111
  }
    ]

    $scope.GetVendors = function () {
        $scope.Vendors = Vendors;
    }

    $scope.addVendors = function (vend) {

        $scope.Vendors.push(vend);
    }

    $scope.setVendors = function (c) {
        $scope.Group = c;
    }
});