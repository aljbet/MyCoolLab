using Application.Models;
using Application.Repositories;
using Spectre.Console;

namespace Presentation.Scenarios;

public class CreateAccountScenario : ICreateAccountScenario
{
    private readonly IAccountRepository _accountRepository;

    public CreateAccountScenario(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
    }
    public string Name => "Create account";
    public async Task Run(Context context)
    {
        var accountNumber = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter account number: "));
        var pin = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter pin code: ")
                .Secret());
        await _accountRepository.CreateAccount(accountNumber, pin);
    }
}