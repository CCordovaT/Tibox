using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tibox.UnitOfWork;
using Tibox.Models;
using Tibox.Mvc.FilterActions;

namespace Tibox.Mvc.Controllers
{
    [ErrorHandler]
    public class CustomerController : Controller
    {
        private readonly IUnitOfWork _unit;

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

        //public ActionResult Edit(int id)
        //{
        //    return View(_unit.Customers.GetEntityById(id));
        //}

        public PartialViewResult Edit(int id)
        {
            return PartialView(_unit.Customers.GetEntityById(id));
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {

            //if (ModelState.IsValid)
            //{
            //    if (_unit.Customers.Update(customer))
            //        return RedirectToAction("Index");
            //}
            //return View(customer);

            if (!ModelState.IsValid) return PartialView("Edit", customer);
            _unit.Customers.Update(customer);
            return RedirectToAction("Index");

        }

        public PartialViewResult delete(int id)
        {
            return PartialView(_unit.Customers.GetEntityById(id));
        }

        [HttpPost]
        public ActionResult delete(Customer customer)
        {
            if (_unit.Customers.Delete(customer)) return RedirectToAction("Index");
            return PartialView("Delete", customer);                        
        }

        public ActionResult Error()
        {
            throw new TimeZoneNotFoundException();
        }

    }
}