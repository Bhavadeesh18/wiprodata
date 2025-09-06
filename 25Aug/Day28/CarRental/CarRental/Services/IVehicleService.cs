using CarRental.DTOs;

namespace CarRental.Services
{
    public interface IVehicleService
    {
        Task<VehicleDto> AddVehicleAsync(CreateVehicleDto vehicleDto);
        Task<List<VehicleDto>> GetAllVehiclesAsync();
        Task<List<VehicleDto>> GetVehiclesByTypeAsync(string vehicleType);
        Task<List<VehicleDto>> GetAvailableVehiclesByTypeAsync(string vehicleType);
        Task<VehicleDto> GetVehicleByIdAsync(int id);
        Task<VehicleDto> UpdateVehicleAsync(int id, CreateVehicleDto vehicleDto);
        Task<bool> DeleteVehicleAsync(int id);

    }
}
