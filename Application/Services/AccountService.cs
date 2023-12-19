using Application.Exceptions;
using Application.Models;
using Application.Repositories;

namespace Application.Services;

public class AccountService : IAccountService
{
    private IAccountRepository _accountRepository;
    private IHistoryRepository _historyService;

    public AccountService(IAccountRepository accountRepository, IHistoryRepository historyService)
    {
        _accountRepository = accountRepository;
        _historyService = historyService;
    }

    public Task<Account> GetAccountByNumber(string number, string pin)
    {
        Account? account = _accountRepository.GetAccountByNumber(number);
        if (account == null) throw new NotFoundException();
        if (account.Pin != pin) throw new BadPasswordException();
        return account;
    }

    public Task ChangeBalance(long accountId, decimal amount)
    {
        Account? account = _accountRepository.GetById(accountId);
        if (account == null) throw new NotFoundException();
        if (account.Balance + amount < 0) throw new NotEnoughMoney();
        _accountRepository.ChangeBalance(accountId, account.Balance + amount);
        _historyService.MakeHistory(accountId, amount);
    }
}