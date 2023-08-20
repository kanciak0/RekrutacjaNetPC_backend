using NetPcRekrutacjaBackend.Domain.Employee;

namespace NetPcRekrutacjaBackend.Services.EmployeeService
{
    public interface IEmployeeService
    {
        Task<Employee> CreateEmployeeAsync(EmployeeViewModel employeeViewModel);
        Task<bool> DeleteEmployeeAsync(Guid employeeId);
        Task<Employee> GetEmployeeDetailsAsync(Guid employeeId);
        Task<List<EmployeeListItem>> GetEmployeesWithoutDetailsListAsync();
        Task<bool> UpdateEmployeeAsync(Guid employeeId, EmployeeViewModel employeeViewModel);
    }
}