using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Models;
using Tibox.Repository;
using Tibox.Repository.Northwind;
using Tibox.UnitOfWork;

namespace Tibox.WebApi.Tests.MockData
{
    public class MockedUnitOfWork : IUnitOfWork
    {

        public MockedUnitOfWork()
        {
            Customers = new MockedCustomerRepository();
        }
        public ICustomerRepository Customers { get; private set; }
        public IOrderRepository Orders { get; private set; }
        public IRepository<OrderItem> OrderItems { get; private set; }
        public IRepository<Product> Products { get; private set; }
        public IRepository<Supplier> Suppliers { get; private set; }
        public IUserRepository Users { get; private set; }

        public void Dispose()
        {
            this.Dispose();
        }

    }
}
