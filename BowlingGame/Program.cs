using BowlingGame.AppUI;
using BowlingGame.Models;
using Spectre.Console;

Bowling bowling = new();
Table scoreTable = AppUIHelpers.InitialiseScoreTable();

while (!bowling.IsComplete)
{
    int pinsStillStanding = bowling.Frames.Last().PinsStillStanding;
    int frameNumber = bowling.Frames.Count;

    int pinsDown = AnsiConsole.Prompt(
        new TextPrompt<int>($"Roll a bowling ball, [green]how many pins[/] did the ball knock down? (0 to {pinsStillStanding})")
            .ValidationErrorMessage($"[red]Number of pins knocked down must be between 0 and {pinsStillStanding}[/]")
            .Validate(input => input >= 0 && input <= pinsStillStanding));

    bowling.Roll(pinsDown);

    AppUIHelpers.UpdateTotalScoreOnTable(bowling, scoreTable);
    AppUIHelpers.AddCurrentRollToTable(bowling, scoreTable, frameNumber);

    Console.Clear();
    AnsiConsole.Write(scoreTable);
}

AppUIHelpers.PrintGameCompletionMessage(bowling);