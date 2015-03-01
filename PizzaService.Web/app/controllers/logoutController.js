'use strict';
app = angular.module('PizzaApp');
app.controller('logoutController', function($auth, $alert,cookieService){
    cookieService.remove();
/*    $auth.logout()
        .then(function() {
            $alert({
                content: 'You have been logged out',
                animation: 'fadeZoomFadeDown',
                type: 'material',
                duration: 3
            });
            cookieService.remove();
           // $location.path( "/explore" )
        });*/
});