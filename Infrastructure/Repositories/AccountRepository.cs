using Application.Models;
using Application.Repositories;
using Infrastructure.Connection;
#pr
namespace Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    private ISourceProvider _sourceProvider;

    public AccountRepository(ISourceProvider sourceProvider)
    {
        _sourceProvider = sourceProvider;
    }

    public async Task<Account?> GetAccountByNumber(string number)
    {
        await using var command = new NpgsqlCommand(
            "INSERT INTO accounts (balance, user_id) VALUES ($1, $2);",
            await _connectionProvider.ConnectionSource.OpenConnectionAsync());
    }

    public Task<Account?> GetById(long id)
    {
        throw new NotImplementedException();
    }

    public Task ChangeBalance(long accountId, decimal amount)
    {
        throw new NotImplementedException();
    }
}