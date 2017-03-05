using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Models;
using Tibox.Repositorio;
using Tibox.Repositorio.Northwind;

namespace Tibox.UnitOfWork
{
    public class TiboxUnitOfWork : IUnitOfWork, IDisposable
    {

        public TiboxUnitOfWork()
        {
            Customers = new CustomerRepositorio();
            Orders = new BaseRepositorio<Order>();
            OrderItems = new BaseRepositorio<OrderItem>();
            Products = new BaseRepositorio<Product>();
            Suppliers = new BaseRepositorio<Supplier>();
        }

        public void Dispose() { Dispose(); }
        public ICustomerRepositorio Customers { get; private set; }
        public IRepositorio<Order> Orders { get; private set; }
        public IRepositorio<OrderItem> OrderItems { get; private set; }
        public IRepositorio<Product> Products { get; private set; }
        public IRepositorio<Supplier> Suppliers { get; private set; }

    }
}
