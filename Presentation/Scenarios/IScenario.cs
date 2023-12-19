using Application.Models;

namespace Presentation.Scenarios;

public interface IScenario
{
    string Name { get; }
    Task Run(Account account);
}