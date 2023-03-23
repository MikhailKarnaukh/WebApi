using Bank.Repository.Models;

namespace Bank.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomerAsync(int id);
        Task<List<Customer>> GetCustomersAsync();
        Task AddCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(int id);
        Task UpdateCustomerAsync(Customer customer);
    }
}
