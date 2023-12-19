namespace Application.Services;

public class AdminService: IAdminService
{
    private string _password;

    public AdminService(string password)
    {
        _password = password;
    }

    public Task<bool> LoginAdmin(string password)
    {
        return _password == password;
    }
}