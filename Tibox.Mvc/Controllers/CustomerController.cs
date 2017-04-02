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
    //[ErrorHandler] YA ESTA ADMINISTRADO EN EL BASE
    [RoutePrefix("Customer")]
    public class CustomerController : BaseController
    {
        //private readonly IUnitOfWork _unit;

        public CustomerController(IUnitOfWork unit) : base(unit)
        {
            //_unit = new TiboxUnitOfWork();
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

        [Route("Count/{rows:int}")]
        public JsonResult Count(int rows)
        {
            var totalRecords = _unit.Customers.count();
            var totalPages = Math.Ceiling((decimal)totalRecords / rows);
            var page = new
            {
                totalPages = totalPages
            };
            return Json(page, JsonRequestBehavior.AllowGet);
        }

        [Route("List/{page:int}/{rows:int}")]
        public PartialViewResult List(int page, int rows)
        {

            int _nInicio = _nInicio = rows * (page - 1) + 1;
            int _nFin = _nInicio + rows - 1;

            return PartialView(_unit.Customers.ObtenerPorPagina(_nInicio, _nFin));
        }

        public JsonResult Customers()
        {
            var customers = _unit.Customers.GetAllEntitys();
            return Json(customers, JsonRequestBehavior.AllowGet);
        }

    }
}