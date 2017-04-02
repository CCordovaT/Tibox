using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Models;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;

namespace Tibox.Repositorio.Northwind
{
    public class CustomerRepositorio : BaseRepositorio<Customer>, ICustomerRepositorio
    {

        //private readonly string _cCadenaConexion;

        //public CustomerRepositorio()
        //{
        //    _cCadenaConexion = ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;
        //}

        public Customer ObtenerxNombre(string pcFirstName, string pcLastName)
        {
            using(var _conn = new SqlConnection(_cCadenaConexion))
            {

                var parameters = new DynamicParameters();
                parameters.Add("@cFirstName", pcFirstName);
                parameters.Add("@cLastName", pcLastName);

                return _conn.QueryFirst<Customer>("dbo.CustomerObtenerxNombre", parameters, commandType: System.Data.CommandType.StoredProcedure);

            }
        }

        public Customer CustomerWithOrders(int id)
        {
            using (var _conn = new SqlConnection(_cCadenaConexion))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CustomerID", id);

                using (var multiple = _conn.QueryMultiple("dbo.CustomerWithOrders", parameters, commandType: System.Data.CommandType.StoredProcedure))
                {
                    var customer = multiple.Read<Customer>().Single(); //Single permite indicar cual es el principal
                    customer.Orders = multiple.Read<Order>();
                    return customer;
                }
            }
        }

        public IEnumerable<Customer> ObtenerPorPagina(int pnStar, int pnFinal)
        {
            using (var _conn = new SqlConnection(_cCadenaConexion))
            {

                var parameters = new DynamicParameters();
                parameters.Add("@startRow", pnStar);
                parameters.Add("@endRow", pnFinal);

                return _conn.Query<Customer>("[dbo].[usp_CustomerPagedList]", parameters, commandType: System.Data.CommandType.StoredProcedure);

            }
        }

        public int count()
        {

            using (var _conn = new SqlConnection(_cCadenaConexion))
            {
                return _conn.ExecuteScalar<int>("SELECT COUNT(id) FROM dbo.Customer");
            }

        }

    }
}
