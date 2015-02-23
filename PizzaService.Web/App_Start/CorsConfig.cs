using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Thinktecture.IdentityModel.Http.Cors.WebApi;

namespace PizzaService.Web.App_Start
{
    public class CorsConfig
    {
        public static void RegisterCors(HttpConfiguration httpConfig)
        {
            WebApiCorsConfiguration corsConfig = new WebApiCorsConfiguration();

            // this adds the CorsMessageHandler to the HttpConfiguration's
            // MessageHandlers collection
            corsConfig.RegisterGlobal(httpConfig);

            // this allow all CORS requests to the Products controller
            // from the http://foo.com origin.
            corsConfig
               .ForResources("Auth")
               .ForOrigins("http://localhost:63342/")
               .AllowAll();
        }
    }
}