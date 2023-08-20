using NetPcRekrutacjaBackend.Domain.Employee;

namespace NetPcRekrutacjaBackend.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> AddEmployeeAsync(Employee employee);
        Task<bool> DeleteEmployeeAsync(Guid employeeid);
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(Guid employeeid);
        Task<Employee> UpdateEmployeeAsync(Employee employee);
    }
}