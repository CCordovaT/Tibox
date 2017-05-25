using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tibox.Models;
using Tibox.UnitOfWork;

namespace Tibox.WebApi.Controllers
{
    [RoutePrefix("supplier")]
    [Authorize]
    public class SupplierController : BaseController
    {

        public SupplierController(IUnitOfWork unit) : base(unit)
        {
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            if (id <= 0) return BadRequest();
            return Ok(_unit.Suppliers.GetEntityById(id));
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Post(Supplier supplier)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var id = _unit.Suppliers.Insert(supplier);
            return Ok(id);
        }

        [Route("")]
        [HttpPut]
        public IHttpActionResult Put(Supplier supplier)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!_unit.Suppliers.Update(supplier)) return BadRequest("Incorrect id");
            return Ok(true);
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest();
            var result = _unit.Suppliers.Delete(new Supplier { Id = id });
            return Ok(true);
        }

        [HttpGet]
        [Route("list")]
        public IHttpActionResult GetList()
        {
            return Ok(_unit.Suppliers.GetAll());
        }
    }
}
