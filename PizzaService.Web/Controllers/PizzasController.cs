using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using System.Net;
using System.Web.Http.Routing;
using PizzaService.Data.Entities;
using Learning.Web.Filters;



namespace PizzaService.Web.Controllers
{
    public class PizzasController : BaseApiController
    {
        //
        // GET: /Pizzas/
       //  [LearningAuthorizeAttribute]
        public Object Get(int page = 0, int pageSize = 10)
        {
            IQueryable<Pizza> query;

            query = TheRepository.GetAllPizza().OrderBy(c => c.id);
            var totalCount = query.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var urlHelper = new UrlHelper(Request);
            var prevLink = page > 0 ? urlHelper.Link("Pizzas", new { page = page - 1, pageSize = pageSize }) : "";
            var nextLink = page < totalPages - 1 ? urlHelper.Link("Pizzas", new { page = page + 1, pageSize = pageSize }) : "";

            var results = query
                          .Skip(pageSize * page)
                          .Take(pageSize)
                          .ToList()
                          .Select(s => s);

            return new
            {
                TotalCount = totalCount,
                TotalPages = totalPages,
                PrevPageLink = prevLink,
                NextPageLink = nextLink,
                Results = results
            };

        }
      /*  public List<Pizza> Get()
        {

            return TheRepository.GetAllPizzaWithImage();

        }*/

        public HttpResponseMessage GetPizza(int id)
        {
            try
            {
                var pizza = TheRepository.GetPizza(id);
                if (pizza != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, pizza);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

       // [Learning.Web.Filters.ForceHttps()]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Pizza pizza)
        {
            try
            {
                //var result = TheRepository.insert(pizza);
                bool ins = TheRepository.InsertPizza(pizza);
                bool saveAll = TheRepository.SaveAll();
                if (ins && saveAll )
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

        [HttpPatch]
        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody] Pizza updatedPizza)
        {
            try
            {

                //var updatedCourse = TheModelFactory.Parse(courseModel);

                if (updatedPizza == null) Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not read pizza from body");

                var originalPizza = TheRepository.GetPizza(id);

                if (originalPizza == null || originalPizza.id != id)
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified, "Pizza is not found");
                }
                else
                {
                    updatedPizza.id = id;
                }

                if (TheRepository.UpdatePizza(originalPizza, updatedPizza) && TheRepository.SaveAll())
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
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
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var pizza = TheRepository.GetPizza(id);

                if (pizza == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                if (pizza.orders.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Can not delete pizza, there are orders on this pizza.");
                }

                if (TheRepository.DeletePizza(id) && TheRepository.SaveAll())
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }




    }
}
