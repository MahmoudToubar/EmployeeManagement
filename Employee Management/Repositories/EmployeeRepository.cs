using Employee_Management.Data;
using Employee_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext employeeDbContext;

        public EmployeeRepository(EmployeeDbContext employeeDbContext)
        {
            this.employeeDbContext = employeeDbContext;
        }

        public async Task<Employee> AddAsync(Employee employees)
        {
            await employeeDbContext.Employees.AddAsync(employees);
            await employeeDbContext.SaveChangesAsync();

            return employees;
        }

        public async Task<Employee?> DeleteAsync(Guid id)
        {
            var existingEmp = await employeeDbContext.Employees.FindAsync(id);

            if (existingEmp != null)
            {
                employeeDbContext.Employees.Remove(existingEmp);
                await employeeDbContext.SaveChangesAsync();
                return existingEmp;
            }

            return null;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await employeeDbContext.Employees.ToListAsync();
        }

        public Task<Employee?> GetAsync(Guid id)
        {
            return employeeDbContext.Employees.FirstOrDefaultAsync(x => x.EmployeeId == id);
        }

        public async Task<Employee?> UpdateAsync(Employee employees)
        {
            var existingEmp = await employeeDbContext.Employees.FindAsync(employees.EmployeeId);

            if (existingEmp != null)
            {
                existingEmp.Name = employees.Name;
                existingEmp.NationalId = employees.NationalId;
                existingEmp.DateOfBirth = employees.DateOfBirth;
                existingEmp.Account = employees.Account;
                existingEmp.LineOfBusiness = employees.LineOfBusiness;
                existingEmp.Language = employees.Language;
                existingEmp.LanguageLevel = employees.LanguageLevel;

                await employeeDbContext.SaveChangesAsync();

                return existingEmp;
            }

            return null;

        }
    }
}
