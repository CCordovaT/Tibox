using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Models;

namespace Tibox.Repositorio.Northwind
{
    public class OrderRepositorio : BaseRepositorio<Order>, IOrderRepositorio
    {
        public Order ObtenerxOrderNumber(int pnOrderNumber)
        {
            using (var _conn = new SqlConnection(_cCadenaConexion))
            {

                var parameters = new DynamicParameters();
                parameters.Add("@nOrderNumber", pnOrderNumber);

                return _conn.QueryFirst<Order>("[dbo].[OrderObtenerxOrderNumber]", parameters, commandType: System.Data.CommandType.StoredProcedure);

            }
        }

        public Order ItemsByOrder(int pnID)
        {
            using (var _conn = new SqlConnection(_cCadenaConexion))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@nId", pnID);

                using (var multiple = _conn.QueryMultiple("[dbo].[OrderObtenerItemsxId]", parameters, commandType: System.Data.CommandType.StoredProcedure))
                {
                    var order = multiple.Read<Order>().Single(); //Single permite indicar cual es el principal
                    order.OrderItems = multiple.Read<OrderItem>();
                    return order;
                }
            }
        }

        public bool SaveOrderAndOrderItems(Order order, IEnumerable<OrderItem> items)
        {
            using (var _conn = new SqlConnection(_cCadenaConexion))
            {
                _conn.Open();
                using(var transaction = _conn.BeginTransaction())
                {

                    try
                    {
                        var id = (int)_conn.Insert(order, transaction);
                        foreach(var orderItem in items)
                        {

                            orderItem.OrderId = id;
                            _conn.Insert(order, transaction);

                        }
                        transaction.Commit();
                        return true;

                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }

                }
                return false;
            }
        }
    }
}
