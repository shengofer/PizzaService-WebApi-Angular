'use strict';
var app = angular.module('PizzaApp');
app.controller('cartController', function($scope,ordersService,$location, sharedProperties, cookieService){
    //paging
    $scope.totalRecordsCount = 0;
    $scope.pageSize = 10;
    $scope.currentPage = 1;

    init();
    function init() {

        //  createWatche();
        getPizzaListInBucket();


    }

    function getPizzaListInBucket(){
        var user = cookieService.get();
        ordersService.get({customerID:user.id,  page: $scope.currentPage-1, pageSize: $scope.pageSize},function (pizzasResult) {
            for (var i = 0; i < pizzasResult.bucketList.length; i++) {

                pizzasResult.bucketList[i].image =  'http://localhost:41841/api/images/'+pizzasResult.bucketList[i].imageID;

            }

            $scope.totalPrice = pizzasResult.totalPrice;
            $scope.totalRecordsCount =  pizzasResult.totalCount;
            $scope.bucketList = pizzasResult.bucketList;




        });
    };

    $scope.makeOrder = function(){
        var idArray =[];
      //  for(var bucket in $scope.bucketList){
        for(var i=0;i<$scope.bucketList.length;i++){
            idArray.push($scope.bucketList[i].orderID);
        }
        ordersService.makeorders({idList:idArray})
      //  $route.reload();
    }

    $scope.removeOrder = function(orderID){
        ordersService.delete({id : orderID}, function(){
           // var status = responce.status;
            for(var i =0; i<$scope.bucketList.length; i++){
                var orid = $scope.bucketList[i].orderID;
                if (orid=== orderID){
                    $scope.bucketList.splice(i,1);
                }
            }
        });
    }



    $scope.isAuth = function(){
        //return sharedProperties.isAuth();

        if(cookieService.get())
            return true;
        else return  false;
    }



})