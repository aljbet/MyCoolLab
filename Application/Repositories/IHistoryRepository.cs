using Application.Models;

namespace Application.Repositories;

public interface IHistoryRepository
{
    Task<IEnumerable<History>> GetHistoryByAccountNumber(string number);
    Task MakeHistory(long accountId, decimal amount);
}