using PizzaService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;


namespace PizzaService.Web.Controllers
{
    public class OrdersController : BaseApiController
    {
        //
        // GET: /Orders/
        [HttpPost]
        public HttpResponseMessage Post([FromUri] int customerId, [FromUri] int pizzaId)
        {
            try
            {
                var customer = TheRepository.GetCustomer(customerId);
                var pizza = TheRepository.GetPizza(pizzaId);

                if (customer == null) return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not find Customer");
                if (pizza == null) return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not find Pizza");

                //order.customer = customer;
               // order.pizza = pizza;
                Order order = new Order
                {
                    customer = customer,
                    pizza = pizza,
                    activeStatus = 1
                };
                

             try
                {
                   // bool ins = TheRepository.InsertOrder(order);
                   // bool saveAll = TheRepository.SaveAll();
                    if (TheRepository.InsertOrder(order) && TheRepository.SaveAll())
                    {
                        return Request.CreateResponse(HttpStatusCode.Created);
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not save to the database.");
                    }
                }
            catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }               
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
