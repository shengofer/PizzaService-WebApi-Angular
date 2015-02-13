using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaService.Data.Entities
{
    public class Customer
    {
        public Customer()
        {
            orders = new List<Order>();
        }
        public int id { get; set; }
        public int role { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }

        public ICollection<Order> orders{ get; set; }
    }
}
