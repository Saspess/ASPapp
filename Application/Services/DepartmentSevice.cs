using Application.Common.Exceptions;
using Application.Common.Interfaces.Services;
using Application.Common.Interfaces.UOW;
using Application.Dtos.Department;
using Application.Services.Common;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class DepartmentSevice : BaseService, IDepartmentService
    {
        public DepartmentSevice(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllAsync()
        {
            var departments = await unitOfWork.DepartmentRepository.GetAllAsync();
            var departmentsDtos = mapper.Map<IEnumerable<DepartmentDto>>(departments);

            return departmentsDtos;
        }

        public async Task<DepartmentDto> GetByIdAsync(int id)
        {
            var department = await unitOfWork.DepartmentRepository.GetByIdAsync(id);

            var departmentDto = mapper.Map<DepartmentDto>(department);

            return departmentDto;
        }

        public async Task CreateAsync(DepartmentForCreateDto departmentForCreateDto)
        {
            if (departmentForCreateDto == null)
            {
                throw new ArgumentNullException(nameof(departmentForCreateDto));
            }

            var checkAddress = await unitOfWork.AddressRepository.GetByIdAsync(departmentForCreateDto.AddressId)
                ?? throw new NotFoundException("Address was not found");

            var checkOrganization = await unitOfWork.OrganizationRepository.GetByIdAsync(departmentForCreateDto.OrganizationId)
                ?? throw new NotFoundException("Organization was not found");

            var department = mapper.Map<Department>(departmentForCreateDto);

            await unitOfWork.DepartmentRepository.CreateAsync(department);
        }

        public async Task UpdateAsync(DepartmentForUpdateDto departmentForUpdateDto)
        {
            if (departmentForUpdateDto == null)
            {
                throw new ArgumentNullException(nameof(departmentForUpdateDto));
            }

            var checkDepartment = await unitOfWork.DepartmentRepository.GetByIdAsync(departmentForUpdateDto.Id)
                ?? throw new NotFoundException("Department was not found");

            var checkAddress = await unitOfWork.AddressRepository.GetByIdAsync(departmentForUpdateDto.AddressId)
                ?? throw new NotFoundException("Address was not found");

            var checkOrganization = await unitOfWork.OrganizationRepository.GetByIdAsync(departmentForUpdateDto.OrganizationId)
                ?? throw new NotFoundException("Organization was not found");

            var department = mapper.Map<Department>(departmentForUpdateDto);

            await unitOfWork.DepartmentRepository.UpdateAsync(department);
        }

        public async Task DeleteAsync(int id)
        {
            var checkDepartment = await unitOfWork.DepartmentRepository.GetByIdAsync(id) 
                ?? throw new NotFoundException("Department was not found");

            await unitOfWork.DepartmentRepository.DeleteAsync(id);
        }
    }
}
