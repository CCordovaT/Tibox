using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Tibox.Models;

namespace Tibox.Repositorio.Tests
{
    [TestClass]
    public class PruebaRepositorioCustomer
    {
        private readonly IRepositorio<Customer> _Repositorio;

        public PruebaRepositorioCustomer()
        {
            _Repositorio = new BaseRepositorio<Customer>();
        }

        [TestMethod]
        public void Get_All_Customers()
        {

            var _Resul = _Repositorio.GetAllEntitys();
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
            var _Resul = _Repositorio.Insert(_Customer);
            Assert.AreEqual(_Resul > 0, true);
        }

        [TestMethod]
        public void Delete_Customer()
        {

            var _Customer = new Customer
            {
                Id = 93
            };
            var _Resul = _Repositorio.Delete(_Customer);
            Assert.AreEqual(_Resul, true);

        }

        [TestMethod]
        public void Get_Customer_By_Id()
        {

            var _Resul = _Repositorio.GetEntityById(94);
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
            var _Resul = _Repositorio.Update(_Customer);
            Assert.AreEqual(_Resul, true);

        }

    }
}
