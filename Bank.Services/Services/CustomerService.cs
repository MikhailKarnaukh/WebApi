using Bank.Repository.Interfaces;
using Bank.Repository.Models;
using Bank.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Bank.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(ICustomerRepository externalRepository, ILogger<CustomerService> externalLogger)
        {
            _repository = externalRepository;
            _logger = externalLogger;
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            _logger.LogInformation("Log from Service start");
            var customer = await _repository.GetCustomerAsync(id);
            _logger.LogInformation("Log from Service finish");
            return customer;
        } 
        public async Task UpdateCustomerAsync(Customer customer)
        {
            await _repository.UpdateCustomerAsync(customer);
        }
        public async Task<List<Customer>> GetCustomersAsync()
        {
            var customers = await _repository.GetCustomersAsync();
            return customers;
        }
        public async Task AddCustomerAsync(Customer customer)
        {
            await _repository.AddCustomerAsync(customer);
        }
        public async Task DeleteCustomerAsync(int id)
        {
            await _repository.DeleteCustomerAsync(id);
        }
    }
}
