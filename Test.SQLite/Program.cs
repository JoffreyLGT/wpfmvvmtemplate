using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WpfMvvm.Business.Models;
using WpfMvvm.Data.Services;

namespace Test.SQLite
{
    class Program
    {
        static void Main(string[] args)
        {
            //ICustomerRepository repo = new CustomerRepository();
            //repo.EnsureDatabaseCreated();
            //var customeers = repo.GetCustomersAsync().Result;
            using (var context = new TestDbContext())
            {
                context.Database.Migrate();
                var customer = new Customer
                {
                    Id = 1,
                    FirstName = "Elizabeth",
                    LastName = "Lincoln",
                };

                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }
    }
}
