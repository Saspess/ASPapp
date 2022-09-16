using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Common.Interfaces.Services;
using Application.Dtos.Employee;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _employeeService.GetAllAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] EmployeeForCreateDto employeeForCreateDto)
        {
            await _employeeService.CreateAsync(employeeForCreateDto);

            return StatusCode(201);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] EmployeeForUpdateDto employeeForUpdateDto)
        {
            await _employeeService.UpdateAsync(employeeForUpdateDto);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await _employeeService.DeleteAsync(id);

            return NoContent();
        }
    }
}
