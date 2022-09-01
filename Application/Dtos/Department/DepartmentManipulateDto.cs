namespace Application.Dtos.Department
{
    public abstract class DepartmentManipulateDto
    {
        public int AddressId { get; set; }
        public int OrganizationId { get; set; }
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}
