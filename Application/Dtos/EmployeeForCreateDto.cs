﻿namespace Application.Dtos
{
    public class EmployeeForCreateDto
    {
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateOnly Birthday { get; set; }
        public string PhoneNumber { get; set; } = null!;
    }
}
