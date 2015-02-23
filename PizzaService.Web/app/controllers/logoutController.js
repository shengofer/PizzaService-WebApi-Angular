app = angular.module('PizzaApp');
app.controller('logoutController', function($auth, $alert){
    if (!$auth.isAuthenticated()) {
        return;
    }
    $auth.logout()
        .then(function() {
            $alert({
                content: 'You have been logged out',
                animation: 'fadeZoomFadeDown',
                type: 'material',
                duration: 3
            });
            $location.path( "/explore" )
        });
})