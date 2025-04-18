using Microsoft.AspNetCore.Mvc;
using Core.Abstraction.Manager;

using Core.Models;

namespace WebApplication.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly IMasterManager _masterManager;

        public MasterController(IMasterManager masterManager)
        {
            _masterManager = masterManager;
        }


        [HttpPost("seed/department")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SeedDepartmentAsync()
        {

            await _masterManager.SeedDepartmentsAsync();
            return Ok("Departments Seeded Successfully");
        }

        [HttpPost("seed/states")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SeedStatesAsync()
        {

            await _masterManager.SeedStatesAsync();
            return Ok("States Seeded Successfully");
        }

        [HttpPost("seed/cities")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SeedCitiesAsync()
        {

            await _masterManager.SeedCitiesAsync();
            return Ok("cities Seeded Successfully");
        }

        [HttpPost("create/city")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCityAsync([FromBody] CityModel city)
        {


            return Ok(await _masterManager.CreateCityAsync(city));
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllCitiesAsync()
        {
            var cities = await _masterManager.GetCitiesAsync();

            if (cities == null)
                return NotFound("Every Department have employee");
            return Ok(cities);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllStateAsync()
        {
            var states = await _masterManager.GetStateListAsync();

            if (states == null)
                return NotFound("Every Department have employee");
            return Ok(states);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllDepartmentsAsync()
        {
            var depratments = await _masterManager.GetDepartmentsAsync();

            if (depratments == null)
                return NotFound("Every Department have employee");
            return Ok(depratments);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDepartmentWithNoEmployeeAsync()
        {
            var departmentWithNoEmployee = await _masterManager.GetDepartmentWithNoEmployeeAsync();

            if (departmentWithNoEmployee == null)
                return NotFound("Every Department have employee");
            return Ok(departmentWithNoEmployee);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCityWithNoEmployeeAsync()
        {
            var cityWithNoEmployee = await _masterManager.GetCityWithNoEmployeeAsync();

            if (cityWithNoEmployee == null)
                return NotFound("Every City Have employees");
            return Ok(cityWithNoEmployee);
        }
        [HttpGet("{stateId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCityByStateIdAsync([FromRoute] int stateId)
        {
            var cities = await _masterManager.GetCityListByStateIdAsync(stateId);

            if (cities == null)
                return NotFound($"Cities Not exist with State Id: {stateId}");
            return Ok(cities);
        }


    }
}