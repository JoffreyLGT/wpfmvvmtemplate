using Microsoft.EntityFrameworkCore;
using WpfMvvm.Business.Models;

namespace WpfMvvm.Data
{
    public class CustomerDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=customers.db");
        }
    }
}
