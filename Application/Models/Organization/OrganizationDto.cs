using Application.Models.Common;

namespace Application.Models.Organization
{
    public class OrganizationDto : BaseDto
    {
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}
