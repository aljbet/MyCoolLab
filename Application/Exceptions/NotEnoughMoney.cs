namespace Application.Exceptions;

public class NotEnoughMoney : Exception
{
    public NotEnoughMoney(string message)
        : base(message)
    {
    }

    public NotEnoughMoney(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public NotEnoughMoney()
    {
    }
}