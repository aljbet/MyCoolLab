using Application.Exceptions;
using Application.Services;
using Presentation.Scenarios;
using Spectre.Console;

namespace Presentation.Services;

public class StartService
{
    private readonly IAdminService _adminService;
    private readonly IAccountService _accountService;

    private readonly List<IScenario> _adminActions = new List<IScenario>();

    private readonly List<IScenario> _userActions = new List<IScenario>();

    public StartService(IAdminService adminService,
        IAccountService accountService,
        ICreateAccountScenario createAccountScenario,
        IShowBalanceScenario showBalanceScenario,
        IDepositScenario depositMoneyScenario,
        IWithdrawScenario withdrawMoneyScenario,
        IHistoryScenario showHistoryScenario
    )
    {
        _adminService = adminService ?? throw new ArgumentNullException(nameof(adminService));
        _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
        _adminActions.Add(createAccountScenario);
        _userActions.Add(showBalanceScenario);
        _userActions.Add(depositMoneyScenario);
        _userActions.Add(withdrawMoneyScenario);
        _userActions.Add(showHistoryScenario);
        _adminActions.Add(showHistoryScenario);
    }

    public async void Start()
    {
        var role = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose role: ")
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
            if (!await _adminService.LoginAdmin(password)) throw new BadPasswordException("Wrong system password.");
            var adminAction = AnsiConsole.Prompt(
                new SelectionPrompt<IScenario>()
                    .Title("Choose action: ")
                    .AddChoices(_adminActions)
                    .UseConverter(x => x.Name)
            );
        }
        else
        {
            var accountNumber = AnsiConsole.Prompt(
                new TextPrompt<string>("Enter account number: "));
            var pin = AnsiConsole.Prompt(
                new TextPrompt<string>("Enter pin code: ")
                    .Secret());
            var account = await _accountService.GetAccountByNumber(accountNumber, pin);
            var scenario = AnsiConsole.Prompt(
                new SelectionPrompt<IScenario>()
                    .Title("Choose action: ")
                    .AddChoices(_userActions)
                    .UseConverter(x => x.Name)
            );
            await scenario.Run(account);
        }
    }
}