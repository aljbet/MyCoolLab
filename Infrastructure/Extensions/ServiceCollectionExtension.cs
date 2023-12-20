using Application.Repositories;
using Infrastructure.Connection;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace Infrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddSingleton<ISourceProvider>(new SourceProvider(connectionString));
        services.AddSingleton<IAccountRepository, AccountRepository>();
        services.AddSingleton<IHistoryRepository, HistoryRepository>();
    }
}