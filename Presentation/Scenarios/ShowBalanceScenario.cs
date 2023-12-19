using Application.Models;
using Spectre.Console;

namespace Presentation.Scenarios;

public class ShowBalanceScenario : IShowBalanceScenario
{ 
    public string Name => "Show balance";
    public Task Run(Account account)
    {
        AnsiConsole.MarkupLine($"Your balance is {account.Balance}.");
        return Task.CompletedTask;
    }
}