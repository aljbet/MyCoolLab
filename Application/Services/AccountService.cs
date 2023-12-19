using Application.Models;
using Application.Repositories;

namespace Application.Services;

public class AccountService : IAccountService
{
    private IAccountRepository _accountRepository;
    private HistoryService _historyService;

    public AccountService(IAccountRepository accountRepository, HistoryService historyService)
    {
        _accountRepository = accountRepository;
        _historyService = historyService;
    }

    public Account GetAccountByNumber(string number, string pin)
    {
        Account? account = _accountRepository.GetAccountByNumber(number);
        if (account == null) throw new ArgumentNullException();
    }

    public void ChangeBalance(long accountId, decimal amount)
    {
        throw new NotImplementedException();
    }
}