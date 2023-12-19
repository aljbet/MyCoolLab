using Application.Models;
using Application.Repositories;
#pragma warning disable CA2007
namespace Application.Services;

public class HistoryService : IHistoryService
{
    private IHistoryRepository _historyRepository;

    public HistoryService(IHistoryRepository historyRepository)
    {
        _historyRepository = historyRepository;
    }

    public Task<IEnumerable<History>> GetHistoryByAccountId(long accountId)
    {
        return _historyRepository.GetHistoryByAccountId(accountId);
    }
}