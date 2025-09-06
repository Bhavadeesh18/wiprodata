using CarRental.DTOs;

namespace CarRental.Services
{
    public interface ICustomerService
    {
        Task<CustomerDto> AddCustomerAsync(CreateCustomerDto customerDto);
        Task<List<CustomerDto>> GetAllCustomersAsync();
        Task<List<CustomerDto>> SearchCustomersAsync(string name);
        Task<CustomerDto?> UpdateCustomerAsync(int id, CreateCustomerDto customerDto);
        Task<bool> DeleteCustomerAsync(int id);
    }
}