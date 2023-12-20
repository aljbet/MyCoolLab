using Application.Models;

namespace Application.Services;

public interface IHistoryService
{
    Task<IEnumerable<History>> GetHistoryByAccountNumber(string number);
}