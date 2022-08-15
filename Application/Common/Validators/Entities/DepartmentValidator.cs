using Domain.Entities;
using FluentValidation;
using Application.Common.Validators.Helpers;
using Application.Common.Interfaces.Validators;

namespace Application.Common.Validators.Entities
{
    public class DepartmentValidator : BaseValidator<Department>, IDepartmentValidator
    {
        public DepartmentValidator()
        {
            RuleFor(d => d.AddressId)
                .NotEmpty().WithMessage("Id can't be empty");

            RuleFor(d => d.OrganizationId)
                .NotEmpty().WithMessage("Organization id can't be empty");

            RuleFor(d => d.Name)
                .Must(d => d.All(char.IsLetter)).WithMessage("Error in department name")
                .NotEmpty().WithMessage("Name can't be empty");

            RuleFor(d => d.PhoneNumber)
                .Must(PhoneValidator.IsPhoneValid).WithMessage("Error in phone number name")
                .NotEmpty().WithMessage("Phone number can't be empty");
        }
    }
}
