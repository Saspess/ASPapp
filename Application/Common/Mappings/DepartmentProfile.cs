using Application.Models.Department;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mappings
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentDto>();
        }
    }
}
