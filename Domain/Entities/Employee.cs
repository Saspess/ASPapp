using Domain.Common;

namespace Domain.Entities
{
    public class Employee : BaseEntity
    {
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
        public int AddresId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateOnly Birthday { get; set; }
        public string PhoneNumber { get; set; } = null!;
    }
}
