using Bank.Repository.Interfaces;
using Bank.Repository.Models;
using Bank.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Bank.Services.Services
{
    public class DepositService : IDepositService
    {
        private readonly IDepositRepository _repository;
        private readonly ILogger<DepositService> _logger;

        public DepositService(IDepositRepository externalRepository, ILogger<DepositService> externalLogger)
        {
            _repository = externalRepository;
            _logger = externalLogger;
        }

        public async Task<List<BaseDeposit>> GetDepositsAsync()
        {
            var deposits = await _repository.GetDepositsAsync();
            return deposits;
        }
        public async Task AddDepositAsync(BaseDeposit deposit)
        {
            _logger.LogInformation("Log from DepositService");
            await _repository.AddDepositAsync(deposit);
        }
    }
}
