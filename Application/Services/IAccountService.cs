using Application.Models;

namespace Application.Services;

public interface IAccountService
{
    Task<Account> GetAccountByNumber(string number, string pin);
    Task ChangeBalance(long accountId, decimal amount);
    Task CreateAccount(string number, string pin);
}