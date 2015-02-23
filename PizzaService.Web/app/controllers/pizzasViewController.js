
var app = angular.module('PizzaApp');
app.controller('pizzasViewController', function ($scope,pizzasViewService, pizzaImagesService, $filter, $modal, sharedProperties,ordersService) {

    //paging
    $scope.totalRecordsCount = 0;
    $scope.pageSize = 10;
    $scope.currentPage = 1;
    init();
    function init() {

      //  createWatche();
        getPlaces();

        pizz = "sdfsfd";
    }

    $scope.isAuth = function(){
        return sharedProperties.isAuth();
    }


    function getPlaces() {


       pizzasViewService.get({ page: $scope.currentPage-1, pageSize: $scope.pageSize},function (pizzasResult) {

           for (i = 0; i < pizzasResult.results.length; i++) {

               pizzasResult.results[i].image =  'http://localhost:41841/api/images/'+pizzasResult.results[i].id;

           }

           $scope.totalRecordsCount =  pizzasResult.totalCount;
           $scope.pizzas = pizzasResult.results;
           pizz = "sdfsfd";

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
       for (i = 0; i < $scope.pizzas.length; i++) {
            $scope.pizzas[i].image ='app/image/HamAndMushrooms.png';
        }

    }

     $scope.addToBucket = function (pizza){
         var custId = sharedProperties.getUser().id;
         var pizzaId = pizza.id;
         //ordersService.post({ customerId: customerId, pizzaId: pizzaId})
        ordersService.post({customerId: custId, pizzaId:pizzaId});
    }

});


