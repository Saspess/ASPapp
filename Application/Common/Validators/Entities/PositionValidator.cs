using Application.Common.Interfaces.Validators;
using Domain.Entities;
using FluentValidation;

namespace Application.Common.Validators.Entities
{
    public class PositionValidator : BaseValidator<Position>, IPositionValidator
    {
        public PositionValidator()
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
