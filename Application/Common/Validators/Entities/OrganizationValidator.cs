using Application.Common.Validators.Helpers;
using Application.Common.Interfaces.Validators;
using Domain.Entities;
using FluentValidation;

namespace Application.Common.Validators.Entities
{
    public class OrganizationValidator : BaseValidator<Organization>, IOrganizationValidator
    {
        public OrganizationValidator()
        {
            RuleFor(o => o.Name)
                .Must(o => o.All(char.IsLetter)).WithMessage("Error in organization name")
                .NotEmpty().WithMessage("Organization name can't be empty");

            RuleFor(o => o.PhoneNumber)
                .Must(PhoneValidator.IsPhoneValid).WithMessage("Error in phone number name")
                .NotEmpty().WithMessage("Phone number can't be empty");
        }
    }
}
