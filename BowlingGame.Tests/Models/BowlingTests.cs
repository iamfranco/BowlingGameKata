using BowlingGame.Models;

namespace BowlingGame.Tests.Models;
internal class BowlingTests
{
    Bowling bowling;
    [SetUp]
    public void Setup()
    {
        bowling = new();
    }

    [Test]
    public void Frames_Should_Return_Containe_One_Frame_By_Default()
    {
        bowling.Frames.Count.Should().Be(1);
        bowling.Frames[0].Rolls.Should().Equal(new List<int>());
    }

    [Test]
    public void TotalScore_Should_Return_0_By_Default()
    {
        bowling.TotalScore.Should().Be(0);
    }

    [Test]
    public void Roll_With_1_Should_Update_Frames_And_TotalScore_Correctly()
    {
        int pinsDown = 1;

        bowling.Roll(pinsDown);

        bowling.Frames.Count.Should().Be(1);
        bowling.Frames[0].Rolls.Should().Equal(new List<int>() { pinsDown });
        bowling.TotalScore.Should().Be(pinsDown);
    }

    [Test]
    public void Roll_With_1_2_Should_Update_Frames_And_TotalScore_Correctly()
    {
        bowling.Roll(1);
        bowling.Roll(2);

        bowling.Frames.Count.Should().Be(2);
        bowling.Frames[0].Rolls.Should().Equal(new List<int>() { 1, 2 });
        bowling.Frames[1].Rolls.Should().Equal(new List<int>());
        bowling.TotalScore.Should().Be(3);
    }

    [Test]
    public void Roll_With_1_2_3_Should_Update_Frames_And_TotalScore_Correctly()
    {
        bowling.Roll(1);
        bowling.Roll(2);
        bowling.Roll(3);

        bowling.Frames.Count.Should().Be(2);
        bowling.Frames[0].Rolls.Should().Equal(new List<int>() { 1, 2 });
        bowling.Frames[1].Rolls.Should().Equal(new List<int>() { 3 });
        bowling.TotalScore.Should().Be(6);
    }

    [Test]
    public void Roll_With_Strike_1_2_Should_Update_Frames_And_TotalScore_Correctly()
    {
        bowling.Roll(10);
        bowling.Roll(1);
        bowling.Roll(2);

        bowling.Frames.Count.Should().Be(3);
        bowling.Frames[0].Rolls.Should().Equal(new List<int>() { 10 });
        bowling.Frames[1].Rolls.Should().Equal(new List<int>() { 1, 2 });
        bowling.Frames[2].Rolls.Should().Equal(new List<int>());
        bowling.TotalScore.Should().Be(16);
    }

    [Test]
    public void Roll_With_Spare_1_2_Should_Update_Frames_And_TotalScore_Correctly()
    {
        bowling.Roll(4);
        bowling.Roll(6);
        bowling.Roll(1);
        bowling.Roll(2);

        bowling.Frames.Count.Should().Be(3);
        bowling.Frames[0].Rolls.Should().Equal(new List<int>() { 4, 6 });
        bowling.Frames[1].Rolls.Should().Equal(new List<int>() { 1, 2 });
        bowling.Frames[2].Rolls.Should().Equal(new List<int>());
        bowling.TotalScore.Should().Be(14);
    }

    [Test]
    public void Roll_With_12_Strikes_Then_TotalScore_Should_Return_300()
    {
        for (int i=0; i<12; i++)
        {
            bowling.Roll(10);
        }

        bowling.TotalScore.Should().Be(300);
    }

    [Test]
    public void Roll_With_No_Strike_Or_Spare_On_10th_Frame_Then_IsComplete_Should_Return_True()
    {
        for (int i = 0; i < 9; i++)
        {
            bowling.Roll(2);
            bowling.Roll(3);
        }

        bowling.Roll(2);
        bowling.IsComplete.Should().Be(false);

        bowling.Roll(3);
        bowling.IsComplete.Should().Be(true);
    }

    [Test]
    public void Roll_With_Spare_On_10th_Frame_Then_Roll_1_Then_IsComplete_Should_Return_True()
    {
        for (int i = 0; i < 9; i++)
        {
            bowling.Roll(2);
            bowling.Roll(3);
        }

        bowling.Roll(4);
        bowling.Roll(6);
        bowling.IsComplete.Should().Be(false);

        bowling.Roll(1);

        bowling.IsComplete.Should().Be(true);
    }

    [Test]
    public void Roll_With_Spare_On_10th_Frame_Then_Roll_Strike_Then_IsComplete_Should_Return_True()
    {
        for (int i = 0; i < 9; i++)
        {
            bowling.Roll(2);
            bowling.Roll(3);
        }

        bowling.Roll(4);
        bowling.Roll(6);
        bowling.IsComplete.Should().Be(false);

        bowling.Roll(10);

        bowling.IsComplete.Should().Be(true);
    }

    [Test]
    public void Roll_With_Strike_On_10th_Frame_Then_Roll_1_2_Then_IsComplete_Should_Return_True()
    {
        for (int i = 0; i < 9; i++)
        {
            bowling.Roll(2);
            bowling.Roll(3);
        }

        bowling.Roll(10);
        bowling.IsComplete.Should().Be(false);

        bowling.Roll(1);
        bowling.IsComplete.Should().Be(false);

        bowling.Roll(2);
        bowling.IsComplete.Should().Be(true);
    }

    [Test]
    public void Roll_With_Strike_On_10th_Frame_Then_Roll_Strike_1_Then_IsComplete_Should_Return_True()
    {
        for (int i = 0; i < 9; i++)
        {
            bowling.Roll(2);
            bowling.Roll(3);
        }

        bowling.Roll(10);
        bowling.IsComplete.Should().Be(false);

        bowling.Roll(10);
        bowling.IsComplete.Should().Be(false);

        bowling.Roll(1);
        bowling.IsComplete.Should().Be(true);
    }

    [Test]
    public void Roll_With_Strike_On_10th_Frame_Then_Roll_Strike_Strike_Then_IsComplete_Should_Return_True()
    {
        for (int i = 0; i < 9; i++)
        {
            bowling.Roll(2);
            bowling.Roll(3);
        }

        bowling.Roll(10);
        bowling.IsComplete.Should().Be(false);

        bowling.Roll(10);
        bowling.IsComplete.Should().Be(false);

        bowling.Roll(10);
        bowling.IsComplete.Should().Be(true);
    }

    [Test]
    public void Roll_After_IsComplete_True_Should_Throw_Exception()
    {
        for (int i=0; i<10; i++)
        {
            bowling.Roll(2);
            bowling.Roll(3);
        }

        bowling.IsComplete.Should().Be(true);

        Action act = () => bowling.Roll(1);

        act.Should().Throw<Exception>();
    }
}
