using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tibox.UnitOfWork;

namespace Tibox.WebApi.Controllers
{

    public class BaseController : ApiController
    {
        protected readonly IUnitOfWork _unit;
        public BaseController(IUnitOfWork unit)
        {
            _unit = unit;
        }
    }
}
