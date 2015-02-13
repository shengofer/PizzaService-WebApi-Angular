using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using System.Net;
using System.Web.Http.Routing;
using PizzaService.Data.Entities;



namespace PizzaService.Web.Controllers
{
    public class PizzasController : BaseApiController
    {
        //
        // GET: /Pizzas/

        public List<Pizza> Get()
        {

            //ILearningRepository repository = new LearningRepository(new LearningContext());

            return TheRepository.GetAllPizza().ToList();
           /* return new Pizza[] 
            {
                  new  Pizza
                {
                    Id = 1,
                    Name = "Glenn Block",
                    Price = 23.245
                },
                new Pizza
                {
                    Id = 2,
                    Name = "Dan Roth",
                    Price = 84.23
                }
            };*/

        }

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

                if (updatedPizza == null) Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not read subject/tutor from body");

                var originalPizza = TheRepository.GetPizza(id);

                if (originalPizza == null || originalPizza.id != id)
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified, "Course is not found");
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
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Can not delete course, students has enrollments in course.");
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
