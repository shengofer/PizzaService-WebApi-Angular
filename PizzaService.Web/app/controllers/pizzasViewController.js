'use strict';
var app = angular.module('PizzaApp');
app.controller('pizzasViewController', function ($scope,pizzasViewService, pizzaImagesService, $filter, $modal, sharedProperties,ordersService,cookieService) {

    //paging
    $scope.totalRecordsCount = 0;
    $scope.pageSize = 10;
    $scope.currentPage = 1;
   // $scope.pizzas = null;
    init();
    function init() {
      //  createWatche();
            getPlaces();
    }

    $scope.isAuth = function(){
        //return sharedProperties.isAuth();

        if(cookieService.get())
            return true;
        else return  false;
    }


    function getPlaces() {


       pizzasViewService.get({ page: $scope.currentPage-1, pageSize: $scope.pageSize},function (pizzasResult) {

           for (var i = 0; i < pizzasResult.results.length; i++) {
               pizzasResult.results[i].image =  'http://localhost:41841/api/images/'+pizzasResult.results[i].id;

           }
           $scope.totalRecordsCount =  pizzasResult.totalCount;
           $scope.pizzas = pizzasResult.results;

        });
    };

    $scope.pageChanged = function (page) {
        $scope.currentPage = page;
        getPlaces();
    };

    $scope.doSearch = function () {
        $scope.currentPage = 1;
        getPlaces();
    };

    function getImages(){
       for (var i = 0; i < $scope.pizzas.length; i++) {
            $scope.pizzas[i].image ='app/image/HamAndMushrooms.png';
        }
    }
     $scope.addToBucket = function (pizza){
         var custId = cookieService.get().id;
         var pizzaId = pizza.id;
         //ordersService.post({ customerId: customerId, pizzaId: pizzaId})
        ordersService.post({customerId: custId, pizzaId:pizzaId});
    }

});


