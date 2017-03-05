using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tibox.Models;
using System.Linq;

namespace Tibox.Repositorio.Tests
{
    [TestClass]
    public class PruebaRepositorioOrder
    {

        private readonly IRepositorio<Order> _Base;
        //private readonly BaseRepositorio<Order> _Base;

        public PruebaRepositorioOrder()
        {

            _Base = new BaseRepositorio<Order>();

        }

        [TestMethod]
        public void Get_All_Order()
        {

            var _Resul = _Base.GetAllEntitys();
            Assert.AreEqual(_Resul.Count() > 0, true);

        }

        [TestMethod]
        public void Get_Order_By_Id()
        {

            var _Resul = _Base.GetEntityById(20);
            Assert.AreEqual(_Resul !=null, true);

        }

    }
}
