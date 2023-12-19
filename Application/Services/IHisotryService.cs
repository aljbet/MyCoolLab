using Application.Models;

namespace Application.Services;

public interface IHisotryService
{
    IEnumerable<History> GetHistoryByAccountId(long accountId);
}