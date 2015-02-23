using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaService.Web.Models
{
    public class PizzaModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public double weight { get; set; }

        public int imageID { get; set; }

    }
}