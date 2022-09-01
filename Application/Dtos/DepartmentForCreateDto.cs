namespace Application.Dtos
{
    public class DepartmentForCreateDto
    {
        public int AddressId { get; set; }
        public int OrganizationId { get; set; }
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}
