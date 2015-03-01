'use strict';
var app = angular.module('PizzaApp');
app.controller('loginController', function($scope, $alert, $auth, sharedProperties,$location,cookieService){
    $scope.login = function() {
        $auth.login({ email: $scope.email, password: $scope.password })
            .then(function(response) {
               // $scope.user = response.data;
              //  $scope.em = $scope.user.email;
               // sharedProperties.setUser(response.data);
                cookieService.set(response.data);
                $alert({
                    content: 'You have successfully logged in',
                    animation: 'fadeZoomFadeDown',
                    type: 'material',
                    duration: 3
                });
                $location.path( "/explore" );
            })
            .catch(function(response) {
                $alert({
                    content: response.data.message,
                    animation: 'fadeZoomFadeDown',
                    type: 'material',
                    duration: 3
                });
            });
    };
    $scope.authenticate = function(provider) {

        $auth.authenticate(provider)
            .then(function() {
                $alert({
                    content: 'You have successfully logged in',
                    animation: 'fadeZoomFadeDown',
                    type: 'material',
                    duration: 3
                });
            })
            .catch(function(response) {
                $alert({
                    content: response.data ? response.data.message : response,
                    animation: 'fadeZoomFadeDown',
                    type: 'material',
                    duration: 3
                });
            });
    };
});