using Npgsql;

namespace Infrastructure.Connection;

public class SourceProvider : ISourceProvider
{
    public SourceProvider(NpgsqlDataSource dataSource)
    {
        DataSource = dataSource;
    }

    public NpgsqlDataSource DataSource { get; }
}