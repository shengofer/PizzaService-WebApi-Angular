using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaService.Data.Entities
{
    public class Pizza
    {
        public Pizza()
        {
            orders = new List<Order>();
            image = new PizzaImage();
        
        }
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public double weight { get; set; }
        //public byte[] image { get; set; }
        //public byte[] image { get; set; }'
       // public string image { get; set; }
        public PizzaImage image { get; set; }

        public ICollection<Order> orders { get; set; }

    }
}
