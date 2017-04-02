using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tibox.UnitOfWork;

namespace Tibox.Mvc.Controllers
{
    public class ProductController : BaseController
    {

        public ProductController(IUnitOfWork unit): base(unit)
        {

        }
        
        public JsonResult Products()
        {
            var products = _unit.Products.GetAllEntitys();
            return Json(products, JsonRequestBehavior.AllowGet);
        }

    }
}