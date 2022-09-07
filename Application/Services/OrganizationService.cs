using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Services;
using Application.Dtos.Organization;
using Application.Services.Common;
using Application.Common.Exceptions;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class OrganizationService : BaseService, IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationService(IMapper mapper, IOrganizationRepository organizationRepository) : base(mapper)
        { 
            _organizationRepository = organizationRepository ?? throw new ArgumentNullException(nameof(organizationRepository));
        }

        public async Task<IEnumerable<OrganizationDto>> GetAllAsync()
        {
            var organizations = await _organizationRepository.GetAllAsync() ?? throw new NotFoundException();
            var organizationsDtos = mapper.Map<IEnumerable<OrganizationDto>>(organizations);

            return organizationsDtos;
        }

        public async Task<OrganizationDto> GetByIdAsync(int id)
        {
            var organization = await _organizationRepository.GetByIdAsync(id) ?? throw new NotFoundException();

            var organizationDto = mapper.Map<OrganizationDto>(organization);

            return organizationDto;
        }

        public async Task CreateAsync(OrganizationForCreateDto organizationForCreateDto)
        {
            if(organizationForCreateDto == null)
            {
                throw new ArgumentNullException(nameof(organizationForCreateDto));
            }

            var organization = mapper.Map<Organization>(organizationForCreateDto);

            await _organizationRepository.CreateAsync(organization);
        }

        public async Task UpdateAsync(OrganizationForUpdateDto organizationForUpdateDto)
        {
            if(organizationForUpdateDto == null)
            {
                throw new ArgumentNullException(nameof(organizationForUpdateDto));
            }

            var checkOrganization = await _organizationRepository.GetByIdAsync(organizationForUpdateDto.Id) ?? throw new NotFoundException();

            var organization = mapper.Map<Organization>(organizationForUpdateDto);

            await _organizationRepository.UpdateAsync(organization);
        }

        public async Task DeleteAsync(int id)
        {
            var checkOrganization = await _organizationRepository.GetByIdAsync(id) ?? throw new NotFoundException();

            await _organizationRepository.DeleteAsync(id);
        }
    }
}
