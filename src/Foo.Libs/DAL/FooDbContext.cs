using Foo.Domain.Accounts;
using Foo.Domain.Customers;
using Microsoft.EntityFrameworkCore;

namespace Foo.DAL
{
    public class FooDbContext : DbContext
    {
        public FooDbContext(DbContextOptions<FooDbContext> options) : base(options)
        {
        }
        
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //todo
            modelBuilder.Entity<Account>().HasKey(x => x.Id);
            modelBuilder.Entity<Account>().Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Customer>().HasKey(x => x.Id);
            modelBuilder.Entity<Customer>().Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}
