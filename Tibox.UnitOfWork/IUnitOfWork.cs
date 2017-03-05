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
    public interface IUnitOfWork
    {

        ICustomerRepositorio Customers { get; }
        IOrderRepositorio Orders { get; }
        IRepositorio<OrderItem> OrderItems { get; }
        IRepositorio<Product> Products { get; }
        IRepositorio<Supplier> Suppliers { get; }

    }
}
