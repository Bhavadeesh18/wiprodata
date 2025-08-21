using EmployLoad.Models;

namespace EmployLoad.Services
{
    public interface IEmployService
    {
        Task<IEnumerable<Employ>> ShowEmployAsync();
        Task<Employ?> SearchByEmpnoAsync(int id);
        Task<string> AddEmployAsync(Employ employ);
        Task<string> UpdateEmployAsync(int id, Employ employ);
        Task<string> DeleteEmployAsync(int id);
    }
}
