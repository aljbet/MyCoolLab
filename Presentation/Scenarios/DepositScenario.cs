using Application.Exceptions;
using Application.Services;
using Spectre.Console;

namespace Presentation.Scenarios;

public class DepositScenario : IDepositScenario
{
    private readonly IAccountService _accountService;

    public DepositScenario(IAccountService accountService)
    {
        _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
    }

    public string Name => "Deposit money";

    public async Task Run(Context context)
    {
        if (context.Account is null) throw new NotFoundException();
        var money = AnsiConsole.Prompt(
            new TextPrompt<int>("Enter amount of money: "));
        await _accountService.ChangeBalance(context.Account.Id, money);
    }
}