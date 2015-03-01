'use strict'
var app = angular.module('PizzaApp');
app.factory('ordersService', function ($resource,$location,$http,base64,cookieService) {
   // var user = cookieService.get();
   // var userEncode = base64.encode(user.email+':'+user.password);
    return $resource('http://localhost:41841/api/orders/:id', {id:'@_id'}, {
        //post: { method: 'POST', params: { customerId: "@customerId", pizzaId: '@pizzaId' }, isArray: true },
        post: { method: 'POST', params: { customerId: "@customerId", pizzaId: '@pizzaId' }, isArray: true },
        makeorders: { method: 'POST', params: { idList: "@idList" },headers: {'Access-Control-Request-Headers': 'accept, origin, authorization','Authorization': getAuthHeader()} },
        put: { method: 'PUT'},
        delete: { method: 'DELETE', headers: {'Access-Control-Request-Headers': 'accept, origin, authorization','Authorization': getAuthHeader() }}
       // delete: { method: 'DELETE', headers: {'Access-Control-Request-Headers': 'accept, origin, authorization','Authorization': cookieService.getAuthHeader() }}
      //  delete: { method: 'DELETE', headers: {'Access-Control-Request-Headers': 'accept, origin, authorization','Authorization': (cookieService.get().email+':'+base64.encode(cookieService.get().password)).toString() }}
     //   delete: { method: 'DELETE', headers: {'Access-Control-Request-Headers': 'accept, origin, authorization','Authorization': 'basic ' + base64.encode(cookieService.get().email+':'+cookieService.get().password) }}
      //  delete: { method: 'DELETE', headers: {'Access-Control-Request-Headers': 'accept, origin, authorization','Authorization':'basic oLDMYrJD0Qg15Nhv7N-H6w'}}
        //delete: { method: 'DELETE', withCredentials : true},
        // headers: {'Authorization':'Bearer oLDMYrJD0Qg15Nhv7N-H6w'}
    })
    function getAuthHeader(){
        return 'basic ' + base64.encode(cookieService.get().email+':'+cookieService.get().password)
    }
});