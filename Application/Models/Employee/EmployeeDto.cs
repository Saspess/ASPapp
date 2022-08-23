using Application.Models.Common;

namespace Application.Models.Employee
{
    public class EmployeeDto : BaseDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateOnly Birthday { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string DepartmentName { get; set; } = null!;
        public string PositionName { get; set; } = null!;
    }
}
