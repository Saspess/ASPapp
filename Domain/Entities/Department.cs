using Domain.Common;

namespace Domain.Entities
{
    public class Department : BaseEntity
    {
        public int OrganizationId { get; set; }
        public int AddresId { get; set; }
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}
