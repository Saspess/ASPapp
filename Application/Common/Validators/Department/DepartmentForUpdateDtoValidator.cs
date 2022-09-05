using FluentValidation;
using Application.Dtos.Department;

namespace Application.Common.Validators.Department
{
    public class DepartmentForUpdateDtoValidator : DepartmentManipulateDtoValidator<DepartmentForUpdateDto>
    {
        public DepartmentForUpdateDtoValidator()
        {
            RuleFor(d => d.Id)
                .NotEmpty().WithMessage("Id can't be empty");
        }
    }
}
