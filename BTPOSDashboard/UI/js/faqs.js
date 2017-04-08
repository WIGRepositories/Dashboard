var app = angular.module('faqs', []);

var ctrl = app.controller('myCtrl', function ($scope, $http) {
    $scope.Getlist = function () {
        $http.get("/api/faqs/Getlist").then(function (response, req) {
            $scope.Getlist = response.data;
        });
    }
    $scope.question = null;


    $scope.setfaqs = function (type) {
        alert(type);
        question = $scope.question;
        answer = $scope.answer;


    }

    var req = {
        method: 'Post',
        url: 'api/faqs/SavefaqsdetailsUsingpost',
        data: setfaqs
    }

    $http(req).then(function (response) {
        //alert("save successfully!!");
        //window.location.href = "Register.html";
    },
    function (errres) {
        alert(errres.data);
    });
});

