using Application.Models;
using Application.Repositories;

namespace Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    public Account? GetAccountByNumber(string number)
    {
        throw new NotImplementedException();
    }

    public Account? GetById(long id)
    {
        throw new NotImplementedException();
    }

    public void ChangeBalance(long accountId, decimal amount)
    {
        throw new NotImplementedException();
    }
}