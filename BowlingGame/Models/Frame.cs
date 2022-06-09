namespace BowlingGame.Models;
public class Frame
{
    private const int MAX_PINS_COUNT = 10;
    private const int MAX_ROLLS_COUNT = 2;

    private int _pinsCount;

    public List<int> Rolls { get; private set; }
    public FrameStatus Status { get; private set; }

    public Frame()
    {
        _pinsCount = MAX_PINS_COUNT;
        Rolls = new();
        Status = FrameStatus.Incomplete;
    }

    public void AddRoll(int pinsDown)
    {
        if (pinsDown < 0 || pinsDown > _pinsCount)
            throw new ArgumentOutOfRangeException(nameof(pinsDown));

        _pinsCount -= pinsDown;
        Rolls.Add(pinsDown);

        if (pinsDown == MAX_PINS_COUNT)
        {
            Status = FrameStatus.Strike;
            return;
        }

        if (_pinsCount == 0)
        {
            Status = FrameStatus.Spare;
            return;
        }

        if (Rolls.Count == MAX_ROLLS_COUNT)
        {
            Status = FrameStatus.Normal;
            return;
        }
    }
}
