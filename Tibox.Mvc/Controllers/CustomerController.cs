using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tibox.UnitOfWork;
using Tibox.Models;

namespace Tibox.Mvc.Controllers
{
    public class CustomerController : Controller
    {
        private readonly TiboxUnitOfWork _unit;

        public CustomerController()
        {
            _unit = new TiboxUnitOfWork();
        }

        // GET: Customer
        public ActionResult Index()
        {
            return View(_unit.Customers.GetAllEntitys());
        }

        //public ActionResult Create()
        //{
        //    return View();
        //}
        public PartialViewResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {

            if (!ModelState.IsValid) return PartialView("Create", customer);
            var id = _unit.Customers.Insert(customer);
            return RedirectToAction("Index");

        }

        public ActionResult Edit(int id)
        {
            return View(_unit.Customers.GetEntityById(id));
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {

            if (ModelState.IsValid)
            {
                if (_unit.Customers.Update(customer))
                    return RedirectToAction("Index");
            }
            return View(customer);

        }

        public ActionResult delete(int id)
        {
            return View(_unit.Customers.GetEntityById(id));
        }

        [HttpPost]
        public ActionResult delete(Customer customer)
        {
            if (_unit.Customers.Delete(customer)) return RedirectToAction("Index");
            return View(customer);                        
        }

    }
}