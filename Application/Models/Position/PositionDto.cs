using Application.Models.Common;

namespace Application.Models.Position
{
    public class PositionDto : BaseDto
    {
        public string Name { get; set; } = null!;
        public int Salary { get; set; }
    }
}
