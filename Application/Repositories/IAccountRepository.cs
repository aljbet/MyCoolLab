using Application.Models;

namespace Application.Repositories;

public interface IAccountRepository
{
    Task<Account?> GetAccountByNumber(string number);
    Task<Account?> GetById(long id);
    Task ChangeBalance(long accountId, decimal amount);
    Task CreateAccount(string number, string pin);
}