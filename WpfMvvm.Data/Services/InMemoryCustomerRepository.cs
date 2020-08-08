using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMvvm.Business.Models;

namespace WpfMvvm.Data.Services
{
    public class InMemoryCustomerRepository : ICustomerRepository
    {
        private List<Customer> customers = new List<Customer>() {
            new Customer { Id = 1, Reference = 1233224, FirstName = "Jean", LastName = "DUPOND" },
            new Customer { Id = 2, Reference = 2233442, FirstName = "Charles", LastName = "MARTIN" }
        };
        public Task<Customer> AddCustomerAsync(Customer customer)
        {
            customers.Sort((a, b) => a.Id - b.Id);
            customer.Id = customers.Count > 0 ? customers.Last().Id + 1 : 0;
            customers.Add(customer);
            return Task.Run(() => customer);
        }

        public Task DeleteCustomerAsync(int customerId)
        {
            return Task.Run(() => customers.Remove(customers.Find(c => c.Id == customerId)));
        }

        public void EnsureDatabaseCreated()
        {
            // Do nothing since we are working in memory.
        }

        public Task<Customer> GetCustomerAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetCustomersAsync()
        {
            return Task.Run(() => customers);
        }

        public Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            var i = customers.FindIndex(cust => cust.Id == customer.Id);
            customers[i] = new Customer(customer);
            return Task.Run(() => customers[i]);
        }
    }
}
