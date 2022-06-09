namespace BowlingGame.Models;
public class ScoreCalculator
{
    private const int MAX_FRAME_INDEX_WITH_BONUS = 9;

    private int _currentMultipler;
    private int _nextMultiplier;

    public ScoreCalculator()
    {
        _currentMultipler = 1;
        _nextMultiplier = 1;
    }

    public int CalculateCurrentRollScore(Frame frame, int frameIndex)
    {
        if (!frame.Rolls.Any())
            return 0;

        int currentRoll = frame.Rolls.Last();
        int score = currentRoll * _currentMultipler;

        UpdateMultiplier(frame, frameIndex);

        return score;
    }
    
    private void UpdateMultiplier(Frame frame, int frameIndex)
    {
        _currentMultipler = _nextMultiplier;
        _nextMultiplier = 1;

        if (frameIndex >= MAX_FRAME_INDEX_WITH_BONUS)
            return;

        if (frame.Status is FrameStatus.Strike)
        {
            _currentMultipler++;
            _nextMultiplier++;
        }

        if (frame.Status is FrameStatus.Spare)
        {
            _currentMultipler++;
        }
    }
}
