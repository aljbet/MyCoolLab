using Application.Models;

namespace Application.Repositories;

public interface IAccountRepository
{
    Account? GetAccountByNumber(string number);
    void ChangeBalance(long accountId, decimal amount);
}