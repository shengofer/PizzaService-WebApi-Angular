'use strict'
var app = angular.module('PizzaApp');
app.factory('ordersService', function ($resource,$location,$http,base64,cookieService) {
    var user = cookieService.get();
    var userEncode = base64.encode(user.email+':'+user.password);
    return $resource('http://localhost:41841/api/orders/:id', {id:'@_id'}, {
        post: { method: 'POST', params: { customerId: "@customerId", pizzaId: '@pizzaId' }, isArray: true },
        put: { method: 'PUT'},
      //  delete: { method: 'DELETE', headers: {'Access-Control-Request-Headers': 'accept, origin, authorization','Authorization': (cookieService.get().email+':'+base64.encode(cookieService.get().password)).toString() }}
        delete: { method: 'DELETE', headers: {'Access-Control-Request-Headers': 'accept, origin, authorization','Authorization': 'basic ' + base64.encode(cookieService.get().email+':'+cookieService.get().password) }}
      //  delete: { method: 'DELETE', headers: {'Access-Control-Request-Headers': 'accept, origin, authorization','Authorization':'basic oLDMYrJD0Qg15Nhv7N-H6w'}}
        //delete: { method: 'DELETE', withCredentials : true},
        // headers: {'Authorization':'Bearer oLDMYrJD0Qg15Nhv7N-H6w'}
    })
/*    var delOrder = 'http://localhost:41841/api/orders/:id';
     var deleteOrder = function (idOrder) {
       // $http.defaults.headers.post["Content-Type"] = "application/json";
        $http.defaults.headers.delete["Authorization"] = "Bearer oLDMYrJD0Qg15Nhv7N-H6w";
        //   return $http.post(config.signupUrl, {displayName:user.displayName,email:user.email, password: user.password})
        return $http.delete(delOrder, idOrder)
            .then(function(response) {
                if (loginOnSignup) {

                } else if (signupRedirect) {
                    $location.path(signupRedirect);

                }
                return response;
            });
    };*/

/*    return $http.post(serviceBase, miniVenue).then(

        function (results) {
            toaster.pop('success', "Bookmarked Successfully", "Place saved to your bookmark!");
        },
        function (results) {
            if (results.status == 304)
            {
                toaster.pop('note', "Already Bookmarked",  "Already bookmarked for user: " + miniVenue.userName);
            }
            else
            {
                toaster.pop('error', "Faield to Bookmark", "Something went wrong while saving :-(");
            }


            return results;
        });*/

    //$http.defaults.headers.post["Content-Type"] = "application/json";
   // $http.defaults.headers.delete = {"Access-Control-Request-Headers": "accept, origin, authorization"}; //you probably don't need this line.  This lets me connect to my server on a different domain
   // $http.defaults.headers.delete['Authorization'] = 'Bearer oLDMYrJD0Qg15Nhv7N-H6w';
   // $resource.defaults.headers.common = {"Access-Control-Request-Headers": "accept, origin, authorization"}; //you probably don't need this line.  This lets me connect to my server on a different domain
  //  $resource.defaults.headers.common['Authorization'] = 'Bearer oLDMYrJD0Qg15Nhv7N-H6w';

 /*   $resource.defaults.headers.delete["Authorization"] = "Bearer oLDMYrJD0Qg15Nhv7N-H6w";
    return  $resource('http://localhost:41841/api/orders/:id', {id:'@_id'}, {
        post: { method: 'POST', params: { customerId: "@customerId", pizzaId: '@pizzaId' }, isArray: true },
        put: { method: 'PUT'},
        delete: { method: 'DELETE'}

    });*/
  //  $resource.defaults.headers.delete["Authorization"] = "Bearer oLDMYrJD0Qg15Nhv7N-H6w";
  // res;
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