using PizzaService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaService.Data
{
    public class PizzaRepository : IPizzaRepository
    {
        private PizzaContext _ctx;
        public PizzaRepository(PizzaContext ctx)
        {
            _ctx = ctx;
        }

        //Customer
        public bool LoginCustomer(string username, string password)
        {
            var customer = _ctx.Customers.Where(s => s.username == username).SingleOrDefault();

            if (customer != null)
            {
                if (customer.password == password)
                {
                    return true;
                }
            }

            return false;

        }
        public bool InsertCustomer(Customer customer)
        {
            try
            {
                _ctx.Customers.Add(customer);
                return true;
            }
            catch
            {
                return false;
            }
        }
     //   bool update(Customer originalStudent, Customer updatedStudent)


        /*public bool DeleteCustomer(int id)
        {
            try
            {
                var entity = _ctx.Customers.Find(id);
                if (entity != null)
                {
                    _ctx.Customers.Remove(entity);
                    return true;
                }
            }
            catch
            {
                // TODO Logging
            }

            return false;
        }*/
        public Customer GetCustomer(int customerId)
        {
            return _ctx.Customers.Find(customerId);
        }

        //Pizza
        public bool InsertPizza(Pizza pizza) 
        {
            try
            {
                _ctx.Pizzas.Add(pizza);
              //  _ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdatePizza(Pizza originalPizza, Pizza updatedPizza)
        {
            _ctx.Entry(originalPizza).CurrentValues.SetValues(updatedPizza);
            //To update child entites in Pizza entity


            return true;
        }
        public bool DeletePizza(int id)
        {
            try
            {
                var entity = _ctx.Pizzas.Find(id);
                if (entity != null)
                {
                    _ctx.Pizzas.Remove(entity);
                    return true;
                }
            }
            catch
            {
                // TODO Logging
            }

            return false;
        }

        public Pizza GetPizza(int pizzaId)
        {
            return _ctx.Pizzas.Find(pizzaId);
        }

        public IQueryable<Pizza> GetAllPizza()
        {
            return _ctx.Pizzas
                .AsQueryable();
        }

        public IQueryable<Pizza> GetPizzaInCustomerBucket(int customerID)
        {
            return _ctx.Pizzas
                    .Include("Orders")
                    .Where(c => c.orders.Any(s => s.customer.id == customerID && s.activeStatus==1))
                    .AsQueryable();
        }

        public IQueryable<Order> GetPizzaActiveOrder()
        {
            return _ctx.Orders
                .Where(c => c.activeStatus == 2)
                .AsQueryable();
        }

        public bool InsertOrder(Order order)
        {
            try
            {
                _ctx.Orders.Add(order);
                //  _ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool UpdateOrder(Order originOrder, Order updatedOrder)
        {
            _ctx.Entry(originOrder).CurrentValues.SetValues(updatedOrder);
            return true;
        
        }

        public bool CleanBucket(int customerID)
        {

            var orders = _ctx.Orders
                .Where(c => c.customer.id == customerID && c.activeStatus == 1);
            try
            {
                foreach (Order o in orders)
                {
                    _ctx.Orders.Remove(o);
                }
            }
            catch
            {
                // TODO Logging
            }

            return false;
        }  
           
                
     

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
