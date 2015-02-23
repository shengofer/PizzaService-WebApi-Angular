using PizzaService.Data.Entities;
using PizzaService.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;


namespace Learning.Web2.Controllers
{
    public class CustomersController : BaseApiController
    {
        //
        // GET: /Customers/
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Customer customer)
        {
            try
            {
                //var result = TheRepository.insert(pizza);
                bool ins = TheRepository.InsertCustomer(customer);
                bool saveAll = TheRepository.SaveAll();
                if (ins && saveAll)
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

    }

}
