namespace Application.Dtos
{
    public class AddressForCreateDto
    {
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
        public int HouseNumber { get; set; }
        public string? HouseCode { get; set; }
    }
}
