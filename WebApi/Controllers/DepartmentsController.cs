using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Dtos.Department;
using Application.Common.Interfaces.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _departmentService.GetAllAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var department = await _departmentService.GetByIdAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] DepartmentForCreateDto departmentForCreateDto)
        {
            await _departmentService.CreateAsync(departmentForCreateDto);

            return StatusCode(201);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] DepartmentForUpdateDto departmentForUpdateDto)
        {
            await _departmentService.UpdateAsync(departmentForUpdateDto);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await _departmentService.DeleteAsync(id);

            return NoContent();
        }
    }
}
