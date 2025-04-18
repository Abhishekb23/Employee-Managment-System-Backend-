using Core.Abstraction.Manager;
using Core.Models;

using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeManager _employeeManager;
        public EmployeeController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddEmployeeAsync([FromBody] EmployeeDetailModel employee)
        {
            if (employee == null)
                return BadRequest(new { message = "Invalid employee details." });
            await _employeeManager.AddEmployeeAsync(employee);
            return Ok(new { message = "Employee Created..." });
        }

        [HttpGet("employee/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEmployeeAsync([FromRoute] int id)
        {
            var employees = await _employeeManager.GetEmployeeDetailsAsync(id);

            if (employees == null)
                return NotFound(new { message = $"No employee found with id {id}." });
            return Ok(employees);
        }

        [HttpGet("employee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllEmployeesAsync()
        {
            var employees = await _employeeManager.GetEmployeesAsync();

            if (employees == null)
                return NotFound(new { message = "No employees found ." });
            return Ok(employees);
        }

        [HttpGet("city-wise")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCityWiseEmployeesAsync()
        {
            var cityEmployees = await _employeeManager.GetCityWiseEmployeesAsync();

            if (cityEmployees == null)
                return NotFound(new { message = "No employees found for any city." });
            return Ok(cityEmployees);
        }

        [HttpGet("active")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetActiveEmployeesAsync()
        {
            var employees = await _employeeManager.GetWorkingEmployeesAsync();

            if (employees == null)
                return NotFound(new { message = "No active employees available." });
            return Ok(employees);
        }

        [HttpGet("department/{departmentId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEmployeesByDepartmentIdAsync([FromRoute] int departmentId)
        {
            var employees = await _employeeManager.GetEmployeeByDepartmentIdAsync(departmentId);

            if (employees == null)
                return NotFound(new { message = "No employees found for the given department." });
            return Ok(employees);
        }

        [HttpGet("paid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPaidEmployeesAsync()
        {
            var paidEmployees = await _employeeManager.GetPaidEmployeesAsync();

            if (paidEmployees == null)
                return NotFound(new { message = "No employees have been paid yet." });
            return Ok(paidEmployees);
        }

        [HttpGet("unpaid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUnpaidEmployeesAsync()
        {
            var unpaidEmployees = await _employeeManager.GetNotPaidEmployeesAsync();

            if (unpaidEmployees == null)
                return NotFound(new { message = "All employees have been paid." });
            return Ok(unpaidEmployees);
        }

        [HttpPut("update/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateEmployeeAsync([FromRoute] int id, [FromBody] EmployeeModel employee)
        {
            if (employee == null)
                return BadRequest(new { message = "Invalid employee data." });
            await _employeeManager.UpdateEmployeeByAsync(id, employee);
            return Ok(new { message = "Employee Updated..." });
        }

        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteEmployeeByIdAsync([FromRoute] int id)
        {
            await _employeeManager.DeleteEmployeeByAsync(id);
            return Ok(new { message = "Employee deleted successfully." });
        }
    }
}