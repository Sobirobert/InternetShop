namespace WebAPI.Wrappers;

public class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message) { }
}
