using Application.Models;

namespace Application.Repositories;

public interface IHistoryRepository
{
    IEnumerable<History> GetHistoryByAccountId(long accountId);
    void MakeHistory(long accountId, decimal amount);
}