using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Tibox.Repositorio
{
   public class BaseRepositorio<T> : IRepositorio<T> where T : class
    {
        private readonly string _cCadenaConexion;

        public BaseRepositorio()
        {
            _cCadenaConexion = ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;
        }

        public bool Delete(T Entity)
        {
            using (SqlConnection _conn = new SqlConnection(_cCadenaConexion))
            {
                return _conn.Delete(Entity);
            }
        }

        public IEnumerable<T> GetAllEntitys()
        {
            using (SqlConnection _conn = new SqlConnection(_cCadenaConexion))
            {
                return _conn.GetAll<T>();
            }
        }

        public T GetEntityById(int id)
        {
            using (SqlConnection _conn = new SqlConnection(_cCadenaConexion))
            {
                return _conn.Get<T>(id);
            }
        }

        public int Insert(T Entity)
        {
            using (SqlConnection _conn = new SqlConnection(_cCadenaConexion))
            {
                return (int)_conn.Insert(Entity);
            }
        }

        public bool Update(T Entity)
        {
            using (SqlConnection _conn = new SqlConnection(_cCadenaConexion))
            {
                return _conn.Update(Entity);

            }
        }
    }
}
