using Application.Dtos.Employee;

namespace Application.Common.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllAsync();
        Task<EmployeeDto> GetByIdAsync(int id);
        Task CreateAsync(EmployeeForCreateDto employeeForCreateDto);
        Task UpdateAsync(EmployeeForUpdateDto employeeForUpdateDto);
        Task DeleteAsync(int id);
    }
}
