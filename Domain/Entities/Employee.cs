using Domain.Common;

namespace Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateOnly Birthday { get; set; }
        public string PhoneNumber { get; set; } = null!;

        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;

        public int PositionId { get; set; }
        public Position Position { get; set; } = null!;

        public int AddressId { get; set; }
        public Address Address { get; set; } = null!;
    }
}
