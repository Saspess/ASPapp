using Application.Common.Interfaces.Services;
using Application.Dtos.Address;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressesController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _addressService.GetAllAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var address = await _addressService.GetByIdAsync(id);

            if(address == null)
            {
                return NotFound();
            }

            return Ok(address);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] AddressForCreateDto addressForCreateDto)
        {
            await _addressService.CreateAsync(addressForCreateDto);

            return StatusCode(201);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] AddressForUpdateDto addressForUpdateDto)
        {
            await _addressService.UpdateAsync(addressForUpdateDto);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await _addressService.DeleteAsync(id);

            return NoContent();
        }
    }
}
