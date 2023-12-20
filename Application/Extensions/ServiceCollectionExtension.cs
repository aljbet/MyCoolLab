using Application.Repositories;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services, string password)
    {
        services.AddSingleton<IHistoryService, HistoryService>();
        services.AddSingleton<IAccountService, AccountService>();
        services.AddSingleton<IAdminService>(new AdminService(password));
    }
}