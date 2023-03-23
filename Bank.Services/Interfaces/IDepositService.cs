using Bank.Repository.Models;

namespace Bank.Services.Interfaces
{
    public interface IDepositService
    {
        Task<List<BaseDeposit>> GetDepositsAsync();
        Task AddDepositAsync(BaseDeposit deposit);
    }
}
