using Application.Dtos.Common;

namespace Application.Dtos
{
    public class AddressForUpdateDto : BaseForUpdateDto
    {
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
        public int HouseNumber { get; set; }
        public string? HouseCode { get; set; }
    }
}
