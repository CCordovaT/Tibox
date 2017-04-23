using System;
using System.Web.Mvc;
using Tibox.Models;
using Tibox.Mvc.FilterActions;
using Tibox.UnitOfWork;

namespace Tibox.Mvc.Controllers
{
    [RoutePrefix("Customer")]
    public class CustomerController : BaseController
    {
        public CustomerController(IUnitOfWork unit) : base(unit)
        {
        }

        public ActionResult Index()
        {
            return View(_unit.Customers.GetAll());
        }

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

        public PartialViewResult Edit(int id)
        {
            return PartialView(_unit.Customers.GetEntityById(id));
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (!ModelState.IsValid) return PartialView("Edit", customer);
            var id = _unit.Customers.Update(customer);
            return RedirectToAction("Index");
        }

        public PartialViewResult Delete(int id)
        {
            return PartialView(_unit.Customers.GetEntityById(id));
        }

        [HttpPost]
        public ActionResult Delete(Customer customer)
        {
            var id = _unit.Customers.Delete(customer);
            return RedirectToAction("Index");
        }

        public ActionResult Error()
        {
            throw new TimeZoneNotFoundException();
        }

        [Route("Count/{rows:int}")]
        public JsonResult Count(int rows)
        {
            var totalRecords = _unit.Customers.Count();
            var totalPages = totalRecords % rows != 0 ? (totalRecords / rows) + 1 : totalRecords / rows;
            var page = new
            {
                TotalPages = totalPages
            };
            return Json(page, JsonRequestBehavior.AllowGet);
        }

        [Route("List/{page:int}/{rows:int}")]
        public PartialViewResult List(int page, int rows)
        {
            var startRecord = ((page - 1) * rows) + 1;
            var endRecord = page * rows;
            return PartialView(_unit.Customers.PagedList(startRecord, endRecord));
        }

        public JsonResult Customers()
        {
            var customers = _unit.Customers.GetAll();
            return Json(customers, JsonRequestBehavior.AllowGet);
        }
    }
}