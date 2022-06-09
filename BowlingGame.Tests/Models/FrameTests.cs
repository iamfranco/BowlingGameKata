using BowlingGame.Models;

namespace BowlingGame.Tests.Models;
internal class FrameTests
{
    Frame frame;
    [SetUp]
    public void Setup()
    {
        frame = new();
    }

    [Test]
    public void PinsStillStanding_Should_Return_10_By_Default()
    {
        frame.PinsStillStanding.Should().Be(10);
    }

    [Test]
    public void AddRoll_3_Then_PinsStillStanding_Should_Return_7()
    {
        frame.AddRoll(3);
        frame.PinsStillStanding.Should().Be(7);
    }

    [Test]
    public void Rolls_Should_Return_Empty_List_By_Default()
    {
        frame.Rolls.Count.Should().Be(0);
        frame.Rolls.Should().Equal(new List<int>());
    }

    [Test]
    public void AddRoll_With_PinsDown_Negative_Should_Throw_Exception()
    {
        Action act;

        act = () => frame.AddRoll(-1);
        act.Should().Throw<ArgumentOutOfRangeException>();

        act = () => frame.AddRoll(-2);
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Test]
    public void AddRoll_Twice_With_PinsDown_Sum_More_Than_10_Should_Throw_Exception()
    {
        Action act;

        frame = new();
        frame.AddRoll(7);
        act = () => frame.AddRoll(4);
        act.Should().Throw<ArgumentOutOfRangeException>();

        frame = new();
        frame.AddRoll(5);
        act = () => frame.AddRoll(8);
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Test]
    public void AddRoll_Twice_With_PinsDown_Sum_Less_Than_Or_Equal_To_10_Should_Not_Throw()
    {
        Action act;

        frame = new();
        frame.AddRoll(7);
        act = () => frame.AddRoll(3);
        act.Should().NotThrow();

        frame = new();
        frame.AddRoll(5);
        act = () => frame.AddRoll(4);
        act.Should().NotThrow();
    }

    [Test]
    public void AddRoll_With_Valid_PinsDown_Then_Rolls_Last_Should_Return_PinsDown_Input()
    {
        int pinsDown;

        pinsDown = 4;
        frame.AddRoll(pinsDown);
        frame.Rolls.Last().Should().Be(pinsDown);

        pinsDown = 1;
        frame.AddRoll(pinsDown);
        frame.Rolls.Last().Should().Be(pinsDown);
    }

    [Test]
    public void Status_Should_Return_Incomplete_By_Default()
    {
        frame.Status.Should().Be(FrameStatus.Incomplete);
    }

    [Test]
    public void AddRoll_With_PinsDown_10_Then_Status_Should_Return_Strike()
    {
        frame.AddRoll(10);
        frame.Status.Should().Be(FrameStatus.Strike);
    }

    [Test]
    public void AddRoll_With_PinsDown_Less_Than_10_Then_Status_Should_Return_Incomplete()
    {
        frame.AddRoll(9);
        frame.Status.Should().Be(FrameStatus.Incomplete);
    }

    [Test]
    public void AddRoll_Twice_With_PinsDown_Sum_To_10_Then_Status_Should_Return_Spare()
    {
        frame.AddRoll(4);
        frame.AddRoll(6);
        frame.Status.Should().Be(FrameStatus.Spare);
    }

    [Test]
    public void AddRoll_Twice_With_PinsDown_Sum_Less_Than_10_Then_Status_Should_Return_Normal()
    {
        frame.AddRoll(3);
        frame.AddRoll(6);
        frame.Status.Should().Be(FrameStatus.Normal);
    }
}
