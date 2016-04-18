// JavaScript source code
var myapp1 = angular.module('myApp', [])
var mycrtl1 = myapp1.controller('Mycntrlr', function ($scope, $http) {

    $http.get('http://localhost:1476/api/Types/TypesByGroupId?groupid=-1').then(function (res, data) {
        $scope.Types = res.data;
    });
    $scope.Sample = [{

        id: '16',
        name: 'Gender'
    },
    {
    id:'12',
    name:'Status'
},
{
    id:'13',
    name:'UserType'
}];

    $scope.getselectval = function (seltype) {
        var grpid = (seltype) ? seltype.id: -1;

        $http.get('http://localhost:1476/api/Types/TypesByGroupId?groupid=' + grpid).then(function (res, data) {
            $scope.Types = res.data;

        });

        $scope.selectedvalues = 'Name: ' + $scope.selitem.name + ' Id: ' + $scope.selitem.id;
        
    }





    $scope.save = function (Types) {
        alert("ok");
        var Types = {

         Id:Types.Id,
            Name: Types.Name,
            Description: Types.Description,
            Active: Types.Active,
            TypeGroupId: Types.TypeGroupId,
            ListKey: Types.ListKey,
            Listvalue: Types.Listvalue
        };
        $scope.save
        var req = {
            method: 'POST',
            url: 'http://localhost:1476/api/Types/Type2',
            //headers: {
            //    'Content-Type': undefined

            data: Types


        }
        $http(req).then(function (res) { });
      

        $scope.currGroup = null;

    };

    $scope.setCompany = function (grp) {
        $scope.currGroup = grp;
    };

    $scope.clearGroup = function () {
        $scope.currGroup = null;
    };

    
});