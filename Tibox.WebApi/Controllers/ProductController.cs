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
    [RoutePrefix("product")]    
    public class ProductController : BaseController
    {
        private readonly AbstractValidator<Product> _validator;
        public ProductController(IUnitOfWork unit, AbstractValidator<Product> validator) : base(unit)
        {

            _validator = validator;

        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            if (id <= 0) return BadRequest();
            return Ok(_unit.Products.GetEntityById(id));
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Post(Product product)
        {
            //if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = _validator.Validate(product);
            if (!result.IsValid)
            {

                return Content(HttpStatusCode.BadRequest, result.Errors);

            }

            var id = _unit.Products.Insert(product);
            return Ok(new { id = id });
        }

        [Route("")]
        [HttpPut]
        public IHttpActionResult Put(Product product)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (!_unit.Products.Update(product)) return BadRequest("Incorrect id");
            return Ok(new { status = true });
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest();
            var result = _unit.Products.Delete(new Product { Id = id });
            return Ok(new { delete = true });
        }

        [HttpGet]
        [Route("list")]
        public IHttpActionResult GetList()
        {
            return Ok(_unit.Products.GetAll());
        }

    }
}
