using FluentValidation;
using Application.Dtos.Position;

namespace Application.Common.Validators.Position
{
    public class PositionForUpdateDtoValidator : PositionManipulateDtoValidator<PositionForUpdateDto>
    {
        public PositionForUpdateDtoValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("Id can't be empty");
        }
    }
}
