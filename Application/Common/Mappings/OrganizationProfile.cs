using Application.Dtos.Organization;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mappings
{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            CreateMap<Organization, OrganizationDto>();

            CreateMap<Organization, OrganizationForCreateDto>();

            CreateMap<Organization, OrganizationForUpdateDto>();
        }
    }
}
