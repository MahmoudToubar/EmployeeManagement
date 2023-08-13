using Employee_Management.Models;

namespace Employee_Management.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();

        Task<Employee?> GetAsync(Guid id);

        Task<Employee> AddAsync(Employee employees);

        Task<Employee?> UpdateAsync(Employee employees);

        Task<Employee?> DeleteAsync(Guid id);
    }
}
