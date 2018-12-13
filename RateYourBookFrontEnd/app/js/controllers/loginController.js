app.controller('LoginController', ['$scope', '$window', 'AuthenticationService', function ($scope, $window, AuthenticationService) {

    $scope.usernameS;
    $scope.passwordS;
    
    $scope.message = "";

    $scope.login = function () {
        AuthenticationService.login($scope.usernameS, $scope.passwordS).then(
            function onSuccess() {
                //TODO Redirect to home...
                $window.location.href = 'http://localhost/RateYourBookApi/home';
            },
            function onError(errorMessage) {
                // TODO show error message to user if error 500 show this if error401 show that
                if (errorMessage === 401) {
                    alert('There was a problem! We cannot find an account with that username or password');
                    $window.location.href = 'http://localhost/RateYourBookApi/login';
                } else {
                    alert('Something went wrong with the server. Most probably token issue.');
                    $window.location.href = 'http://localhost/RateYourBookApi/login';
                }
            }
        );
    };

}]);