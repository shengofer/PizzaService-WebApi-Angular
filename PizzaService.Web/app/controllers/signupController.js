'use strict';
var app = angular.module('PizzaApp');
app.controller('signupController', function($scope,customersService, $alert, $auth,$http,$location) {
    $scope.signup = function() {
        return $auth.signup({
            displayName: $scope.displayName,
            email: $scope.email,
            password: $scope.password
        }).catch(function(response) {
            if (typeof response.data.message === 'object') {
                angular.forEach(response.data.message, function(message) {
                    $alert({
                        content: message[0],
                        animation: 'fadeZoomFadeDown',
                        type: 'material',
                        duration: 3
                    });
                });
               // $location.path( "/login" );
            } else {
                $alert({
                    content: response.data.message,
                    animation: 'fadeZoomFadeDown',
                    type: 'material',
                    duration: 3
                });
               // pattern = true;
            }
        },
        $location.path( "/login" )
        );
    };

});
