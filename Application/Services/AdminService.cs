namespace Application.Services;
#pragma warning disable CA2007
public class AdminService: IAdminService
{
    private string _password;

    public AdminService(string password)
    {
        _password = password;
    }

    public Task<bool> LoginAdmin(string password)
    {
        return Task.FromResult(_password == password);
    }
}