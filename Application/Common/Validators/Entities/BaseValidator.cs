using Domain.Common;
using Application.Common.Interfaces.Validators;
using FluentValidation;

namespace Application.Common.Validators.Entities
{
    public abstract class BaseValidator<TEntity> : AbstractValidator<TEntity> where TEntity : BaseEntity
    {
        public BaseValidator()
        {
            RuleFor(b => b.Id)
                .NotEmpty().WithMessage("Id can't be empty");
        }
    }
}
