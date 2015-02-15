using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaService.Data.Entities
{
    public class PizzaImage
    {
      /*  public PizzaImage()
        {
            pizza = new Pizza();
        }*/
        public int id { get; set; }
        public String path { get; set; }

        public Pizza pizza { get; set; }
    }
}
