using FluentValidation;
using Application.Dtos.Organization;
using Application.Common.Validators.Helpers;

namespace Application.Common.Validators.Organization
{
    public abstract class OrganizationManipulateDtoValidator<T> : AbstractValidator<T> where T : OrganizationManipulateDto
    {
        public OrganizationManipulateDtoValidator()
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
