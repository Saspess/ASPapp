namespace Application.Dtos.Employee
{
    public abstract class EmployeeManipulateDto
    {
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateOnly Birthday { get; set; }
        public string PhoneNumber { get; set; } = null!;
    }
}
