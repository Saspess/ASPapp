using Application.Common.Exceptions;
using Application.Common.Interfaces.Services;
using Application.Common.Interfaces.UOW;
using Application.Dtos.Address;
using Application.Services.Common;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class AddressService : BaseService, IAddressService
    {
        public AddressService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<IEnumerable<AddressDto>> GetAllAsync()
        {
            var addresses = await unitOfWork.AddressRepository.GetAllAsync();
            var addressesDtos = mapper.Map<IEnumerable<AddressDto>>(addresses);

            return addressesDtos;
        }

        public async Task<AddressDto> GetByIdAsync(int id)
        {
            var address = await unitOfWork.AddressRepository.GetByIdAsync(id);

            var addressDto = mapper.Map<AddressDto>(address);

            return addressDto;
        }

        public async Task CreateAsync(AddressForCreateDto addressForCreateDto)
        {
            if (addressForCreateDto == null)
            {
                throw new ArgumentNullException(nameof(addressForCreateDto));
            }

            var address = mapper.Map<Address>(addressForCreateDto);

            await unitOfWork.AddressRepository.CreateAsync(address);
        }

        public async Task UpdateAsync(AddressForUpdateDto addressForUpdateDto)
        {
            if (addressForUpdateDto == null)
            {
                throw new ArgumentNullException(nameof(addressForUpdateDto));
            }

            var checkAddress = await unitOfWork.AddressRepository.GetByIdAsync(addressForUpdateDto.Id) 
                ?? throw new NotFoundException("Address was not found");

            var address = mapper.Map<Address>(addressForUpdateDto);

            await unitOfWork.AddressRepository.UpdateAsync(address);
        }

        public async Task DeleteAsync(int id)
        {
            var checkAddress = await unitOfWork.AddressRepository.GetByIdAsync(id) 
                ?? throw new NotFoundException("Address was not found");

            await unitOfWork.AddressRepository.DeleteAsync(id);
        }
    }
}
