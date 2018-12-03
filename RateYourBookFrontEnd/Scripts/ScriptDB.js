var app = angular
    .module("myModule", [])
    .controller("myController", function ($scope, $http)
    {
        $http.get('http://localhost/RateYourBookApi/books')
            .then(function (response) {
                $scope.books = response.data;
            });
    });