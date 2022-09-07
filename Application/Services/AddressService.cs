using Application.Common.Interfaces.Repositories;
using Application.Services.Common;
using AutoMapper;
using Application.Dtos.Address;
using Application.Common.Exceptions;
using Domain.Entities;
using Application.Common.Interfaces.Services;

namespace Application.Services
{
    public class AddressService : BaseService, IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IMapper mapper, IAddressRepository addressRepository) : base(mapper)
        {
            _addressRepository = addressRepository ?? throw new ArgumentNullException(nameof(addressRepository));
        }

        public async Task<IEnumerable<AddressDto>> GetAllAsync()
        {
            var addresses = await _addressRepository.GetAllAsync() ?? throw new NotFoundException();
            var addressesDtos = mapper.Map<IEnumerable<AddressDto>>(addresses);

            return addressesDtos;
        }

        public async Task<AddressDto> GetByIdAsync(int id)
        {
            var address = await _addressRepository.GetByIdAsync(id) ?? throw new NotFoundException();

            var addressDto = mapper.Map<AddressDto>(address);

            return addressDto;
        }

        public async Task CreateAsync(AddressForCreateDto addressForCreateDto)
        {
            if(addressForCreateDto == null)
            {
                throw new ArgumentNullException(nameof(addressForCreateDto));
            }
            
            var address = mapper.Map<Address>(addressForCreateDto);

            await _addressRepository.CreateAsync(address);
        }

        public async Task UpdateAsync(AddressForUpdateDto addressForUpdateDto)
        {
            if(addressForUpdateDto == null)
            {
                throw new ArgumentNullException(nameof(addressForUpdateDto));
            }

            var checkAddress = _addressRepository.GetByIdAsync(addressForUpdateDto.Id) ?? throw new NotFoundException();

            var address = mapper.Map<Address>(addressForUpdateDto);

            await _addressRepository.UpdateAsync(address);
        }

        public async Task DeleteAsync(int id)
        {
            var checkAddress = await _addressRepository.GetByIdAsync(id) ?? throw new NotFoundException();

            await _addressRepository.DeleteAsync(id);        
        }
    }
}
