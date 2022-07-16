using Domain.Common;

namespace Domain.Entities
{
    public class Department : BaseEntity
    {
        public int AddressId { get; set; }
        public int OrganizationId { get; set; }
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public Organization Organization { get; set; } = null!;        
        public Address Address { get; set; } = null!;
        public ICollection<Employee> Employees { get; set; } = null!;
    }
}
