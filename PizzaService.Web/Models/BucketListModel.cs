using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaService.Web.Models
{
    public class BucketListModel
    {
        public int orderID { get;set; }
        public int customerID { get; set; }
        public String username { get; set; }
        public int pizzaID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public double weight { get; set; }

        public int imageID { get; set; }


    }
}