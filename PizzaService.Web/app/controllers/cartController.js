var app = angular.module('PizzaApp');
app.controller('cartController', function($scope,ordersService, sharedProperties){
    //paging
    $scope.totalRecordsCount = 0;
    $scope.pageSize = 10;
    $scope.currentPage = 1;
    init();
    function init() {

        //  createWatche();
        getPizzaListInBucket();

        pizz = "sdfsfd";
    }

    function getPizzaListInBucket(){
        ordersService.get({customerID:sharedProperties.getUser().id,  page: $scope.currentPage-1, pageSize: $scope.pageSize},function (pizzasResult) {

            $scope.totalRecordsCount =  pizzasResult.totalCount;
            $scope.bucketList = pizzasResult.bucketList;

            pizz = "sdfsfd";

        });
    };

})