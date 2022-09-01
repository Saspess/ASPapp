using Application.Dtos.Common;

namespace Application.Dtos.Organization
{
    public class OrganizationDto : BaseDto
    {
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}
