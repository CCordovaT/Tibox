using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Models;
using Tibox.Repository;

namespace Tibox.WebApi.Tests.MockData
{
    class MockedSupplierRepository : IRepository<Supplier>
    {
        private List<Supplier> m_suppliers;
        public MockedSupplierRepository()
        {
            var fixture = new Fixture();
            m_suppliers = fixture.CreateMany<Supplier>(30).ToList();
        }
        public bool Delete(Supplier entity)
        {
            return m_suppliers.Remove(entity);
        }

        public IEnumerable<Supplier> GetAll()
        {
            return m_suppliers;
        }

        public Supplier GetEntityById(int id)
        {
            return m_suppliers.FirstOrDefault(c => c.Id == id);
        }

        public int Insert(Supplier entity)
        {
            m_suppliers.Add(entity);
            return entity.Id;
        }

        public bool Update(Supplier entity)
        {
            var _supplier = m_suppliers.FirstOrDefault(c => c.Id == entity.Id);
            if (_supplier == null) return false;
            _supplier = entity;
            return true;
        }
    }
}
