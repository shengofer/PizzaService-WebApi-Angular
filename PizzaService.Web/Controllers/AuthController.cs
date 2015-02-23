using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PizzaService.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Helpers;
using PizzaService.Data.Entities;


namespace PizzaService.Web.Controllers
{
 
    public class AuthController : BaseApiController
    {
        [HttpOptions]
        [HttpPost]
        [Route("signup")]
        public IHttpActionResult SignUp([FromBody] SignupCustomerModel model)
        {
           
            if (model == null || String.IsNullOrWhiteSpace(model.email))
                return BadRequest("Email Address is required.");

            if (String.IsNullOrWhiteSpace(model.displayName))
                return BadRequest("Name is required.");


         /*   if (!IsValidPassword(user.Password))
            {
                _exceptionless.CreateFeatureUsage("Invalid Password").AddTags("Signup").SetProperty("Email Address", model.Email).SetProperty("Password Length", model.Password != null ? model.Password.Length : 0).Submit();
                return BadRequest("Password must be at least 6 characters long.");
            }*/

            Customer  customer;
            try
            {
                customer = TheRepository.GetCustomerByEmail(model.email);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            if (customer != null)
                return BadRequest("A user already exists with this email address.");

            Customer newCustomer = new Customer
            {
                email = model.email,
                username = model.displayName,
                password = model.password,
                role = 1
            };

            try
            {
                if (TheRepository.InsertCustomer(newCustomer) && TheRepository.SaveAll())
                {
                    return Ok();
                }
                else
                {
                    throw new Exception();
                };
            }
            catch (Exception)
            {
                return BadRequest();
            }
       
            //return Ok();
        }

        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login([FromBody] LoginModel model)
        {
            if (model == null || String.IsNullOrWhiteSpace(model.email))
                return BadRequest("Email Address is required.");

            if (String.IsNullOrWhiteSpace(model.password))
                return BadRequest("Password is required.");

          /*  bool auth = false;
            try
            {
                auth = TheRepository.LoginCustomer(model.email, model.password);
            }
            catch (Exception)
            {
                return Unauthorized();
            }*/

            Customer customer;
            try
            {
                customer = TheRepository.GetCustomerByEmail(model.email);
            }
            catch(Exception)
            {
                return Unauthorized();
            }

            if (customer == null)
            {
                return Unauthorized();
            }

            if (!String.Equals(customer.password, model.password))
            {
                return Unauthorized();
            }

            return Ok(customer);
        }
   
    }
}
