using FluentValidation;
using Application.Dtos.Employee;

namespace Application.Common.Validators.Employee
{
    public class EmployeeForUpdateDtoValidator : EmployeeManipulateDtoValidator<EmployeeForUpdateDto>
    {
        public EmployeeForUpdateDtoValidator()
        {
            RuleFor(e => e.Id)
                .NotEmpty().WithMessage("Id can't be empty");
        }
    }
}
