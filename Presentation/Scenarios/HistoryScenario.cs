﻿using Application.Models;
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

    public async Task Run(Account account)
    {
        await _historyService.GetHistoryByAccountId(account.Id);
    }
}