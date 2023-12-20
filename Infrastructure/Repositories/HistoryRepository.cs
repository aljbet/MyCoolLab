using Application.Models;
using Application.Repositories;
using Infrastructure.Connection;
using Npgsql;
#pragma warning disable CA2007
namespace Infrastructure.Repositories;

public class HistoryRepository : IHistoryRepository
{
    private ISourceProvider _sourceProvider;

    public HistoryRepository(ISourceProvider sourceProvider)
    {
        _sourceProvider = sourceProvider;
    }

    public async Task<IEnumerable<History>> GetHistoryByAccountNumber(string number)
    {
        await using var command = new NpgsqlCommand(
            "SELECT * FROM history WHERE (SELECT account_id FROM accounts WHERE number = $1) = account_id",
            await _sourceProvider.DataSource.OpenConnectionAsync());
        command.Parameters.AddWithValue(number);
        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();
        List<History> history = new();
        while (await reader.ReadAsync())
        {
            history.Add(new History(
                reader.GetInt64(0),
                reader.GetDecimal(1),
                reader.GetInt64(2)
            ));
        }
        return history;
    }

    public async Task MakeHistory(long accountId, decimal amount)
    {
        await using var command = new NpgsqlCommand(
            "INSERT INTO history (account_id, amount) VALUES ($1, $2)",
            await _sourceProvider.DataSource.OpenConnectionAsync());
        command.Parameters.AddWithValue(accountId);
        command.Parameters.AddWithValue(amount);
        await command.ExecuteNonQueryAsync();
    }
}