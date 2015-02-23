var app = angular.module('PizzaApp');
app.factory('ordersService', function ($resource) {

    return $resource('http://localhost:41841/api/orders/:id', {}, {
        post: { method: 'POST', params: { customerId: "@customerId", pizzaId: '@pizzaId' }, isArray: true }
    })
/*    return $resource('http://localhost:41841/api/orders/:id',{id:'@id'}, {
        update: {
            method: 'PUT'
        }
    });*/
    //return $resource('http://localhost:41841/api/images/:id',{id:'@_id',responseType:'arraybuffer'}, {
 /*   return $resource('http://localhost:41841/api/orders/:customerId:pizzaId',{customerId:'@_customerId',pizzaId:'@_pizzaId'}, {
        update: {
            method: 'PUT'
        }
    });*/
});