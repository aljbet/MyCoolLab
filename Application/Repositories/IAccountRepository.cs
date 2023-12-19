using Application.Models;

namespace Application.Repositories;

public interface IAccountRepository
{
    Account? GetAccountByNumber(string number);
    Account? GetById(long id);
    void ChangeBalance(long accountId, decimal amount);
}