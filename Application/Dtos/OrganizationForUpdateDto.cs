using Application.Dtos.Common;

namespace Application.Dtos
{
    public class OrganizationForUpdateDto : BaseForUpdateDto
    {
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}
