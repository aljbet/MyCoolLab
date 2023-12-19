using Application.Models;
using Application.Repositories;

namespace Application.Services;

public class HistoryService : IHistoryService
{
    private IHistoryRepository _historyRepository;

    public HistoryService(IHistoryRepository historyRepository)
    {
        _historyRepository = historyRepository;
    }

    public IEnumerable<History> GetHistoryByAccountId(long accountId)
    {
        return _historyRepository.GetHistoryByAccountId(accountId);
    }
}