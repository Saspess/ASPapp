using Domain.Common;

namespace Domain.Entities
{
    public class Address : BaseEntity
    {
        public string City { get; set; } = null!;
        public string? Street { get; set; }
        public string? HouseNumber { get; set; }

        public Department Department { get; set; } = null!;

        public Employee Employee { get; set; } = null!;
    }
}
 