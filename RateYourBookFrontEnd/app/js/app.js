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



//app.config(function ($httpProvider) { //TODO : Check if it is httpProvider or if we can add it to $stateProvider
//    $httpProvider.interceptors.push('authInterceptorService');
//});

//app.run(['authService', function (authService) {
//    authService.fillAuthData();
//}]);