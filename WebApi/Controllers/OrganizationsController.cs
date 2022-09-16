using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Dtos.Organization;
using Application.Common.Interfaces.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationsController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _organizationService.GetAllAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var organization = await _organizationService.GetByIdAsync(id);

            if (organization == null)
            {
                return NotFound();
            }

            return Ok(organization);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] OrganizationForCreateDto organizationForCreateDto)
        {
            await _organizationService.CreateAsync(organizationForCreateDto);

            return StatusCode(201);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] OrganizationForUpdateDto organizationForUpdateDto)
        {
            await _organizationService.UpdateAsync(organizationForUpdateDto);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await _organizationService.DeleteAsync(id);

            return NoContent();
        }
    }
}
