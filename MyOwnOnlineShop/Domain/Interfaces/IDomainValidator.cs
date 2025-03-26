using Domain.Validation;

namespace Domain.Interfaces;

public interface IDomainValidator<T>
{
    ValidationResult Validate(T entity);
}
