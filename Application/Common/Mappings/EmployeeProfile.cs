﻿using Application.Dtos.Employee;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mappings
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>();

            CreateMap<Employee, EmployeeForCreateDto>();

            CreateMap<Employee, EmployeeForUpdateDto>();
        }
    }
}
