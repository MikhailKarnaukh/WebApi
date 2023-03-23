using Bank.Repository.Interfaces;
using Bank.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;

namespace Bank.Repository.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BankDbContext _bankDbContext;
        private readonly ILogger<CustomerRepository> _logger;

        public CustomerRepository(BankDbContext bankDb, ILogger<CustomerRepository> externalLogger)
        {
            _bankDbContext = bankDb;
            _logger = externalLogger;
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            _logger.LogInformation("Log from Repository");
            var customer = await _bankDbContext.Set<Customer>().Include(x=>x.Deposits).FirstOrDefaultAsync(customer => customer.Id == id);
            //customer.Deposits = await _bankDbContext.Set<BaseDeposit>().Where(deposit => deposit.CustomerId == id).ToListAsync();
            return customer;
        }
        public async Task<List<Customer>> GetCustomersAsync()
        {
            var customers = await _bankDbContext.Set<Customer>().ToListAsync();
            return customers;
        }
        public async Task AddCustomerAsync(Customer customer)
        {
            await _bankDbContext.Set<Customer>().AddAsync(customer);
            await _bankDbContext.SaveChangesAsync();
        }
        public async Task UpdateCustomerAsync(Customer customer)
        {
            var needToUpdate = await _bankDbContext.Set<Customer>().FirstOrDefaultAsync(x => x.Id == customer.Id);
            _bankDbContext.Entry(needToUpdate).State = EntityState.Detached;
            needToUpdate = customer;
            _bankDbContext.Update(needToUpdate);
            await _bankDbContext.SaveChangesAsync();
        }
        public async Task DeleteCustomerAsync(int id)
        {
            var customer = await _bankDbContext.Customers.FindAsync(id);
            var baseDeposits = await _bankDbContext.BaseDeposits.Where(d => d.CustomerId == id).ToListAsync();
            _bankDbContext.Customers.Remove(customer);
            await _bankDbContext.SaveChangesAsync();
        }
    }
}
