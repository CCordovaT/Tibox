using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tibox.Models;
using Tibox.Mvc.Models;
using Tibox.UnitOfWork;

namespace Tibox.Mvc.Controllers
{
    public class OrderController : BaseController
    {
        public OrderController(IUnitOfWork unit) : base(unit)
        {
        }

        public ActionResult Index()
        {
            return View(_unit.Orders.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Save(OrderViewModel model)
        {
            if (!ModelState.IsValid) return Json("Error");
            _unit.Orders.SaveOrderAndOrderItems(model.Order, model.OrderITems);
            return Json("ok");
        }                
    }
}