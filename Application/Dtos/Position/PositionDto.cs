using Application.Dtos.Common;

namespace Application.Dtos.Position
{
    public class PositionDto : BaseDto
    {
        public string Name { get; set; } = null!;
        public int Salary { get; set; }
    }
}
