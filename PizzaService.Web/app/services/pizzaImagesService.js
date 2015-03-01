'use strict';
app.factory('pizzaImagesService', function ($resource) {

    //return $resource('http://localhost:41841/api/images/:id',{id:'@_id',responseType:'arraybuffer'}, {
    return $resource('http://localhost:41841/api/images/:id',{id:'@_id'}, {
        update: {
            method: 'PUT'
        }
    });
});