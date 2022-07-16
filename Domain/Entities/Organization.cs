using Domain.Common;

namespace Domain.Entities
{
    public class Organization : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public ICollection<Department> Departments { get; set; } = null!;
    }
}
