using Microsoft.AspNetCore.Mvc;
using EmployLoad.Models;
using EmployLoad.Services;

namespace EmployLoad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployLoadController : ControllerBase
    {
        private readonly IEmployService _employService;

        public EmployLoadController(IEmployService employService)
        {
            _employService = employService;
        }

        // GET: api/EmployLoad
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var result = await _employService.ShowEmployAsync();
            return Ok(result);
        }

        // GET: api/EmployLoad/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var result = await _employService.SearchByEmpnoAsync(id);
            if (result == null)
            {
                return NotFound($"Employee with ID {id} not found");
            }
            return Ok(result);
        }

        // POST: api/EmployLoad
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Employ employ)
        {
            var result = await _employService.AddEmployAsync(employ);
            return Ok(new { message = "Employee created successfully", data = result });
        }

        // PUT: api/EmployLoad/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, Employ employ)
        {
            var result = await _employService.UpdateEmployAsync(id, employ);
            return Ok(new { message = result });
        }

        // DELETE: api/EmployLoad/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var result = await _employService.DeleteEmployAsync(id);
            return Ok(new { message = result });
        }
    }
}
