using Application.Dtos.Address;

namespace Application.Common.Interfaces.Services
{
    public interface IAddressService
    {
        Task<IEnumerable<AddressDto>> GetAllAsync();
        Task<AddressDto> GetByIdAsync(int id);
        Task CreateAsync(AddressForCreateDto addressForCreateDto);
        Task UpdateAsync(AddressForUpdateDto addressForUpdateDto);
        Task DeleteAsync(int id);
    }
}
