using Application.Models;

namespace Application.Services;

public interface IHistoryService
{
    IEnumerable<History> GetHistoryByAccountId(long accountId);
}