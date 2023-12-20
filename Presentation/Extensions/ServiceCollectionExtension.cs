using Microsoft.Extensions.DependencyInjection;
using Presentation.Scenarios;

namespace Presentation.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddPresentation(this IServiceCollection services)
    {
        services.AddSingleton<ICreateAccountScenario, CreateAccountScenario>();
        services.AddSingleton<IShowBalanceScenario, ShowBalanceScenario>();
        services.AddSingleton<IWithdrawScenario, WithdrawScenario>();
        services.AddSingleton<IHistoryScenario, HistoryScenario>();
        services.AddSingleton<IDepositScenario, DepositScenario>();
        services.AddSingleton<IStartService, StartService>();
    }
}