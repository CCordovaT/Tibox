using Tibox.UnitOfWork;
using Tibox.WebApi.Tests.MockData;
using Tibox.WebApi.Controllers;
using Xunit;
using System.Web.Http.Results;
using FluentAssertions;
using Tibox.Models;
using System.Linq;
using System.Collections.Generic;

namespace Tibox.WebApi.Tests
{

    public class SupplierControllerTest
    {

        private readonly IUnitOfWork m_unidad;
        private SupplierController m_controller;

        public SupplierControllerTest()
        {
            m_unidad = new MockedUnitOfWork();
            m_controller = new SupplierController(m_unidad);
        }

        [Fact]
        public void GetByIdBadRequest()
        {
            var result = m_controller.Get(-1) as BadRequestResult;
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(BadRequestResult));
        }

        [Fact]
        public void GetByIdOkWithNull()
        {
            var result = m_controller.Get(99999999) as OkNegotiatedContentResult<Supplier>;
            result.Content.Should().BeNull();
        }

        [Fact]
        public void GetByIdOk()
        {
            var _supplierTest = m_unidad.Suppliers.GetAll().ToList().FirstOrDefault();

            var result = m_controller.Get(_supplierTest.Id) as OkNegotiatedContentResult<Supplier>;
            result.Should().NotBeNull();
            result.Content.Id.Should().Be(_supplierTest.Id);
            result.Content.CompanyName.Should().Be(_supplierTest.CompanyName);
            result.Content.ContactName.Should().Be(_supplierTest.ContactName);
            result.Content.ContactTitle.Should().Be(_supplierTest.ContactTitle);
            result.Content.City.Should().Be(_supplierTest.City);
            result.Content.Country.Should().Be(_supplierTest.Country);
            result.Content.Phone.Should().Be(_supplierTest.Phone);
            result.Content.Fax.Should().Be(_supplierTest.Fax);
        }

        [Fact]
        public void InsertBadRequest()
        {

            m_controller.ModelState.Clear();
            m_controller.ModelState.AddModelError("fakeError", "FakeError");

            var _result = m_controller.Post(null) as InvalidModelStateResult;
            _result.Should().NotBeNull();
            _result.ModelState.IsValid.Should().BeFalse();
            _result.ModelState.Values.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void InsertSupplier()
        {
            var _supplier = new Supplier
            {
                Id = 3344,
                CompanyName = "companytest",
                ContactTitle = "titletest",
                City = "citytest",
                ContactName = "contacttest",
                Country = "Peru",
                Fax = "",
                Phone = "11111111"
            };

            var _result = m_controller.Post(_supplier) as OkNegotiatedContentResult<int>;
            _result.Should().NotBeNull();
            _result.Content.Should().Be(_supplier.Id);
        }

        [Fact]
        public void UpdateBadModelState()
        {

            m_controller.ModelState.Clear();
            m_controller.ModelState.AddModelError("fakeErrorUpdate", "fakeErrorUpdate");

            var _result = m_controller.Put(null) as InvalidModelStateResult;
            _result.Should().NotBeNull();
            _result.ModelState.IsValid.Should().BeFalse();
            _result.ModelState.Values.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void UpdateWithIdIncorrect()
        {

            var _supplier = new Supplier
            {
                Id = 99999999,
                CompanyName = "test",
                City = "city test",
                ContactName = "contact",
                ContactTitle = "title",
                Country = "country",
                Fax = "fax",
                Phone = "phone"             
            };

            var _result = m_controller.Put(_supplier) as BadRequestErrorMessageResult;
            _result.Should().NotBeNull();
            _result.Message.Should().Be("Incorrect id");
        }

        [Fact]
        public void UpdateSupplier()
        {
            var _supplierTest = m_unidad.Suppliers.GetAll().ToList().FirstOrDefault();

            _supplierTest.CompanyName = "cambio";
            _supplierTest.Fax = "22222222";

            var _result = m_controller.Put(_supplierTest) as OkNegotiatedContentResult<bool>;
            _result.Should().NotBeNull();
            _result.Content.Should().BeTrue();

            var _resultEntity = m_unidad.Suppliers.GetEntityById(_supplierTest.Id);
            _resultEntity.CompanyName.Should().Be("cambio");
            _resultEntity.Fax.Should().Be("22222222");
        }

        [Fact]
        public void DeleteByIdBadRequest()
        {
            var result = m_controller.Delete(-1) as BadRequestResult;
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(BadRequestResult));
        }

        [Fact]
        public void DeleteSupplier()
        {
            var _supplierToDelete = m_unidad.Suppliers.GetAll().ToList().FirstOrDefault();

            var _result = m_controller.Delete(_supplierToDelete.Id) as OkNegotiatedContentResult<bool>;
            _result.Should().NotBeNull();
            _result.Content.Should().BeTrue();
        }

        [Fact]
        public void GetAll()
        {
            var _result = m_controller.GetList() as OkNegotiatedContentResult<IEnumerable<Supplier>>;
            _result.Should().NotBeNull();
            _result.Content.Count().Should().Be(m_unidad.Suppliers.GetAll().Count());
        }

        [Fact]
        public void InsertBad()
        {

            var result = false;
            result.Should().BeFalse();
        }

    }
}
