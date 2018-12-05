var app = angular.module("myModule", ['ui.router']); 

app.config(function ($stateProvider) {
    $stateProvider.state({
        name: 'home',
        url: '/',
        templateUrl: "home.html"
    });
    $stateProvider.state({
        name: 'books',
        url: '/books',
        templateUrl: "Books.html"
    });
    $stateProvider.state({
        name: 'aboutus',
        url: '/aboutus',
        templateUrl: "AboutUs.html"
    });
    $stateProvider.state({
        name: 'login',
        url: '/login',
        templateUrl: "LogIn.html"
    });
    $stateProvider.state({
        name: 'signup',
        url: '/signup',
        templateUrl: "SignUp.html"
    });
});

app.controller("myController", function ($scope, $http) {
    $http.get('http://localhost/RateYourBookApi/books')
        .then(function (response) {
            $scope.books = response.data;
        });
});