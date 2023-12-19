using Application.Services;
using Spectre.Console;

namespace Presentation.Services;

public class StartService
{
    private readonly IAdminService _adminService;
    private readonly IAccountService _accountService;

    public StartService(IAdminService adminService, IAccountService accountService)
    {
        _adminService = adminService ?? throw new ArgumentNullException(nameof(adminService));
        _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
    }

    public void Start()
    {
        var role = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose role:")
                .AddChoices(new List<string>()
                {
                    "Admin", "User"
                })
        );

        if (role == "Admin")
        {
            var password = AnsiConsole.Prompt(
                new TextPrompt<string>("Enter password: ")
                    .Secret());
            if (!_adminService.LoginAdmin(password))
            {
                // throw exception;
            }
        }
        else
        {
        }
    }
}