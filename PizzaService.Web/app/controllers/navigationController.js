'use strict';
app = angular.module('PizzaApp');
app.controller('navigationController', function ($scope, $location,$auth, sharedProperties) {

    $scope.isActive = function (path) {

        return $location.path().substr(0, path.length) == path;
    };

    $scope.isAuthenticated = function() {
        var testvar = sharedProperties.getUser();
        if(testvar) return true;
        else false;
        //return $auth.isAuthenticated();
    };

    //$scope.hasUserInCtx = function () {
        
    //    return (!placesDataService.getUserInContext()) ? true : false;
    //};
});