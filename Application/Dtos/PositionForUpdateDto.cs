using Application.Dtos.Common;

namespace Application.Dtos
{
    public class PositionForUpdateDto : BaseForUpdateDto
    {
        public string Name { get; set; } = null!;
        public int Salary { get; set; }
    }
}
