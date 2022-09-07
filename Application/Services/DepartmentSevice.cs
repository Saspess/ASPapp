using Application.Common.Interfaces.Repositories;
using Application.Services.Common;
using AutoMapper;
using Application.Dtos.Department;
using Application.Common.Exceptions;
using Domain.Entities;
using Application.Common.Interfaces.Services;

namespace Application.Services
{
    public class DepartmentSevice : BaseService, IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentSevice(IMapper mapper, IDepartmentRepository departmentRepository) : base(mapper)
        {
            _departmentRepository = departmentRepository ?? throw new ArgumentNullException(nameof(departmentRepository));
        }
            
        public async Task<IEnumerable<DepartmentDto>> GetAllAsync()
        {
            var departments = await _departmentRepository.GetAllAsync() ?? throw new NotFoundException();
            var departmentsDtos = mapper.Map<IEnumerable<DepartmentDto>>(departments);

            return departmentsDtos;
        }

        public async Task<DepartmentDto> GetByIdAsync(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id) ?? throw new NotFoundException();

            var departmentDto = mapper.Map<DepartmentDto>(department); 

            return departmentDto;
        }

        public async Task CreateAsync(DepartmentForCreateDto departmentForCreateDto)
        {
            if(departmentForCreateDto == null)
            {
                throw new ArgumentNullException(nameof(departmentForCreateDto));
            }

            var department = mapper.Map<Department>(departmentForCreateDto);

            await _departmentRepository.CreateAsync(department);
        }

        public async Task UpdateAsync(DepartmentForUpdateDto departmentForUpdateDto)
        {
            if (departmentForUpdateDto == null)
            {
                throw new ArgumentNullException(nameof(departmentForUpdateDto));
            }

            var checkDepartment = await _departmentRepository.GetByIdAsync(departmentForUpdateDto.Id) ?? throw new NotFoundException();

            var department = mapper.Map<Department>(departmentForUpdateDto);

            await _departmentRepository.UpdateAsync(department);
        }

        public async Task DeleteAsync(int id) 
        {
            var checkDepartment = await _departmentRepository.GetByIdAsync(id) ?? throw new NotFoundException();

            await _departmentRepository.DeleteAsync(id); 
        }
    }
}
