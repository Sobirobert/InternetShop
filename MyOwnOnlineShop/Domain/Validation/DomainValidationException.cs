namespace Domain.Validation;

public class DomainValidationException : Exception
{
    public IReadOnlyList<string> Errors { get; }

    public DomainValidationException(string message, IReadOnlyList<string> errors)
        : base(message)
    {
        Errors = errors;
    }
}
