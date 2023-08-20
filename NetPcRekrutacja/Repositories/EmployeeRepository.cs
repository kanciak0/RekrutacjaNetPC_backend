using NetPcRekrutacjaBackend.Domain.Employee;
using NetPcRekrutacjaBackend.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace NetPcRekrutacjaBackend.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DatabaseContext _dbContext;

        public EmployeeRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _dbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(Guid employeeid)
        {
            return await _dbContext.Employees.FindAsync(employeeid);
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            return employee;
        }
        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            _dbContext.Entry(employee).State = EntityState.Modified;
            return employee;
        }
        public async Task<bool> DeleteEmployeeAsync(Guid employeeid)
        {
            var user = await _dbContext.Employees.FindAsync(employeeid);
            if (user == null)
                return false;

            _dbContext.Employees.Remove(user);
            return true;
        }

    }
}
