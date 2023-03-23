using Bank.Repository.Interfaces;
using Bank.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Bank.Repository.Repositories
{
    public class DepositRepository : IDepositRepository
    {
        private readonly BankDbContext _bankDbContext;
        private readonly ILogger<DepositRepository> _logger;

        public DepositRepository(BankDbContext bankDb, ILogger<DepositRepository> externalLogger)
        {
            _bankDbContext = bankDb;
            _logger = externalLogger;
        }

        public async Task<List<BaseDeposit>> GetDepositsAsync()
        {
            var deposits = await _bankDbContext.Set<BaseDeposit>().ToListAsync();
            return deposits;
        }
        public async Task AddDepositAsync(BaseDeposit deposit)
        {
            _logger.LogInformation("Log from DepositRepository");
            await _bankDbContext.Set<BaseDeposit>().AddAsync(deposit);
            await _bankDbContext.SaveChangesAsync();
        }
    }
}
