using NetPcRekrutacjaBackend.Domain.Employee;
using NetPcRekrutacjaBackend.Repositories;

namespace NetPcRekrutacjaBackend.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Employee> CreateEmployeeAsync(EmployeeViewModel employeeViewModel)
        {
            if (employeeViewModel == null)
            {
                throw new ArgumentNullException(nameof(employeeViewModel));
            }

            var contact = new Contact
            {
                Category = employeeViewModel.Contact.Category,
                Subcategory = employeeViewModel.Contact.Subcategory
            };

            var details = new Details(
                name: employeeViewModel.Details.Name,
                surname: employeeViewModel.Details.Surname,
                email: employeeViewModel.Details.Email,
                password: employeeViewModel.Details.Password,
                phoneNumber: employeeViewModel.Details.PhoneNumber,
                birthdate: employeeViewModel.Details.Birthdate
            );

            var newEmployee = new Employee(
                details: details,
                contact: contact
            );

            await _employeeRepository.AddEmployeeAsync(newEmployee);
            await _unitOfWork.SaveChangesAsync();

            return newEmployee;
        }
        public async Task<bool> UpdateEmployeeAsync(Guid employeeId, EmployeeViewModel employeeViewModel)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(employeeId);
            if (employee == null)
                return false;

            // Update user properties from userViewModel
            employee.Details = new Details(
                name: employeeViewModel.Details.Name,
                surname: employeeViewModel.Details.Surname,
                email: employeeViewModel.Details.Email,
                password: employeeViewModel.Details.Password,
                phoneNumber: employeeViewModel.Details.PhoneNumber,
                birthdate: employeeViewModel.Details.Birthdate
            );
            employee.Contact = new Contact
            {
                Category = employeeViewModel.Contact.Category,
                Subcategory = employeeViewModel.Contact.Subcategory
            };

            _employeeRepository.UpdateEmployeeAsync(employee);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteEmployeeAsync(Guid employeeId)
        {
            var user = await _employeeRepository.GetEmployeeByIdAsync(employeeId);
            if (user == null)
                return false;

            _employeeRepository.DeleteEmployeeAsync(employeeId);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<Employee> GetEmployeeDetailsAsync(Guid employeeId)
        {
            return await _employeeRepository.GetEmployeeByIdAsync(employeeId);
        }
        public async Task<List<EmployeeListItem>> GetEmployeesWithoutDetailsListAsync()
        {
            var employee = await _employeeRepository.GetAllEmployeesAsync();
            var employeelist = employee.Select(user => new EmployeeListItem
            {
                Id = user.Id,
            }).ToList();

            return employeelist;
        }
    }
    public class EmployeeViewModel
    {
        public Details Details { get; set; }
        public Contact Contact { get; set; }

    }

    public class EmployeeListItem
    {
        public Guid Id { get; set; }
    }
}
