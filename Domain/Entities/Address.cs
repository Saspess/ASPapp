using Domain.Common;

namespace Domain.Entities
{
    public class Address : BaseEntity
    {
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
        public int HouseNumber { get; set; } 
        public string? HouseCode { get; set; }
        
        public Department Department { get; set; } = null!;
    }
}
 