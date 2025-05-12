using Core.Abstraction.Manager;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private readonly ISalaryManager _salaryManager;

        public SalaryController(ISalaryManager salaryManager)
        {
            _salaryManager = salaryManager;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddSalaryAsync([FromBody] SalaryModel salaryModel)
        {
            await _salaryManager.CreateEmployeeSalaryAsync(salaryModel);
            return Ok(new { mes = "Salary Added..." });
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllEmployeeSalaryAsync()
        {
            return Ok(await _salaryManager.GetAllEmployeeSalaryAsync());

        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEmployeeSalaryByIdAsync(int id)
        {
            var salary = await _salaryManager.GetEmployeeSalaryByIdAsync(id);

            if (salary == null)
                return NotFound("Salary data not found.");
            return Ok(salary);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetEmployeeLessThan15KSalaryAsync()
        {
            var employeeWith15K = await _salaryManager.GetEmployeesHavingLessThan15kSalary();

            if (employeeWith15K == null) return NotFound("No Employee paid less than 15K");
            return Ok(employeeWith15K);
        }

        [HttpGet("{id}/{year}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPreviousSalaryOfEmployeeAsync([FromRoute] int id, [FromRoute] int year)
        {
            var previousSalary = await _salaryManager.GetPreviousYearSalaryOfEmployeeAsync(id, year);

            if (previousSalary == null) return NotFound("Salary not found for this employee.");
            return Ok(previousSalary);
        }

        [HttpGet("{employeeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSalaryGroupedByYearAsync([FromRoute] int employeeId)
        {
            return Ok(await _salaryManager.GetEmployeeSalaryGroupedByYearAsync(employeeId));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateSalaryAsync([FromRoute] int id, [FromBody] SalaryModel salary)
        {
            await _salaryManager.UpdateEmployeeSalaryByIdAsync(id, salary);
            return Ok(new { msg = "Salary Updated..." });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteSalaryAsync([FromRoute] int id)
        {
            await _salaryManager.DeleteEmployeeSalaryByIdAsync(id);
            return Ok("Salary deleted successfully.");
        }
    }
}