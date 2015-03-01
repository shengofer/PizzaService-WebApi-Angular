'use strict';
var app = angular.module('PizzaApp');
app.controller('pizzaImagesController',function($scope,pizzaImagesService){

    function getImages(){
        //image = pizzaImagesService.get({id:2})
        for (var i = 0; i < $scope.pizzas.length; i++) {
            $scope.pizzas[i].image ='app/image/HamAndMushrooms.png';
        }
    }
});
