'use strict';
app = angular.module('PizzaApp');


app.factory('pizzasViewService', function ($resource) {

    return $resource('http://localhost:41841/api/pizzas/:id',{id:'@_id'},{
        update: {
            method: 'PUT'
        }
    });

});
