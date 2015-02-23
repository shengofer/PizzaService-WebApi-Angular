using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace PizzaService.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
           /* config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );*/
            config.Routes.MapHttpRoute(
                name: "Auth",
                routeTemplate: "api/auth/{action}/{id}",
                defaults: new { controller = "auth", id=RouteParameter.Optional }
               );
            config.Routes.MapHttpRoute(
              name: "Pizzas",
              routeTemplate: "api/pizzas/{id}",
              defaults: new { controller = "pizzas", id = RouteParameter.Optional }
              );

            config.Routes.MapHttpRoute(
             name: "Customers",
             routeTemplate: "api/customers/{id}",
             defaults: new { controller = "customers", id = RouteParameter.Optional }
         );

           /* config.Routes.MapHttpRoute(
              name: "Orders",
              routeTemplate: "api/customers/{customerID}/pizzas/{pizzaID}",
              defaults: new { controller = "orders", customerID = RouteParameter.Optional,pizzaID = RouteParameter.Optional}
          );*/

            config.Routes.MapHttpRoute(
              name: "Orders",
              routeTemplate: "api/orders/{orderID}",
              defaults: new { controller = "orders", orderID= RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
              name: "Images",
              routeTemplate: "api/images/{id}",
              defaults: new { controller = "images", id = RouteParameter.Optional }
          );

   


            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();

#if !DEBUG
            //force HTTPs
            config.Filters.Add(new ForceHttpsAttribute());
#endif
        }
    }
}
