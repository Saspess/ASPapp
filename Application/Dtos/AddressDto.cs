using Application.Dtos.Common;

namespace Application.Dtos
{
    public class AddressDto : BaseDto
    {
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
        public int HouseNumber { get; set; }
        public string? HouseCode { get; set; }
    }
}
