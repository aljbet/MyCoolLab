using Spectre.Console;

namespace Presentation.Services;

public class StartService
{
    public void Start()
    {
        string role = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose role:")
                .AddChoices(new List<string>()
                {
                    "Admin", "User"
                })
        );
        AnsiConsole.MarkupLine("your choice: " + role);
    }
}