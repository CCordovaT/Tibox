using Tibox.Models;

namespace Tibox.Repositorio.Northwind
{
    public interface IOrderRepositorio: IRepositorio<Order>
    {

        Order ObtenerxOrderNumber(int CustomerId);
        Order ItemsByOrder(int CustomerId);

    }
}
