using Application.Models.Common;

namespace Application.Models.Address
{
    public class AddressDto : BaseDto
    {
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
        public int HouseNumber { get; set; }
        public string? HouseCode { get; set; }
    }
}
