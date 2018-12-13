app.controller('HomeController', ['$scope', '$window', 'localStorageService', function ($scope, $window, localStorageService) {

    var getToken = function (config) {

        config.headers = config.headers || {};

        var authData = localStorageService.get('authorizationData');
        if (authData) {
            config.headers.Authorization = 'bearer ' + authData.token; // It reads the Token here!
        }

        return config;
    }

    var redirect = function ($scope, $http) {
        $http.get('http://localhost/RateYourBookApi/books')
            .then(function (response) {
                $scope.books = response.data;
            });
    }

    authInterceptorServiceFactory.request = getToken;

    return authInterceptorServiceFactory;
}]);