app.controller("HomeController", function ($scope, $http) {
    $http.get('http://localhost/RateYourBookApi/books')
        .then(function (response) {
            $scope.books = response.data;
        });
});