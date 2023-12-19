namespace Application.Exceptions;

public class BadPasswordException : Exception
{
    public BadPasswordException(string message)
        : base(message)
    {
    }

    public BadPasswordException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public BadPasswordException()
    {
    }
}