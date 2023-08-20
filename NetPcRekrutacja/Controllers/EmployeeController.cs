using NetPcRekrutacjaBackend.Services.EmployeeService;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NetPcRekrutacjaBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {

        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService =  employeeService;
        }

        [HttpGet("GetEmployeeList")]
        [AllowAnonymous]
        public async Task<IActionResult> GetEmployeeList()
        {
            try
            {
                var employeeList = await _employeeService.GetEmployeesWithoutDetailsListAsync();
                return Ok(employeeList);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }
        [HttpPost("CreateEmployee")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeViewModel employeeViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _employeeService.CreateEmployeeAsync(employeeViewModel);
                    return Ok("The user has been successfully created");
                }
                return BadRequest("Invalid input data. User not created.");
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while creating the user: " + ex.Message);
            }
        }

        [HttpGet("GetEmployeeDetails/{employeeId}")]

        public async Task<IActionResult> GetEmployeeDetails(Guid employeeId)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeDetailsAsync(employeeId);

                if (employee == null)
                {
                    return NotFound();
                }

                return Ok(employee);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        [HttpDelete("DeleteEmployee/{employeeId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteEmployee(Guid employeeId)
        {
            try
            {
                var deleted = await _employeeService.DeleteEmployeeAsync(employeeId);

                if (deleted)
                {
                    return NoContent();
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        [HttpPut("UpdateEmployee")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateEmployee(Guid employeeId, EmployeeViewModel employeeViewModel)
        {
            try
            {
                var updated = await _employeeService.UpdateEmployeeAsync(employeeId, employeeViewModel);

                if (updated)
                {
                    return NoContent();
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }
    }
}