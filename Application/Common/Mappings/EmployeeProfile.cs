using Application.Models.Employee;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mappings
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>();
        }
    }
}
