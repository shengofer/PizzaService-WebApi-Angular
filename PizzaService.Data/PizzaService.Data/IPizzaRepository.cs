using PizzaService.Data.Entities;
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
        bool LoginCustomer(string userName, string password);
        bool InsertCustomer(Customer customer);

        Customer GetCustomer(int customerId);
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

        // Order
        IQueryable<Order> GetPizzaActiveOrder();

        bool InsertOrder(Order order);
        //bool AddtoBucket(int customerID, int pizzaID);

        bool UpdateOrder(Order originOrder, Order updatedOrder);
        //bool MakeStatusOrderPending(int customerID);
       // bool ChangeStatusFromPendingToFinish(int orderID);

        bool CleanBucket(int customerID);

        bool SaveAll();
    }
}
