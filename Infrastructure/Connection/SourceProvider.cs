using Npgsql;
#pragma warning disable CA2007
namespace Infrastructure.Connection;

public class SourceProvider : ISourceProvider
{
    public SourceProvider(string connectionString)
    {
        DataSource = NpgsqlDataSource.Create(connectionString);
    }

    public NpgsqlDataSource DataSource { get; }
}