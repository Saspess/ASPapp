using Application.Common.Interfaces.Repositories;
using Application.Services.Common;
using AutoMapper;
using Application.Dtos.Employee;
using Application.Common.Exceptions;
using Domain.Entities;
using Application.Common.Interfaces.Services;

namespace Application.Services
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IMapper mapper, IEmployeeRepository employeeRepository) : base(mapper)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            var employees = await _employeeRepository.GetAllAsync() ?? throw new NotFoundException();
            var employeesDtos = mapper.Map<IEnumerable<EmployeeDto>>(employees);

            return employeesDtos;
        }

        public async Task<EmployeeDto> GetByIdAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id) ?? throw new NotFoundException();

            var employeeDto = mapper.Map<EmployeeDto>(employee);

            return employeeDto;
        }

        public async Task CreateAsync(EmployeeForCreateDto employeeForCreateDto)
        {
            if(employeeForCreateDto == null)
            {
                throw new ArgumentNullException(nameof(employeeForCreateDto));
            }

            var employee = mapper.Map<Employee>(employeeForCreateDto);

            await _employeeRepository.CreateAsync(employee);
        }

        public async Task UpdateAsync(EmployeeForUpdateDto employeeForUpdateDto)
        {
            if(employeeForUpdateDto == null)
            {
                throw new ArgumentNullException(nameof(employeeForUpdateDto));
            }

            var checkEmployee = await _employeeRepository.GetByIdAsync(employeeForUpdateDto.Id) ?? throw new NotFoundException();

            var employee = mapper.Map<Employee>(employeeForUpdateDto);

            await _employeeRepository.UpdateAsync(employee);
        }

        public async Task DeleteAsync(int id)
        {
            var checkEmployee = await _employeeRepository.GetByIdAsync(id) ?? throw new NotFoundException();

            await _employeeRepository.DeleteAsync(id);
        }
    }
}
