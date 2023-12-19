namespace Application.Services;

public interface IAdminService
{
    Task<bool> LoginAdmin(string password);
}