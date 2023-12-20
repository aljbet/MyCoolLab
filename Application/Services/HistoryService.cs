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

    public Task<IEnumerable<History>> GetHistoryByAccountNumber(string number)
    {
        return _historyRepository.GetHistoryByAccountNumber(number);
    }
}