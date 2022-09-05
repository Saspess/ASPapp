using FluentValidation;
using Application.Dtos.Position;

namespace Application.Common.Validators.Position
{
    public abstract class PositionManipulateDtoValidator<T> : AbstractValidator<T> where T : PositionManupulateDto
    {
        public PositionManipulateDtoValidator()
        {
            RuleFor(p => p.Name)
                .Must(p => p.All(char.IsLetter)).WithMessage("Error in position name")
                .NotEmpty().WithMessage("Position name can't be empty");

            RuleFor(p => p.Salary)
                .GreaterThan(0).WithMessage("Salary must be greater than 0")
                .NotEmpty().WithMessage("Salary can't be empty");
        }
    }
}
