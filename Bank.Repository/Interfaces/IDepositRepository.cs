using Bank.Repository.Models;

namespace Bank.Repository.Interfaces
{
    public interface IDepositRepository
    {
        Task<List<BaseDeposit>> GetDepositsAsync();
        Task AddDepositAsync(BaseDeposit deposit);
    }
}
