namespace WebAPI.Wrappers;

public class NullRequestExeption : Exception
{
    public NullRequestExeption(string message) : base(message) { }
}

