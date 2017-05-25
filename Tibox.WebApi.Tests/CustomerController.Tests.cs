using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Tibox.UnitOfWork;
using Tibox.WebApi.Controllers;
using Tibox.WebApi.Tests.MockData;
using System.Web.Http.Results;
using FluentAssertions;
using Tibox.Models;
using System.Linq;

namespace Tibox.WebApi.Tests
{
    public class CustomerControllerTest
    {
        private readonly IUnitOfWork _unit;
        private CustomerController _customerController;

        public CustomerControllerTest()
        {
            _unit = new MockedUnitOfWork();
            _customerController = new CustomerController(_unit);
        }

        [Fact]
        public void GetByIdBadRequest()
        {
            var result = _customerController.Get(-1) as BadRequestResult;
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(BadRequestResult));
        }

        [Fact]
        public void GetByIdOkWithNull()
        {
            var result = _customerController.Get(99999999) as OkNegotiatedContentResult<Customer>;
            result.Content.Should().BeNull();            
        }

        [Fact]
        public void GetByIdOkResult()
        {
            var customerToValidate = _unit.Customers.GetAll().ToList().FirstOrDefault();

            var result = _customerController.Get(customerToValidate.Id) as OkNegotiatedContentResult<Customer>;
            result.Should().NotBeNull();
            result.Content.Id.Should().Be(customerToValidate.Id);
            result.Content.City.Should().Be(customerToValidate.City);
            result.Content.Country.Should().Be(customerToValidate.Country);
            result.Content.FirstName.Should().Be(customerToValidate.FirstName);
            result.Content.LastName.Should().Be(customerToValidate.LastName);
            result.Content.Phone.Should().Be(customerToValidate.Phone);
        }

        [Fact]
        public void InsertBadRequest()
        {

            _customerController.ModelState.Clear();
            _customerController.ModelState.AddModelError("fakeError", "FakeError");

            var _result = _customerController.Post(null) as InvalidModelStateResult;
            _result.Should().NotBeNull();
            _result.ModelState.IsValid.Should().BeFalse();
            _result.ModelState.Values.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void InsertCustomer()
        {
            var _customer = new Customer
            {
                Id = 8754,
                FirstName = "malo",
                LastName = "proxy",
                City = "cuty",
                Country = "onntry",
                Phone = "phone1"
            };

            var _result = _customerController.Post(_customer) as OkNegotiatedContentResult<int>;
            _result.Should().NotBeNull();
            _result.Content.Should().Be(_customer.Id);
        }

    }
}
