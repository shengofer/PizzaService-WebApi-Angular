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

                //order.customer = customer;
               // order.pizza = pizza;
                Order order = new Order
                {
                   customer = customer,
                   pizza = pizza,
                  // customer = null,
                  // pizza = null,
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
                          //.ToList()
                          .Select(s=>s)
                          .ToList();

            List<BucketListModel> bucketListModel = new List<BucketListModel>();
            foreach (Order o in results)
            {
                bucketListModel.Add(TheModelFactory.CreateUserBucketList(o));
            }
           // List<PizzaModel> pizzaList = new List<PizzaModel>();

           /* foreach(Order o in results){
                pizzaList.Add(TheModelFactory.CreatePizzaModel(o.pizza));
            }*/
            //PizzaModel pizzaModel = TheModelFactory.CreatePizzaModel()
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

       // [HttpPatch]
       // [HttpPut]
      /*  public HttpResponseMessage Put(int id, [FromBody] CourseModel courseModel)
        {
            try
            {

                var updatedCourse = TheModelFactory.Parse(courseModel);

                if (updatedCourse == null) Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not read subject/tutor from body");

                var originalCourse = TheRepository.GetCourse(id, false);

                if (originalCourse == null || originalCourse.Id != id)
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified, "Course is not found");
                }
                else
                {
                    updatedCourse.Id = id;
                }

                if (TheRepository.Update(originalCourse, updatedCourse) && TheRepository.SaveAll())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, TheModelFactory.Create(updatedCourse));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified);
                }

            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }*/


    }
}
