using CarRental.Data;
using CarRental.DTOs;
using CarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CarRentalDbContext _context;

        public CustomerService(CarRentalDbContext context)
        {
            _context = context;
        }

        public async Task<CustomerDto> AddCustomerAsync(CreateCustomerDto customerDto)
        {
            var customer = new Customer
            {
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                Email = customerDto.Email,
                PhoneNumber = customerDto.PhoneNumber,
                CreatedDate = DateTime.Now
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return new CustomerDto
            {
                CustomerID = customer.CustomerID,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                CreatedDate = customer.CreatedDate
            };
        }

        public async Task<List<CustomerDto>> GetAllCustomersAsync()
        {
            var customers = await _context.Customers.ToListAsync();
            return customers.Select(c => new CustomerDto
            {
                CustomerID = c.CustomerID,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber,
                CreatedDate = c.CreatedDate
            }).ToList();
        }

        public async Task<List<CustomerDto>> SearchCustomersAsync(string name)
        {
            var customers = await _context.Customers
                .Where(c => c.FirstName.Contains(name) || c.LastName.Contains(name))
                .ToListAsync();

            return customers.Select(c => new CustomerDto
            {
                CustomerID = c.CustomerID,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber,
                CreatedDate = c.CreatedDate
            }).ToList();
        }

        public async Task<CustomerDto?> UpdateCustomerAsync(int id, CreateCustomerDto customerDto)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) return null;

            customer.FirstName = customerDto.FirstName;
            customer.LastName = customerDto.LastName;
            customer.Email = customerDto.Email;
            customer.PhoneNumber = customerDto.PhoneNumber;

            await _context.SaveChangesAsync();

            return new CustomerDto
            {
                CustomerID = customer.CustomerID,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                CreatedDate = customer.CreatedDate
            };
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) return false;

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}