using Application.Common.Exceptions;
using Application.Common.Interfaces.Services;
using Application.Common.Interfaces.UOW;
using Application.Dtos.Organization;
using Application.Services.Common;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class OrganizationService : BaseService, IOrganizationService
    {
        public OrganizationService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<IEnumerable<OrganizationDto>> GetAllAsync()
        {
            var organizations = await unitOfWork.OrganizationRepository.GetAllAsync();
            var organizationsDtos = mapper.Map<IEnumerable<OrganizationDto>>(organizations);

            return organizationsDtos;
        }

        public async Task<OrganizationDto> GetByIdAsync(int id)
        {
            var organization = await unitOfWork.OrganizationRepository.GetByIdAsync(id);
            var organizationDto = mapper.Map<OrganizationDto>(organization);

            return organizationDto;
        }

        public async Task CreateAsync(OrganizationForCreateDto organizationForCreateDto)
        {
            if (organizationForCreateDto == null)
            {
                throw new ArgumentNullException(nameof(organizationForCreateDto));
            }

            var organization = mapper.Map<Organization>(organizationForCreateDto);

            await unitOfWork.OrganizationRepository.CreateAsync(organization);
        }

        public async Task UpdateAsync(OrganizationForUpdateDto organizationForUpdateDto)
        {
            if (organizationForUpdateDto == null)
            {
                throw new ArgumentNullException(nameof(organizationForUpdateDto));
            }

            var checkOrganization = await unitOfWork.OrganizationRepository.GetByIdAsync(organizationForUpdateDto.Id) 
                ?? throw new NotFoundException("Organization was not found");

            var organization = mapper.Map<Organization>(organizationForUpdateDto);

            await unitOfWork.OrganizationRepository.UpdateAsync(organization);
        }

        public async Task DeleteAsync(int id)
        {
            var checkOrganization = await unitOfWork.OrganizationRepository.GetByIdAsync(id) 
                ?? throw new NotFoundException("Organization was not found");

            await unitOfWork.OrganizationRepository.DeleteAsync(id);
        }
    }
}
