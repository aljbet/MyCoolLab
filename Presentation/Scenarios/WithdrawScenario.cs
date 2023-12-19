using Application.Models;
using Application.Services;
using Spectre.Console;

namespace Presentation.Scenarios;

public class WithdrawScenario : IWithdrawScenario
{
    private readonly IAccountService _accountService;

    public WithdrawScenario(IAccountService accountService)
    {
        _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
    }

    public string Name => "Withdraw money";

    public async Task Run(Account account)
    {
        var money = AnsiConsole.Prompt(
            new TextPrompt<int>("Enter amount of money: "));
        await _accountService.ChangeBalance(account.Id, -money);
    }
}