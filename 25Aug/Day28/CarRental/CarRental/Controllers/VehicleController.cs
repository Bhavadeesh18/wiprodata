using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CarRental.Services;
using CarRental.DTOs;

namespace CarRental.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // JWT Required for all Vehicle APIs
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        // 1) Add Vehicle
        [HttpPost]
        public async Task<ActionResult<VehicleDto>> AddVehicle([FromBody] CreateVehicleDto vehicleDto)
        {
            var result = await _vehicleService.AddVehicleAsync(vehicleDto);
            return CreatedAtAction(nameof(GetAllVehicles), new { id = result.VehicleID }, result);
        }

        // 2) Show All Vehicles
        [HttpGet]
        public async Task<ActionResult<List<VehicleDto>>> GetAllVehicles()
        {
            var vehicles = await _vehicleService.GetAllVehiclesAsync();
            return Ok(vehicles);
        }

        // 3) Show By Vehicle Type
        [HttpGet("type/{vehicleType}")]
        public async Task<ActionResult<List<VehicleDto>>> GetVehiclesByType(string vehicleType)
        {
            var vehicles = await _vehicleService.GetVehiclesByTypeAsync(vehicleType);
            return Ok(vehicles);
        }

        // 4) Show Available Vehicles by Type
        [HttpGet("available/{vehicleType}")]
        public async Task<ActionResult<List<VehicleDto>>> GetAvailableVehiclesByType(string vehicleType)
        {
            var vehicles = await _vehicleService.GetAvailableVehiclesByTypeAsync(vehicleType);
            return Ok(vehicles);
        }

        // 5) Get Vehicle by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleDto>> GetVehicleById(int id)
        {
            var vehicle = await _vehicleService.GetVehicleByIdAsync(id);
            return Ok(vehicle);
        }

        // 6) Update Vehicle
        [HttpPut("{id}")]
        public async Task<ActionResult<VehicleDto>> UpdateVehicle(int id, [FromBody] CreateVehicleDto vehicleDto)
        {
            var result = await _vehicleService.UpdateVehicleAsync(id, vehicleDto);
            return Ok(result);
        }

        // 7) Delete Vehicle
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteVehicle(int id)
        {
            var result = await _vehicleService.DeleteVehicleAsync(id);
            return Ok(result);
        }
    }
}