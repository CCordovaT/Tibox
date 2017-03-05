using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Tibox.Models;
using Tibox.Repositorio.Northwind;
using Tibox.UnitOfWork;

namespace Tibox.Repositorio.Tests
{
    [TestClass]
    public class PruebaRepositorioCustomer
    {
        //private readonly IRepositorio<Customer> _Repositorio;
        //private readonly ICustomerRepositorio _Repositorio;
        private readonly IUnitOfWork _UnitOfWork;

        public PruebaRepositorioCustomer()
        {
            //_Repositorio = new BaseRepositorio<Customer>();
            //_Repositorio = new CustomerRepositorio();
            _UnitOfWork = new TiboxUnitOfWork();
        }

        [TestMethod]
        public void Get_All_Customers()
        {

            var _Resul = _UnitOfWork.Customers.GetAllEntitys();
            Assert.AreEqual(_Resul.Count() > 0, true);

        }

        [TestMethod]
        public void Insert_Customer()
        {

            var _Customer = new Customer
            {
                FirstName = "Christian",
                LastName = "Cordova",
                City = "Lima",
                Country = "Peru",
                Phone = "111-2233"
            };
            var _Resul = _UnitOfWork.Customers.Insert(_Customer);
            Assert.AreEqual(_Resul > 0, true);
        }

        [TestMethod]
        public void Delete_Customer()
        {

            var _Customer = new Customer
            {
                Id = 93
            };
            var _Resul = _UnitOfWork.Customers.Delete(_Customer);
            Assert.AreEqual(_Resul, true);

        }

        [TestMethod]
        public void Get_Customer_By_Id()
        {

            var _Resul = _UnitOfWork.Customers.GetEntityById(94);
            Assert.AreEqual(_Resul.Id == 94, true);

        }

        [TestMethod]
        public void Update_Customer()
        {

            var _Customer = new Customer
            {
                Id = 94,
                FirstName = "Christian",
                LastName = "Torres",
                City = "Lima",
                Country = "Peru",
                Phone = "121-2233"
            };
            var _Resul = _UnitOfWork.Customers.Update(_Customer);
            Assert.AreEqual(_Resul, true);

        }

        [TestMethod]
        public void Get_Customer_By_Name()
        {

            var _Resul = _UnitOfWork.Customers.ObtenerxNombre("Hanna", "Moos");
            Assert.AreEqual(_Resul != null, true);
            Assert.AreEqual(_Resul.Id == 6, true);

        }

        [TestMethod]
        public void Customer_With_Orders()
        {

            Customer _customer = _UnitOfWork.Customers.CustomerWithOrders(85);
            Assert.AreEqual(_customer != null, true);
            Assert.AreEqual(_customer.Orders.Any(), true);

        }

    }
}
