using Application.Models;

namespace Presentation;

public class Context
{
    public bool IsAdmin { get; }
    public Account? Account { get; }

    public Context()
    {
        IsAdmin = true;
        Account = null;
    }

    public Context(Account account)
    {
        IsAdmin = false;
        Account = account ?? throw new ArgumentNullException(nameof(account));
    }
}