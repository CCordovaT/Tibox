using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Models;

namespace Tibox.Repositorio
{
    public interface IRepositorio<T> where T: class
    {

        int Insert(T Entity);
        bool Update(T Entity);
        bool Delete(T Entity);
        T GetEntityById(int id);
        IEnumerable<T> GetAllEntitys();

    }
}
