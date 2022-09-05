using FluentValidation;
using Application.Dtos.Department;
using Application.Common.Validators.Helpers;

namespace Application.Common.Validators.Department
{
    public abstract class DepartmentManipulateDtoValidator<T> : AbstractValidator<T> where T : DepartmentManipulateDto
    {
        public DepartmentManipulateDtoValidator()
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