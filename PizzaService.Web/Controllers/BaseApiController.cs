
using PizzaService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace PizzaService.Web.Controllers
{
    public class BaseApiController : ApiController
    {
        private IPizzaRepository _repo;

        protected IPizzaRepository TheRepository
        {
            get
            {
                if (_repo == null)
                {
                    _repo = new PizzaRepository(new PizzaContext());
                }
                
                return _repo;
            }
        }
    }
}
