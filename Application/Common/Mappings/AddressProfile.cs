using Application.Dtos.Address;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mappings
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressDto>();

            CreateMap<AddressForCreateDto, Address>();

            CreateMap<AddressForUpdateDto, Address>();
        }
    }
}
