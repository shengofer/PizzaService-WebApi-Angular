var app = angular.module('PizzaApp');
app.controller('pizzaImagesController',function($scope,pizzaImagesService){

    function getImages(){
        //image = pizzaImagesService.get({id:2})
        for (i = 0; i < $scope.pizzas.length; i++) {
            $scope.pizzas[i].image ='app/image/HamAndMushrooms.png';
        }
        // $scope.pizzas
        /*    for (pizza in $scope.pizzas){
         pizza.image = pizzaImagesService.get({id:pizza.id})
         }*/
    }
});
