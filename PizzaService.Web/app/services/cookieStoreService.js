'use strict';
var app  = angular.module('PizzaApp');

app.factory('cookieService',  ['$cookieStore', function ($cookieStore,base64) {

    var user = {};
    return {
        user : user,

        set: function (user) {
            // you can retrive a user setted from another page, like login sucessful page.
/*            var existing_cookie_user = $cookieStore.get('current.user');
            user =  user || existing_cookie_user;*/
            $cookieStore.put('current.user', user);
        },

        remove: function () {
            $cookieStore.remove('current.user', user);
        },

        get: function(){
            return $cookieStore.get('current.user');
        },
        getAuthHeader: function(){
           var user = $cookieStore.get('current.user');
           return  'basic ' + base64.encode(user.email+':'+user.password)
        }
    };

}])
;