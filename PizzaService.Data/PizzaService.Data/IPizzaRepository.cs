﻿using PizzaService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaService.Data
{
    public interface IPizzaRepository
    {


        //Customer
        bool LoginCustomer(string email, string password);
        bool InsertCustomer(Customer customer);

        Customer GetCustomer(int customerId);
        Customer GetCustomerByEmail(String email);
        // bool update(Customer originalCustomer, Customer updatedCustomer);
        //bool deleteCustomer(int id);

       // int makeOrder(int customerId, int pizzaId, Order order);

        //Pizza
        bool InsertPizza(Pizza pizza);
        bool UpdatePizza(Pizza originalPizza, Pizza updatedPizza);

        bool DeletePizza(int id);

        Pizza GetPizza(int pizzaId);
       // bool deletePizza(int id);
        IQueryable<Pizza> GetPizzaInCustomerBucket(int customerID);
       
        IQueryable<Pizza> GetAllPizza();
        List<Pizza> GetAllPizzaWithImage();
        // Order

        Order GetOrderbyID(int idOrder);
        IQueryable<Order> GetPizzaActiveOrder();

        bool InsertOrder(Order order);
        //bool AddtoBucket(int customerID, int pizzaID);

        bool UpdateOrder(Order originOrder, Order updatedOrder);
        bool DeleteOrderByID(int idOrder);
        //bool MakeStatusOrderPending(int customerID);
       // bool ChangeStatusFromPendingToFinish(int orderID);
        
        bool CleanBucket(int customerID);
        IQueryable<Order> GetPizzaCustomerOrderWithStatus(int customerID, int activeStatus);
        bool SaveAll();

        // Image
        String GetPizzaImagePathByPizzaId(int pizzaID);
    }
}
