'use strict';
var app = angular.module('PizzaApp');
app.factory('customersService', function ($resource,$http,$location) {
    var local = {};
    var signupUrl = 'http://localhost:41841/api/auth/signup';
    var loginOnSignup = true;
    var signupRedirect =  '#/login';
    function signup (user) {
        $http.defaults.headers.post["Content-Type"] = "application/json";
        //   return $http.post(config.signupUrl, {displayName:user.displayName,email:user.email, password: user.password})
        return $http.post(signupUrl, user)
            .then(function(response) {
                if (loginOnSignup) {

                } else if (signupRedirect) {
                    $location.path(signupRedirect);

                }
                return response;
            });
    };
    //return local;
    //return $resource('http://localhost:41841/api/images/:id',{id:'@_id',responseType:'arraybuffer'}, {
    var save = function(){
        return $resource('http://localhost:41841/api/auth/signup/:id',{id:'@_id'}, {
            update: {
                method: 'PUT'
            }
        });
    }

    return local;

});