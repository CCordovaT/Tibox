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
            var model = new OrderViewModel
            {
                Order = new Order { OrderDate = DateTime.Now },
                Customers = _unit.Customers.GetAllEntitys()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(OrderViewModel model)
        {

            if (!ModelState.IsValid) {
                model.Customers = _unit.Customers.GetAllEntitys();
                return View(model);
            } 
            var id = _unit.Orders.Insert(model.Order);
            return RedirectToAction("Index");

        }

    }
}