using Domain.Common;
using FluentValidation.Results;

namespace Application.Common.Interfaces.Validators
{
    public interface IBaseValidator<TEntity> where TEntity : BaseEntity
    {
        ValidationResult Validate(TEntity entity);
    }
}
