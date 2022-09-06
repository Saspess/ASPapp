using Application.Common.Interfaces.Repositories;
using Application.Services.Common;
using AutoMapper;
using Application.Dtos.Department;
using Domain.Entities;
using Application.Common.Interfaces.Services;

namespace Application.Services
{
    public class DepartmentSevice : BaseService, IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentSevice(IMapper mapper, IDepartmentRepository departmentRepository) : base(mapper) => _departmentRepository = departmentRepository;

        public async Task<IEnumerable<DepartmentDto>> GetAllAsync()
        {
            var departments = await _departmentRepository.GetAllAsync();
            var departmentsDtos = mapper.Map<IEnumerable<DepartmentDto>>(departments);

            return departmentsDtos;
        }

        public async Task<DepartmentDto> GetByIdAsync(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            var departmentDto = mapper.Map<DepartmentDto>(department); 

            return departmentDto;
        }

        public async Task CreateAsync(DepartmentForCreateDto departmentForCreateDto)
        {
            var department = mapper.Map<Department>(departmentForCreateDto);

            await _departmentRepository.CreateAsync(department);
        }

        public async Task UpdateAsync(DepartmentForUpdateDto departmentForUpdateDto)
        {
            var department = mapper.Map<Department>(departmentForUpdateDto);

            await _departmentRepository.UpdateAsync(department);
        }

        public async Task DeleteAsync(int id) => await _departmentRepository.DeleteAsync(id);
    }
}
