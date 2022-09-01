using Application.Dtos.Common;

namespace Application.Dtos.Employee
{
    public class EmployeeForUpdateDto : EmployeeManipulateDto
    {
        public int Id { get; set; }
    }
}
