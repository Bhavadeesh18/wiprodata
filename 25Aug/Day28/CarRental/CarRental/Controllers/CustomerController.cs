using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CarRental.Services;
using CarRental.DTOs;

namespace CarRental.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize(AuthenticationSchemes = "Cookies")] // Temporarily disabled to test API
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // 1) Add Customer
        [HttpPost]
        public async Task<ActionResult<CustomerDto>> AddCustomer([FromBody] CreateCustomerDto customerDto)
        {
            var result = await _customerService.AddCustomerAsync(customerDto);
            return CreatedAtAction(nameof(GetAllCustomers), new { id = result.CustomerID }, result);
        }

        // 2) Show All Customers
        [HttpGet]
        public async Task<ActionResult<List<CustomerDto>>> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return Ok(customers);
        }

        // 3) Search Customer
        [HttpGet("search")]
        public async Task<ActionResult<List<CustomerDto>>> SearchCustomers([FromQuery] string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Name parameter is required");
            }

            var customers = await _customerService.SearchCustomersAsync(name);
            return Ok(customers);
        }

        // 4) Update Customer
        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerDto>> UpdateCustomer(int id, [FromBody] CreateCustomerDto customerDto)
        {
            var result = await _customerService.UpdateCustomerAsync(id, customerDto);
            if (result == null)
            {
                return NotFound($"Customer with ID {id} not found");
            }
            return Ok(result);
        }

        // 5) Delete Customer
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteCustomer(int id)
        {
            var result = await _customerService.DeleteCustomerAsync(id);
            if (!result)
            {
                return NotFound($"Customer with ID {id} not found");
            }
            return Ok(true);
        }
    }
}