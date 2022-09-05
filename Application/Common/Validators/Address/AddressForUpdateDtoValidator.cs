using FluentValidation;
using Application.Dtos.Address;

namespace Application.Common.Validators.Address
{
    public class AddressForUpdateDtoValidator : AddressManipulateDtoValidator<AddressForUpdateDto>
    {
        public AddressForUpdateDtoValidator()
        {
            RuleFor(a => a.Id)
                .NotEmpty().WithMessage("Id can't be empty");
        }
    }
}
