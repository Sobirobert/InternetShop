namespace WebAPI.Wrappers;

public class ConflictException : Exception
{
    public ConflictException(string message) : base(message) { }
}
