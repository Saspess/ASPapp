using FluentValidation;
using Application.Dtos.Organization;

namespace Application.Common.Validators.Organization
{
    public class OrganizationForUpdateDtoValidator : OrganizationManipulateDtoValidator<OrganizationForUpdateDto>
    {
        public OrganizationForUpdateDtoValidator()
        {
            RuleFor(o => o.Id)
                .NotEmpty().WithMessage("Id can't be empty");
        }
    }
}
