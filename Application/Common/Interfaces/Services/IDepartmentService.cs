using Application.Dtos.Department;

namespace Application.Common.Interfaces.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDto>> GetAllAsync();
        Task<DepartmentDto> GetByIdAsync(int id);
        Task CreateAsync(DepartmentForCreateDto departmentForCreateDto);
        Task UpdateAsync(DepartmentForUpdateDto departmentForUpdateDto);
        Task DeleteAsync(int id);
    }
}
