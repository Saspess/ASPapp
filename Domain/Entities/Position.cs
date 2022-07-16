using Domain.Common;

namespace Domain.Entities
{
    public class Position : BaseEntity
    {
        public string Name { get; set; } = null!;
        public int Salary { get; set; }

        public Employee Employee { get; set; } = null!;
    }
}
