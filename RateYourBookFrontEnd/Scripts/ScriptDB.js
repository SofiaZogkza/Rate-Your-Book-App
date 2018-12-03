var app = angular
    .module("myModule", [])
    .controller("myController", function ($scope, $http) {

        //var obj = {};

        //obj.getData = function () {
        //    return $http({
        //        method: "GET",
        //        url: "http://localhost/RateYourBookApi/getallbooks",
        //    })
        //}

        //return obj.getData;

        $http.get('http://localhost/RateYourBookApi/books')
            .then(function (response) {
                $scope.books = response.data;
            });
    });