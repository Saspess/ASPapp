using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Common.Interfaces.Services;
using Application.Dtos.Position;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly IPositionService _positionService;

        public PositionsController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _positionService.GetAllAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var position = await _positionService.GetByIdAsync(id);

            if (position == null)
            {
                return NotFound();
            }

            return Ok(position);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] PositionForCreateDto positionForCreateDto)
        {
            await _positionService.CreateAsync(positionForCreateDto);

            return StatusCode(201);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] PositionForUpdateDto positionForUpdateDto)
        {
            await _positionService.UpdateAsync(positionForUpdateDto);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await _positionService.DeleteAsync(id);

            return NoContent();
        }
    }
}
