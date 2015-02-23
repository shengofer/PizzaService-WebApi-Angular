using PizzaService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaService.Web.Helper
{
    public static class OrderHelper
    {
        public static double getTotalPriceOfOrders(List<Order> ordersList)
        {
            double totalPrice = 0;
            foreach (Order o in ordersList)
            {
                totalPrice += o.pizza.price;
            }
            return totalPrice;
        }
    }
}