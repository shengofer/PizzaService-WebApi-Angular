using Learning.Web.Filters;
using PizzaService.Data.Entities;
using PizzaService.Web.Helper;
using PizzaService.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;


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
      //  [ForceHttpsAttribute]
        [HttpGet]
        public Object Get([FromUri]int customerID,int page = 0, int pageSize = 10)
        {
            IQueryable<Order> query;

            query = TheRepository.GetPizzaCustomerOrderWithStatus(customerID,1).OrderBy(c => c.id);
            var totalCount = query.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var urlHelper = new UrlHelper(Request);
            var prevLink = page > 0 ? urlHelper.Link("Orders", new { page = page - 1, pageSize = pageSize }) : "";
            var nextLink = page < totalPages - 1 ? urlHelper.Link("Orders", new { page = page + 1, pageSize = pageSize }) : "";

            List<Order> results = query
                          .Skip(pageSize * page)
                          .Take(pageSize)
                          .Select(s=>s)
                          .ToList();

            List<BucketListModel> bucketListModel = new List<BucketListModel>();
            foreach (Order o in results)
            {
                bucketListModel.Add(TheModelFactory.CreateUserBucketList(o));
            }
 
            return new
            {
                TotalCount = totalCount,
                TotalPages = totalPages,
                PrevPageLink = prevLink,
                NextPageLink = nextLink,
                BucketList = bucketListModel,
                TotalPrice = OrderHelper.getTotalPriceOfOrders(results)
              //  Results = results
            };

        }

        [LearningAuthorizeAttribute]
        [HttpDelete]
       // [Route("delete")]
        public HttpResponseMessage removeOrder(int id)
        {
            try
            {
               // TheRepository.DeleteOrderByID(id);
           
                if ( TheRepository.DeleteOrderByID(id) && TheRepository.SaveAll())
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not save to the database.");
                }
            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Problem is occured");
            }

        }
        [LearningAuthorizeAttribute]
        [HttpPost]
       // [Route("changestatus")]
        public HttpResponseMessage makeOrder([FromUri] List<int> idList)
        {

            try
            {
                foreach (int i in idList)
                {
                Order oldOrder = TheRepository.GetOrderbyID(i);
                Order newOrder = new Order
                {
                    customer = oldOrder.customer,
                    id = oldOrder.id,
                    pizza = oldOrder.pizza,
                    activeStatus = 0
                };
                    TheRepository.UpdateOrder(oldOrder, newOrder);
                    bool b = TheRepository.SaveAll();
                }
                    return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Problem is occured");
            }
        }

        public IHttpActionResult cancelOrder([FromUri] int idOrder)
        {

            try
            {
                Order oldOrder = TheRepository.GetOrderbyID(idOrder);
                Order newOrder = oldOrder;
                newOrder.activeStatus = 1;
                TheRepository.UpdateOrder(oldOrder, newOrder);
                return Ok();
            }
            catch
            {
                return BadRequest("Something go wrong");
            }
        }

    }
}
