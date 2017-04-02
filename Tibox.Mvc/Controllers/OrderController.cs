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

        //private readonly IUnitOfWork _unit;

        public OrderController(IUnitOfWork unit) : base(unit)
        {
            //_unit = new TiboxUnitOfWork();
        } 

        public ActionResult Index()
        {
            return View(_unit.Orders.GetAllEntitys());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Save(OrderViewModel model)
        {
            if (!ModelState.IsValid) return Json("Error");
            //var id = _unit.Orders.Insert(model.Order);
            //model.OrderItems.Select(oi => { oi.OrderId = id; return oi; }).ToList();
            //foreach(var orderitem in model.OrderItems)
            //{
            //    _unit.OrderItems.Insert(orderitem);
            //}
            var id = _unit.Orders.SaveOrderAndOrderItems(model.Order, model.OrderItems);
            return Json("ok");
        }       

    }
}