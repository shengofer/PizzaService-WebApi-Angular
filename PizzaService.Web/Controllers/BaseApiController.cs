
using PizzaService.Data;
using PizzaService.Web.Models;
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
        private ModelFactory _modelFactory;

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

        protected ModelFactory TheModelFactory
        {
            get
            {
                if (_modelFactory == null)
                {
                    _modelFactory = new ModelFactory();
                }
                return _modelFactory;
            }
        }
    }
}
