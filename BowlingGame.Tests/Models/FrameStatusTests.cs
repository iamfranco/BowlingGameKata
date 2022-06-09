using BowlingGame.Models;

namespace BowlingGame.Tests.Models;
internal class FrameStatusTests
{
    [Test]
    public void IsComplete_With_Strike_Should_Return_True()
    {
        FrameStatus.Strike.IsComplete().Should().Be(true);
    }

    [Test]
    public void IsComplete_With_Spare_Should_Return_True()
    {
        FrameStatus.Spare.IsComplete().Should().Be(true);
    }

    [Test]
    public void IsComplete_With_Normal_Should_Return_True()
    {
        FrameStatus.Normal.IsComplete().Should().Be(true);
    }

    [Test]
    public void IsComplete_With_Incomplete_Should_Return_False()
    {
        FrameStatus.Incomplete.IsComplete().Should().Be(false);
    }
}
