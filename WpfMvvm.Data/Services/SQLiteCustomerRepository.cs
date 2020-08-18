using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WpfMvvm.Business.Models;

namespace WpfMvvm.Data.Services
{
    public class SQLiteCustomerRepository : ICustomerRepository
    {
        private static CustomerDbContext context;

        public SQLiteCustomerRepository()
        {
            context = new CustomerDbContextFactory().CreateDbContext(null);
            context.Database.EnsureCreated();
        }

        public Task<Customer> AddCustomerAsync(Customer customer)
        {
            return Task.Run(() =>
            {
                context.Add(customer);
                context.SaveChanges();
                return customer;
            });
        }

        public Task DeleteCustomerAsync(int customerId)
        {
            return Task.Run(() =>
            {
                var customer = context.Customers.Find(customerId);
                if (customer == null) return;

                context.Remove(customer);
                context.SaveChanges();
            });
        }

        public Task<Customer> GetCustomerAsync(int id)
        {
            return Task.Run(() => context.Customers.Find(id));
        }

        public Task<List<Customer>> GetCustomersAsync()
        {
            return Task.Run(() => context.Customers.ToList());
        }

        public Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            return Task.Run(() =>
            {
                var customerFromDb = context.Customers.Find(customer.Id);
                customerFromDb.CopyFromCustomer(customer);
                context.Update(customerFromDb);
                context.SaveChanges();
                return customer;
            });
        }
    }
}
