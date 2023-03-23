using Bank.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace Bank.Repository
{
    public class BankDbContext : DbContext
    {
        public BankDbContext(DbContextOptions<BankDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<BaseDeposit> BaseDeposits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasMany(x => x.Deposits)
                .WithOne().HasForeignKey(deposit => deposit.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Customer>().Property(name => name.Name).IsRequired().HasMaxLength(15);
            modelBuilder.Entity<Customer>().HasIndex(phone => phone.PhoneNumber).IsUnique();
            modelBuilder.Entity<Customer>().HasIndex(mail => mail.Mail).IsUnique();
        }
    }
}