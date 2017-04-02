using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Models;

namespace Tibox.Repositorio.Northwind
{
    public interface ICustomerRepositorio: IRepositorio<Customer>
    {

        Customer ObtenerxNombre(string pcFirstName, string pcLastName);
        Customer CustomerWithOrders(int id);
        IEnumerable<Customer> ObtenerPorPagina(int pnStart, int pnFinal);
        int count();
    }
}
