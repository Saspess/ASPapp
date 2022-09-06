using Application.Common.Interfaces.Repositories;
using Application.Services.Common;
using AutoMapper;
using Application.Dtos.Address;
using Domain.Entities;
using Application.Common.Interfaces.Services;

namespace Application.Services
{
    public class AddressService : BaseService, IAddressService
    {
        private IAddressRepository _addressRepository;

        public AddressService(IMapper mapper, IAddressRepository addressRepository) : base(mapper) => _addressRepository = addressRepository;

        public async Task<IEnumerable<AddressDto>> GetAllAsync()
        {
            var addresses = await _addressRepository.GetAllAsync();
            var addressesDtos = mapper.Map<IEnumerable<AddressDto>>(addresses);

            return addressesDtos;
        }

        public async Task<AddressDto> GetByIdAsync(int id)
        {
            var address = await _addressRepository.GetByIdAsync(id);
            var addressDto = mapper.Map<AddressDto>(address);

            return addressDto;
        }

        public async Task CreateAsync(AddressForCreateDto addressForCreateDto)
        {
            var address = mapper.Map<Address>(addressForCreateDto);

            await _addressRepository.CreateAsync(address);
        }

        public async Task UpdateAsync(AddressForUpdateDto addressForUpdateDto)
        {
            var address = mapper.Map<Address>(addressForUpdateDto);

            await _addressRepository.UpdateAsync(address);
        }

        public async Task DeleteAsync(int id) => await _addressRepository.DeleteAsync(id);
    }
}
