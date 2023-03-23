using Bank.Repository.Models;
using Bank.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Bank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositController : ControllerBase
    {
        private readonly IDepositService _depositService;
        private readonly ILogger<DepositController> _logger;
        public DepositController(IDepositService externalServise, ILogger<DepositController> externalLogger)
        {
            _depositService = externalServise;
            _logger = externalLogger;
        }
        
        [HttpGet("get-list-deposits")]
        public async Task<List<BaseDeposit>> GetDepositsAsync()
        {
                var deposits = await _depositService.GetDepositsAsync();
                return deposits;
        }
        [HttpPost("add-deposit")]
        public async Task<IActionResult> AddDepositAsync(BaseDeposit customer)
        {
            _logger.LogInformation("Log from DepositController");
            await _depositService.AddDepositAsync(customer);
            var updatedList = await _depositService.GetDepositsAsync();
            return Ok(updatedList);
        }
    }
}
