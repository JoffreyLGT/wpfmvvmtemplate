using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using WpfMvvm.Business.Models;

namespace WpfMvvm.Data
{
    public class WpfMvvmDbContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=WpfMvvmTemplate.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customers");
        }
    }
}
