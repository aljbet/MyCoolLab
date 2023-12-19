using Application.Models;

namespace Presentation.Scenarios;

public class CreateAccountScenario : ICreateAccountScenario
{
    public string Name => "Create account";
    public Task Run(Account account)
    {
        throw new NotImplementedException();
    }
}