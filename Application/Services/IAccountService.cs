using Application.Models;

namespace Application.Services;

public interface IAccountService
{
    Account GetAccountByNumber(string number, string pin);
    void ChangeBalance(long accountId, decimal amount);
}