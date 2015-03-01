'use strict';
app = angular.module('PizzaApp');
app.controller('navigationController', function ($scope, $location,$auth, sharedProperties,cookieService) {

    $scope.isActive = function (path) {
        return $location.path().substr(0, path.length) == path;
    };

    $scope.isAuthenticated = function() {
        var user = cookieService.get();
        if(user) return true;
        else false;
    };

});