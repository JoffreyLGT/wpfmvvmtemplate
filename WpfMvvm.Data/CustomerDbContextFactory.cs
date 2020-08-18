using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WpfMvvm.Data
{
    public class CustomerDbContextFactory
: IDesignTimeDbContextFactory<CustomerDbContext>
    {
        public CustomerDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CustomerDbContext>();
            optionsBuilder.UseSqlite("Data Source=customers.db");

            return new CustomerDbContext(optionsBuilder.Options);
        }
    }
}
