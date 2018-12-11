app.controller('LoginController', ['$scope', 'AuthenticationService', function ($scope, AuthenticationService) {


    $scope.usernameS;
    $scope.passwordS;
    

    $scope.message = "";

    $scope.login = function () {
        AuthenticationService.login($scope.usernameS, $scope.passwordS).then(
            function onSuccess() {
                //TODO Redirect to home...
            },
            function onError(errorMessage) {
                // TODO show error message to user
            }
        );
    };

}]);