using Application.Common.Exceptions;
using Application.Common.Interfaces.Services;
using Application.Common.Interfaces.UOW;
using Application.Dtos.Employee;
using Application.Services.Common;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        public EmployeeService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            var employees = await unitOfWork.EmployeeRepository.GetAllAsync();
            var employeesDtos = mapper.Map<IEnumerable<EmployeeDto>>(employees);

            return employeesDtos;
        }

        public async Task<EmployeeDto> GetByIdAsync(int id)
        {
            var employee = await unitOfWork.EmployeeRepository.GetByIdAsync(id);

            var employeeDto = mapper.Map<EmployeeDto>(employee);

            return employeeDto;
        }

        public async Task CreateAsync(EmployeeForCreateDto employeeForCreateDto)
        {
            if (employeeForCreateDto == null)
            {
                throw new ArgumentNullException(nameof(employeeForCreateDto));
            }

            var checkDepartment = await unitOfWork.DepartmentRepository.GetByIdAsync(employeeForCreateDto.DepartmentId)
                ?? throw new NotFoundException("Department was not found");

            var checkPosition = await unitOfWork.PositionRepository.GetByIdAsync(employeeForCreateDto.PositionId)
                ?? throw new NotFoundException("Position was not found");

            var employee = mapper.Map<Employee>(employeeForCreateDto);

            await unitOfWork.EmployeeRepository.CreateAsync(employee);
        }

        public async Task UpdateAsync(EmployeeForUpdateDto employeeForUpdateDto)
        {
            if (employeeForUpdateDto == null)
            {
                throw new ArgumentNullException(nameof(employeeForUpdateDto));
            }

            var checkEmployee = await unitOfWork.EmployeeRepository.GetByIdAsync(employeeForUpdateDto.Id)
                ?? throw new NotFoundException("Employee was not found");

            var checkDepartment = await unitOfWork.DepartmentRepository.GetByIdAsync(employeeForUpdateDto.DepartmentId)
                ?? throw new NotFoundException("Department was not found");

            var checkPosition = await unitOfWork.PositionRepository.GetByIdAsync(employeeForUpdateDto.PositionId)
                ?? throw new NotFoundException("Position was not found");

            var employee = mapper.Map<Employee>(employeeForUpdateDto);

            await unitOfWork.EmployeeRepository.UpdateAsync(employee);
        }

        public async Task DeleteAsync(int id)
        {
            var checkEmployee = await unitOfWork.EmployeeRepository.GetByIdAsync(id) 
                ?? throw new NotFoundException("Employee was not found");

            await unitOfWork.EmployeeRepository.DeleteAsync(id);
        }
    }
}
