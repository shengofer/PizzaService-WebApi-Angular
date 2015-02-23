
var app = angular.module('PizzaApp', [
    'ngRoute',
    'ngResource',
    'ui.bootstrap',
    'toaster',
    'satellizer',
    'ngMessages',
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
        templateUrl: "app/views/signup.html"
    });

    $routeProvider.when("/login",{
        controller: "loginController",
        templateUrl: "app/views/login.html"
    });

    $routeProvider.when("/cart",{
        controller: "cartController",
        templateUrl: "app/views/cart.html"
    });

    $routeProvider.when("/logout",{
        controller: "logoutController",
        templateUrl: null
    });

    $routeProvider.when("/ordersucces", {
          templateUrl:"app/views/orderSuccess.html"
    });

/*    $routeProvider.when("/places", {
        controller: "myPlacesController",
        templateUrl: "/app/views/myplaces.html"
    });

    $routeProvider.when("/about", {
        controller: "aboutController",
        templateUrl: "/app/views/about.html"
    });*/

    $routeProvider.otherwise({ redirectTo: "/explore" });


    $authProvider.facebook({
        clientId: '657854390977827'
    });

    $authProvider.google({
        clientId: '672396627676-gtoh351al2s908eh6gus59rk082nj27i.apps.googleusercontent.com'
    });
});