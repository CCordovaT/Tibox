using System.Collections.Generic;
using Tibox.Models;

namespace Tibox.Repository
{
    public interface IRepository<T> where T: class
    {
        int Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        T GetEntityById(int id);
        IEnumerable<T> GetAll();        
    }
}
