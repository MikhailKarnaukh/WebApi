using Bank.Repository.Models;
using Bank.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerService externalServise, ILogger<CustomerController> externalLogger)
        {
            _customerService = externalServise;
            _logger = externalLogger;
        }

        [HttpGet("get-list-customers")]
        public async Task<List<Customer>> GetCustomers()
        {
            var customers = await _customerService.GetCustomersAsync();
            return customers;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerAsync([FromRoute] int id)
        {
            if(id < 0)
            {
                return BadRequest();
            }

            _logger.LogInformation("Log from Controller start");

            var customer = await _customerService.GetCustomerAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _logger.LogInformation("Log from Controller finish");
            return Ok(customer);
        }
        [HttpPost("add-customer")]
        public async Task<IActionResult> AddCustomerAsync([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }
            await _customerService.AddCustomerAsync(customer);
            var checkTable = await _customerService.GetCustomersAsync();
            return Ok(checkTable);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateResultAsync([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }
            await _customerService.UpdateCustomerAsync(customer);
            var checkTable = await _customerService.GetCustomersAsync();
            return Ok(checkTable);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerAsync([FromRoute] int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            await _customerService.DeleteCustomerAsync(id);
            var checkTable = await _customerService.GetCustomersAsync();
            return Ok(checkTable);
        }
    }
}
