using Npgsql;

namespace Infrastructure.Connection;

public interface ISourceProvider
{
    public NpgsqlDataSource DataSource { get; }
}