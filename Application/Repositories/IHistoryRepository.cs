using Application.Models;

namespace Application.Repositories;

public interface IHistoryRepository
{
    Task<IEnumerable<History>> GetHistoryByAccountId(long accountId);
    Task MakeHistory(long accountId, decimal amount);
}