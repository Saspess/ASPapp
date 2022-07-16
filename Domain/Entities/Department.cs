using Domain.Common;

namespace Domain.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public int OrganizationId { get; set; }
        public Organization Organization { get; set; } = null!;

        public int AddressId { get; set; }
        public Address Address { get; set; } = null!;

        public List<Employee> Employees { get; set; } = null!;
    }
}
