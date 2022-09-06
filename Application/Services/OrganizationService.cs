using Application.Common.Interfaces.Repositories;
using Application.Services.Common;
using AutoMapper;
using Application.Dtos.Organization;
using Domain.Entities;
using Application.Common.Interfaces.Services;

namespace Application.Services
{
    public class OrganizationService : BaseService, IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationService(IMapper mapper ,IOrganizationRepository organizationRepository) : base(mapper) => _organizationRepository = organizationRepository;

        public async Task<IEnumerable<OrganizationDto>> GetAllAsync()
        {
            var organizations = await _organizationRepository.GetAllAsync();
            var organizationsDtos = mapper.Map<IEnumerable<OrganizationDto>>(organizations);

            return organizationsDtos;
        }

        public async Task<OrganizationDto> GetByIdAsync(int id)
        {
            var organization = await _organizationRepository.GetByIdAsync(id);
            var organizationDto = mapper.Map<OrganizationDto>(organization);

            return organizationDto;
        }

        public async Task CreateAsync(OrganizationForCreateDto organizationForCreateDto)
        {
            var organization = mapper.Map<Organization>(organizationForCreateDto);

            await _organizationRepository.CreateAsync(organization);
        }

        public async Task UpdateAsync(OrganizationForUpdateDto organizationForUpdateDto)
        {
            var organization = mapper.Map<Organization>(organizationForUpdateDto);

            await _organizationRepository.UpdateAsync(organization);
        }

        public async Task DeleteAsync(int id) => await _organizationRepository.DeleteAsync(id);
    }
}
