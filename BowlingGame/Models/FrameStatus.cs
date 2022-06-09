namespace BowlingGame.Models;
public enum FrameStatus
{
    Strike,
    Spare,
    Normal,
    Incomplete
}

public static class FrameStatusExtensions
{
    public static bool IsComplete(this FrameStatus frameStatus)
    {
        return frameStatus is not FrameStatus.Incomplete;
    }
}
