﻿using Application.Dtos.Common;

namespace Application.Dtos
{
    public class DepartmentDto : BaseDto
    {
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string OrganizationName { get; set; } = null!;
    }
}