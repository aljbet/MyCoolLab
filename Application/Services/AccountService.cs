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

    public async Task<Account> GetAccountByNumber(string number, string pin)
    {
        Account? account = await _accountRepository.GetAccountByNumber(number);
        if (account == null) throw new NotFoundException();
        if (account.Pin != pin) throw new BadPasswordException();
        return account;
    }

    public async Task ChangeBalance(long accountId, decimal amount)
    {
        Account? account = await _accountRepository.GetById(accountId);
        if (account == null) throw new NotFoundException();
        if (account.Balance + amount < 0) throw new NotEnoughMoney();
        await _accountRepository.ChangeBalance(accountId, account.Balance + amount);
        await _historyService.MakeHistory(accountId, amount);
    }

    public Task CreateAccount(string number, string pin)
    {
        throw new NotImplementedException();
    }
}