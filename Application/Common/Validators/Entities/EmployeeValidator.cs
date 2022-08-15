using Application.Common.Validators.Helpers;
using Application.Common.Interfaces.Validators;
using Domain.Entities;
using FluentValidation;

namespace Application.Common.Validators.Entities
{
    public class EmployeeValidator : BaseValidator<Employee>, IEmployeeValidator
    {
        public EmployeeValidator()
        {
            RuleFor(e => e.DepartmentId)
               .NotEmpty().WithMessage("Deparment id can't be empty");

            RuleFor(e => e.PositionId)
                .NotEmpty().WithMessage("Position id can't be empty");

            RuleFor(e => e.FirstName)
                .Must(e => e.All(Char.IsLetter)).WithMessage("Error in first name")
                .NotEmpty().WithMessage("First name can't be empty");

            RuleFor(e => e.LastName)
                .Must(e => e.All(Char.IsLetter)).WithMessage("Error in last name")
                .NotEmpty().WithMessage("Last name can't be empty");

            RuleFor(e => e.PhoneNumber)
                .Must(PhoneValidator.IsPhoneValid).WithMessage("Error in phone number name")
                .NotEmpty().WithMessage("Phone number can't be empty");
        }
    }
}
