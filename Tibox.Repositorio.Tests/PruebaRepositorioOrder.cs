using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tibox.Models;
using System.Linq;
using Tibox.UnitOfWork;
using Tibox.Repositorio.Northwind;

namespace Tibox.Repositorio.Tests
{
    [TestClass]
    public class PruebaRepositorioOrder
    {

        //private readonly IRepositorio<Order> _Base;
        //private readonly BaseRepositorio<Order> _Base;
        private readonly IUnitOfWork _UnitOfWork;

        public PruebaRepositorioOrder()
        {

            //_Base = new BaseRepositorio<Order>();
            _UnitOfWork = new TiboxUnitOfWork();

        }


        [TestMethod]
        public void Get_All_Orders()
        {

            var _Resul = _UnitOfWork.Orders.GetAllEntitys();
            Assert.AreEqual(_Resul.Count() > 0, true);

        }

        [TestMethod]
        public void Insert_Order()
        {

            var _Order = new Order
            {
                OrderDate = DateTime.Today,
                OrderNumber = "542402",
                CustomerId = 100,
                TotalAmount = 500
            };
            var _Resul = _UnitOfWork.Orders.Insert(_Order);
            Assert.AreEqual(_Resul > 0, true);

        }

        [TestMethod]
        public void Delete_Order()
        {

            var _Order = new Order
            {
                Id = 11
            };
            var _Resul = _UnitOfWork.Orders.Delete(_Order);
            Assert.AreEqual(_Resul, true);

        }

        [TestMethod]
        public void Get_Order_By_Id()
        {

            var _Resul = _UnitOfWork.Orders.GetEntityById(10);
            Assert.AreEqual(_Resul.Id == 10, true);

        }

        [TestMethod]
        public void Update_Order()
        {

            var _Order = new Order
            {
                Id = 14,
                OrderDate = DateTime.Today,
                OrderNumber = "542402",
                CustomerId = 61,
                TotalAmount = 888
            };
            var _Resul = _UnitOfWork.Orders.Update(_Order);
            Assert.AreEqual(_Resul, true);

        }

        [TestMethod]
        public void Get_Order_By_NumberOrder()
        {

            var _Resul = _UnitOfWork.Orders.ObtenerxOrderNumber(542398);
            Assert.AreEqual(_Resul != null, true);
            Assert.AreEqual(_Resul.Id == 21, true);

        }

        [TestMethod]
        public void Items_By_Order()
        {

            Order _Order = _UnitOfWork.Orders.ItemsByOrder(1);
            Assert.AreEqual(_Order != null, true);
            Assert.AreEqual(_Order.OrderItems.Count() > 0, true);

        }
    }
}
