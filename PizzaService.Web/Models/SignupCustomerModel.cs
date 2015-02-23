using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaService.Web.Models
{
    public class SignupCustomerModel
    {

        public string displayName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}