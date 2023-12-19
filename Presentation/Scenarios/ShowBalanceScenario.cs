using Application.Exceptions;
using Spectre.Console;

namespace Presentation.Scenarios;

public class ShowBalanceScenario : IShowBalanceScenario
{ 
    public string Name => "Show balance";
    public Task Run(Context context)
    {
        if (context.Account is null) throw new NotFoundException();
        AnsiConsole.MarkupLine($"Your balance is {context.Account.Balance}.");
        return Task.CompletedTask;
    }
}