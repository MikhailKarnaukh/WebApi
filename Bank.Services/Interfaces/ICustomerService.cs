using Bank.Repository.Models;

namespace Bank.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomerAsync(int id);
        Task<List<Customer>> GetCustomersAsync();
        Task AddCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(int id);
        Task UpdateCustomerAsync(Customer customer);
    }
}
