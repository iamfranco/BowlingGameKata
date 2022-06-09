using BowlingGame.Models;
using Spectre.Console;

namespace BowlingGame.AppUI;
internal static class AppUIHelpers
{
    public static Table InitialiseScoreTable()
    {
        Table scoreTable = new Table();

        List<string> scoreTableColumnNames = new() { "Total Score" };
        for (int i = 1; i <= Bowling.STANDARD_MAX_FRAMES; i++)
        {
            scoreTableColumnNames.Add($"Frame {i}");
        }
        scoreTable.AddColumns(scoreTableColumnNames.ToArray());
        scoreTable.AddRow("[blue]0[/]");

        AnsiConsole.Write(scoreTable);
        return scoreTable;
    }

    public static void AddCurrentRollToTable(Bowling bowling, Table scoreTable, int frameNumber)
    {
        List<int> currentFrameRolls = bowling.Frames[frameNumber - 1].Rolls;

        UpdateFrameNumberAndCurrentFrameRollsIfBonusRound(bowling, ref frameNumber, ref currentFrameRolls);

        string stringToWrite = $"[172]{string.Join(" ", currentFrameRolls)}[/]";
        scoreTable.UpdateCell(0, frameNumber, stringToWrite);
    }

    public static void UpdateTotalScoreOnTable(Bowling bowling, Table scoreTable)
    {
        scoreTable.UpdateCell(0, 0, $"[blue]{bowling.TotalScore}[/]");
    }

    public static void PrintGameCompletionMessage(Bowling bowling)
    {
        Console.WriteLine("Game is complete! \n\nTotal Score:");
        AnsiConsole.Write(
            new FigletText(bowling.TotalScore.ToString())
                .LeftAligned()
                .Color(Color.Blue));

        Console.WriteLine("Press any key to quit...");
        Console.ReadKey();
    }

    private static void UpdateFrameNumberAndCurrentFrameRollsIfBonusRound(Bowling bowling, ref int frameNumber, ref List<int> currentFrameRolls)
    {
        if (frameNumber > Bowling.STANDARD_MAX_FRAMES)
        {
            var lastFrameRolls = bowling.Frames[Bowling.STANDARD_MAX_FRAMES - 1].Rolls.ToList();
            for (int i = Bowling.STANDARD_MAX_FRAMES; i < bowling.Frames.Count; i++)
            {
                foreach (var roll in bowling.Frames[i].Rolls)
                {
                    lastFrameRolls.Add(roll);
                }
            }

            frameNumber = Math.Min(frameNumber, Bowling.STANDARD_MAX_FRAMES);
            currentFrameRolls = lastFrameRolls;
        }
    }
}
