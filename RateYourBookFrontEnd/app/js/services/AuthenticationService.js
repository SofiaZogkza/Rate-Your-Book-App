app.service('AuthenticationService', ['$http', function ($http) {
    return {
        login: function (username, password) {
            var url = 'http://localhost/RateYourBookApi/token';
            var data = "grant_type=password&username=" + username + "&password=" + password;
            var config = { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } };

            return $http.post(
                url,
                data,
                config
            ).then(function successCallback(response) {
                alert('authenticated');
                //1. Store token somewhere where it is available to your entire app
            }, function errorCallback(response) {
                alert('NOT authenticated');
                //1. If authentication error show login error message
                //2. Else show generic error message
                // TODO construct error message
                var errorMessage = 'Something went wrong';
                return errorMessage;
            });
        }
    }
}]);