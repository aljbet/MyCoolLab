using Application.Models;
using Application.Repositories;
using Infrastructure.Connection;
using Npgsql;

#pragma warning disable CA2007
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
            "SELECT * FROM accounts WHERE number = $1",
            await _sourceProvider.DataSource.OpenConnectionAsync());
        command.Parameters.AddWithValue(number);
        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();
        if (await reader.ReadAsync())
        {
            return new Account(
                reader.GetInt64(0),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetDecimal(3));
        }

        return null;
    }

    public async Task<Account?> GetById(long id)
    {
        await using var command = new NpgsqlCommand(
            "SELECT * FROM accounts WHERE id = $1",
            await _sourceProvider.DataSource.OpenConnectionAsync());
        command.Parameters.AddWithValue(id);
        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();
        if (await reader.ReadAsync())
        {
            return new Account(
                reader.GetInt64(0),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetDecimal(3));
        }

        return null;
    }

    public async Task ChangeBalance(long accountId, decimal amount)
    {
        await using var command = new NpgsqlCommand(
            "UPDATE accounts SET balance = $1 WHERE id = $2",
            await _sourceProvider.DataSource.OpenConnectionAsync());
        command.Parameters.AddWithValue(accountId);
        command.Parameters.AddWithValue(amount);
        await command.ExecuteNonQueryAsync();
    }

    public async Task CreateAccount(string number, string pin)
    {
        await using var command = new NpgsqlCommand(
            "INSERT INTO accounts (number, pin, balance) VALUES ($1, $2, $3)",
            await _sourceProvider.DataSource.OpenConnectionAsync());
        command.Parameters.AddWithValue(number);
        command.Parameters.AddWithValue(pin);
        command.Parameters.AddWithValue(0);
        await command.ExecuteNonQueryAsync();
    }
}