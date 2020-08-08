using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WpfMvvm.Business.Models;

namespace WpfMvvm.Data.Services
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly WpfMvvmDbContext context = new WpfMvvmDbContext();

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            context.Customers.Add(customer);
            await context.SaveChangesAsync();
            return customer;
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
            var customer = context.Customers.FirstOrDefault(c => c.Id == customerId);
            if (customer != null)
            {
                context.Customers.Remove(customer);
            }
            await context.SaveChangesAsync();
        }

        public void EnsureDatabaseCreated()
        {
            //context.Database.EnsureCreated();
        }

        public Task<Customer> GetCustomerAsync(int id)
        {
            return context.Customers.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<List<Customer>> GetCustomersAsync()
        {
            return context.Customers.ToListAsync();
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            if (!context.Customers.Local.Any(c => c.Id == customer.Id))
            {
                context.Customers.Attach(customer);
            }
            context.Entry(customer).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return customer;
        }
    }
}
