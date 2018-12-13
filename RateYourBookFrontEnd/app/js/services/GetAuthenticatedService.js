app.service('getAuthenticatedService', ['$q', '$location', 'localStorageService', function ($q, $location, localStorageService) {

    var authInterceptorServiceFactory = {};

    var getToken = function (response) {

        response.headers = response.headers || {};

        var authData = localStorageService.get('authorizationData');
        if (authData) {
            response.headers.Authorization = 'bearer ' + authData.token; // It reads the Token here!
        }

        return config;
    }

    var _responseError = function (rejection) {
        if (rejection.status === 401) {
            $location.path('/login');
        }
        return $q.reject(rejection);
    }

    authInterceptorServiceFactory.request = getToken;
    authInterceptorServiceFactory.responseError = _responseError;

    return authInterceptorServiceFactory;
}]);