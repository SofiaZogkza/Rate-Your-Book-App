app.service('AuthenticationService', ['$http', function ($http) {
    var token;

    this.login = function (username, password) {
        var url = 'http://localhost/RateYourBookApi/token';
        var data = "grant_type=password&username=" + username + "&password=" + password;
        var config = { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } };

        return $http.post(
            url,
            data,
            config
        ).then(
            function successCallback(response) {
                token = response.access_token;
                console.log(token);
            }, function errorCallback(response) {
                //1. If authentication error show login error message
                //2. Else show generic error message
                // TODO construct error message
                var errorMessage;
                alert('NOT authenticated');
                if (response.status === 401) {
                    errorMessage = 'There was a problem! We cannot find an account with that username or password';
                } else {
                    errorMessage = 'Something went wrong with the server. Most probably token issue.';
                }
                return $q.reject(errorMessage);
            });
    }
}]);