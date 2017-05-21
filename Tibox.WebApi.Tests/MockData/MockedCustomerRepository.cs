using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Models;
using Tibox.Repository.Northwind;

namespace Tibox.WebApi.Tests.MockData
{

    public class MockedCustomerRepository : ICustomerRepository
    {
        private List<Customer> customers;

        public MockedCustomerRepository()
        {
            var fixture = new Fixture();
            customers = fixture.CreateMany<Customer>(30).ToList();
        }

        public int Count()
        {
            return customers.Count;
        }

        public Customer CustomerWithOrders(int id)
        {
            return customers.FirstOrDefault(c => c.Id == id);
        }

        public bool Delete(Customer entity)
        {
            return customers.Remove(entity);
        }

        public IEnumerable<Customer> GetAll()
        {
            return customers;
        }

        public Customer GetEntityById(int id)
        {
            return customers.FirstOrDefault(c => c.Id == id);
        }

        public int Insert(Customer entity)
        {
            customers.Add(entity);
            return entity.Id;
        }

        public IEnumerable<Customer> PagedList(int startRow, int endRow)
        {
            return customers.OrderBy(c => c.Id).Skip(startRow - 1).Take(endRow - startRow);
        }

        public Customer SearchByNames(string firstName, string lastName)
        {
            return customers.FirstOrDefault(c => c.FirstName == firstName && c.LastName == lastName);
        }

        public bool Update(Customer entity)
        {
            var updateEntity = customers.FirstOrDefault(c => c.Id == entity.Id);
            if (updateEntity == null) return false;
            updateEntity = entity;
            return true;
        }
    }
}
