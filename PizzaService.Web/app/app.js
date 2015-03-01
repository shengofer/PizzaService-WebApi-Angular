
var app = angular.module('PizzaApp', [
    'ngRoute',
    'ngResource',
    'ui.bootstrap',
    'toaster',
    'satellizer',
    'ngMessages',
     'ngCookies',
    'mgcrea.ngStrap'
   // 'chieffancypants.loadingBar',

]);

app.config(function ($routeProvider,$authProvider) {

    $routeProvider.when("/explore", {
        controller: "pizzasViewController",
        templateUrl: "app/views/pizzasList.html"
    });

    $routeProvider.when("/signup",{
        controller: "signupController",
        templateUrl: "app/views/signup.html",
        resolve: {
            authenticated: function($q, $location, cookieService) {
                var deferred = $q.defer();

                if (cookieService.get()) {
                    $location.path('/logout');
                } else {
                    deferred.resolve();
                }

                return deferred.promise;
            }
        }
    });

    $routeProvider.when("/login",{
        controller: "loginController",
        templateUrl: "app/views/login.html",
        resolve: {
            authenticated: function($q, $location, cookieService) {
                var deferred = $q.defer();

                if (cookieService.get()) {
                    $location.path('/logout');
                } else {
                    deferred.resolve();
                }

                return deferred.promise;
            }
        }
    });

    $routeProvider.when("/cart",{
        controller: "cartController",
        templateUrl: "app/views/cart.html",
        resolve: {
            authenticated: function($q, $location, cookieService) {
                var deferred = $q.defer();

                if (!cookieService.get()) {
                    $location.path('/login');
                } else {
                    deferred.resolve();
                }

                return deferred.promise;
            }
        }
    });

    $routeProvider.when("/logout",{
        controller: "logoutController",
        templateUrl:"app/views/logout.html"
        //templateUrl:null
    });

    $routeProvider.when("/ordersucces", {
          templateUrl:"app/views/orderSuccess.html",
            resolve: {
            authenticated: function($q, $location, cookieService) {
                var deferred = $q.defer();

                if (!cookieService.get()) {
                    $location.path('/login');
                } else {
                    deferred.resolve();
                }

                return deferred.promise;
            }
        }
    });

    $routeProvider.otherwise({ redirectTo: "/explore" });


    $authProvider.facebook({
        clientId: '657854390977827'
    });

    $authProvider.google({
        clientId: '672396627676-gtoh351al2s908eh6gus59rk082nj27i.apps.googleusercontent.com'
    });
});