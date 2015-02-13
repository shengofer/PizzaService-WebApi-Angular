using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaService.Data.Entities
{
    public class Order
    {
        public Order()
        {
            customer = new Customer();
            pizza = new Pizza();
           // pizzas = new List<Pizza>();
        }

        public int id { get; set; }
        public int activeStatus { get; set; }
        public Customer customer { get; set; }
       // public Pizza Course { get; set; }
        public Pizza pizza{ get; set; }
    }
}
