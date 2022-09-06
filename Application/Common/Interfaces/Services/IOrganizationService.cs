using Application.Dtos.Organization;

namespace Application.Common.Interfaces.Services
{
    public interface IOrganizationService
    {
        Task<IEnumerable<OrganizationDto>> GetAllAsync();
        Task<OrganizationDto> GetByIdAsync(int id);
        Task CreateAsync(OrganizationForCreateDto organizationForCreateDto);
        Task UpdateAsync(OrganizationForUpdateDto organizationForUpdateDto);
        Task DeleteAsync(int id);
    }
}
