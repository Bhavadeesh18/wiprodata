using CarRental.Data;
using CarRental.DTOs;
using CarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly CarRentalDbContext _context;

        public VehicleService(CarRentalDbContext context)
        {
            _context = context;
        }

        public async Task<VehicleDto> AddVehicleAsync(CreateVehicleDto vehicleDto)
        {
            var vehicle = new Vehicle
            {
                Make = vehicleDto.Make,
                Model = vehicleDto.Model,
                Year = vehicleDto.Year,
                DailyRate = vehicleDto.DailyRate,
                PassengerCapacity = vehicleDto.PassengerCapacity,
                EngineCapacity = vehicleDto.EngineCapacity,
                VehicleType = vehicleDto.VehicleType,
                Status = "Available"
            };

            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();

            return new VehicleDto
            {
                VehicleID = vehicle.VehicleID,
                Make = vehicle.Make,
                Model = vehicle.Model,
                Year = vehicle.Year,
                DailyRate = vehicle.DailyRate,
                Status = vehicle.Status,
                PassengerCapacity = vehicle.PassengerCapacity,
                EngineCapacity = vehicle.EngineCapacity,
                VehicleType = vehicle.VehicleType
            };
        }

        public async Task<List<VehicleDto>> GetAllVehiclesAsync()
        {
            var vehicles = await _context.Vehicles.ToListAsync();
            return vehicles.Select(v => new VehicleDto
            {
                VehicleID = v.VehicleID,
                Make = v.Make,
                Model = v.Model,
                Year = v.Year,
                DailyRate = v.DailyRate,
                Status = v.Status,
                PassengerCapacity = v.PassengerCapacity,
                EngineCapacity = v.EngineCapacity,
                VehicleType = v.VehicleType
            }).ToList();
        }

        public async Task<List<VehicleDto>> GetVehiclesByTypeAsync(string vehicleType)
        {
            var vehicles = await _context.Vehicles
                .Where(v => v.VehicleType.ToLower() == vehicleType.ToLower())
                .ToListAsync();

            return vehicles.Select(v => new VehicleDto
            {
                VehicleID = v.VehicleID,
                Make = v.Make,
                Model = v.Model,
                Year = v.Year,
                DailyRate = v.DailyRate,
                Status = v.Status,
                PassengerCapacity = v.PassengerCapacity,
                EngineCapacity = v.EngineCapacity,
                VehicleType = v.VehicleType
            }).ToList();
        }

        public async Task<List<VehicleDto>> GetAvailableVehiclesByTypeAsync(string vehicleType)
        {
            var vehicles = await _context.Vehicles
                .Where(v => v.VehicleType.ToLower() == vehicleType.ToLower() && v.Status == "Available")
                .ToListAsync();

            return vehicles.Select(v => new VehicleDto
            {
                VehicleID = v.VehicleID,
                Make = v.Make,
                Model = v.Model,
                Year = v.Year,
                DailyRate = v.DailyRate,
                Status = v.Status,
                PassengerCapacity = v.PassengerCapacity,
                EngineCapacity = v.EngineCapacity,
                VehicleType = v.VehicleType
            }).ToList();
        }

        public async Task<VehicleDto> GetVehicleByIdAsync(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
                return null;
            
            return new VehicleDto
            {
                VehicleID = vehicle.VehicleID,
                Make = vehicle.Make,
                Model = vehicle.Model,
                Year = vehicle.Year,
                DailyRate = vehicle.DailyRate,
                Status = vehicle.Status,
                PassengerCapacity = vehicle.PassengerCapacity,
                EngineCapacity = vehicle.EngineCapacity,
                VehicleType = vehicle.VehicleType
            };
        }

        public async Task<VehicleDto> UpdateVehicleAsync(int id, CreateVehicleDto vehicleDto)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
                return null;
            
            vehicle.Make = vehicleDto.Make;
            vehicle.Model = vehicleDto.Model;
            vehicle.Year = vehicleDto.Year;
            vehicle.DailyRate = vehicleDto.DailyRate;
            vehicle.PassengerCapacity = vehicleDto.PassengerCapacity;
            vehicle.EngineCapacity = vehicleDto.EngineCapacity;
            vehicle.VehicleType = vehicleDto.VehicleType;
            
            await _context.SaveChangesAsync();
            
            return new VehicleDto
            {
                VehicleID = vehicle.VehicleID,
                Make = vehicle.Make,
                Model = vehicle.Model,
                Year = vehicle.Year,
                DailyRate = vehicle.DailyRate,
                Status = vehicle.Status,
                PassengerCapacity = vehicle.PassengerCapacity,
                EngineCapacity = vehicle.EngineCapacity,
                VehicleType = vehicle.VehicleType
            };
        }

        public async Task<bool> DeleteVehicleAsync(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
                return false;
            
            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
