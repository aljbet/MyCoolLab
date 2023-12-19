using Application.Exceptions;
using Application.Models;
using Application.Services;
using Spectre.Console;

namespace Presentation.Scenarios;

public class HistoryScenario : IHistoryScenario
{
    private readonly IHistoryService _historyService;

    public HistoryScenario(IHistoryService historyService)
    {
        _historyService = historyService ?? throw new ArgumentNullException(nameof(historyService));
    }

    public string Name => "Show history";

    public async Task Run(Context context)
    {
        if (!context.IsAdmin)
        {
            if (context.Account is null) throw new NotFoundException();
            await _historyService.GetHistoryByAccountId(context.Account.Number);
        }
        else
        {
            var accountNumber = AnsiConsole.Prompt(
                new TextPrompt<string>("Enter account number: "));
            await _historyService.GetHistoryByAccountId(accountNumber);
        }
    }
}