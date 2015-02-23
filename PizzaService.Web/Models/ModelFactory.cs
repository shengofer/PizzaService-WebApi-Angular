using PizzaService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaService.Web.Models
{
    public class ModelFactory
    {
        public PizzaModel CreatePizzaModel(Pizza pizza)
        {
            return new PizzaModel()
            {
               // Url = _UrlHelper.Link("Students", new { userName = student.UserName }),
               

                id = pizza.id,
                description = pizza.description,
                name = pizza.name,
                price = pizza.price,
                weight = pizza.weight
                
            };
        }

        public BucketListModel CreateUserBucketList(Order order)
        {
            return new BucketListModel()
            {
                customerID = order.customer.id,
                description = order.pizza.description,
                imageID = order.pizza.imageID,
                name = order.pizza.name,
                orderID = order.id,
                pizzaID = order.pizza.id,
                price = order.pizza.price,
                username = order.customer.username,
                weight = order.pizza.weight
            };
        }
    }
}