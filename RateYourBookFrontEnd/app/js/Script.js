
                         //    Module, Dependences
var myApp = angular.module("myModule", []);

// Step 2
//var myController = function ($scope) {
//    $scope.message = "Angular JS Tutorial"
//};

// Step 3
//// Register this Controller within our module
//myApp.controller("myController", myController);

// Specify the function to Registration - avoid steps 2, 3
myApp.controller("myController", function ($scope) {
    var book = {
        Title: "Kokkinoskoufitsa",
        ISBN: "isbn-02-04-256"
    };

    $scope.message = "Angular JS Tutorial"
    $scope.book = book;
});