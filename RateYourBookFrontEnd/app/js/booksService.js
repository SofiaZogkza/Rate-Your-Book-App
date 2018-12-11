'use strict';
app.factory('ordersService', ['$http', function ($http) {

    var serviceBase = 'http://localhost/RateYourBookApi/';
    var ordersServiceFactory = {};

    var _getOrders = function () {

        return $http.get(serviceBase + 'books').then(function (results) {
            return results;
        });
    };

    ordersServiceFactory.getOrders = _getOrders;

    return ordersServiceFactory;

}]);