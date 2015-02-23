var app = angular.module('PizzaApp');

app.service('sharedProperties',function() {
    var user;

    return {
        getUser: function() {
            return user;
        },
        setUser: function(newUser) {
            user = newUser;
        },
        isAuth: function() {
            if(user) return true;
            else false;
        }
    }
});