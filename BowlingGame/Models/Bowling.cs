namespace BowlingGame.Models;
public class Bowling
{
    public const int STANDARD_MAX_FRAMES = 10;
    private readonly ScoreCalculator _scoreCalculator;
    private int _bonusRolls;

    public List<Frame> Frames { get; private set; }
    public int TotalScore { get; private set; }
    public bool IsComplete { get; private set; }

    public Bowling()
    {
        _scoreCalculator = new();
        _bonusRolls = 0;
        Frames = new() { new Frame() };
        TotalScore = 0;
        IsComplete = false;
    }

    public void Roll(int pinsDown)
    {
        if (IsComplete)
            throw new Exception("Game is completed, cannot roll more.");

        Frame currentFrame = Frames.Last();

        currentFrame.AddRoll(pinsDown);

        TotalScore += _scoreCalculator.CalculateCurrentRollScore(currentFrame, Frames.Count - 1);
        UpdateBonusRollsAndIsComplete(currentFrame);
        PrepareNextFrame();
    }

    private void UpdateBonusRollsAndIsComplete(Frame currentFrame)
    {
        _bonusRolls--;
        _bonusRolls = _bonusRolls < 0 ? 0 : _bonusRolls;
        if (Frames.Count == STANDARD_MAX_FRAMES)
        {
            if (currentFrame.Status is FrameStatus.Strike)
                _bonusRolls += 2;

            if (currentFrame.Status is FrameStatus.Spare)
                _bonusRolls++;
        }

        if (Frames.Count == STANDARD_MAX_FRAMES && currentFrame.Status.IsComplete() && _bonusRolls == 0)
            IsComplete = true;

        if (Frames.Count > STANDARD_MAX_FRAMES && _bonusRolls == 0)
            IsComplete = true;
    }

    private void PrepareNextFrame()
    {
        if (Frames.Last().Status.IsComplete())
            Frames.Add(new());
    }
}
