using Domain.Common;

namespace Domain.Entities
{
    public class Position : BaseEntity
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; } = null!;
        public int Salary { get; set; }
    }
}
