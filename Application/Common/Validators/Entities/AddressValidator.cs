using Domain.Entities;
using Application.Common.Interfaces.Validators;
using FluentValidation;

namespace Application.Common.Validators.Entities
{
    public class AddressValidator : BaseValidator<Address>, IAddressValidator
    {
        public AddressValidator()
        {
            RuleFor(a => a.City)
                .Must(a => a.All(char.IsLetter)).WithMessage("Error in city name")
                .NotEmpty().WithMessage("City can't be empty");

            RuleFor(a => a.Street)
                .Must(a => a.All(char.IsLetter)).WithMessage("Error in stret name")
                .NotEmpty().WithMessage("Street can't be empty");

            RuleFor(a => a.HouseNumber)
                .GreaterThan(0).WithMessage("House number must be a number greater than zero")
                .NotEmpty().WithMessage("House number can't be empty");

            RuleFor(a => a.HouseCode)
                .Must(a => a.All(char.IsLetterOrDigit)).WithMessage("House number must be a letter or a digit");
        }
    }
}
