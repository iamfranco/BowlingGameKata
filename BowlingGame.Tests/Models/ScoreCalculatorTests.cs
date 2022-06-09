using BowlingGame.Models;

namespace BowlingGame.Tests.Models;
internal class ScoreCalculatorTests
{
    Frame frame;
    int frameIndex;
    ScoreCalculator scoreCalculator;
    [SetUp]
    public void Setup()
    {
        frame = new();
        frameIndex = 0;
        scoreCalculator = new();
    }

    [Test]
    public void CalculateCurrentRollScore_With_Empty_Frame_Should_Return_0()
    {
        int score = scoreCalculator.CalculateCurrentRollScore(frame, frameIndex);
        score.Should().Be(0);
    }

    [Test]
    public void CalculateCurrentRollScore_With_Frame_With_One_Roll_With_No_Strike_Or_Spare_Previously_Should_Return_Roll_Value()
    {
        int rollValue = 8;
        frame.AddRoll(rollValue);
        
        int score = scoreCalculator.CalculateCurrentRollScore(frame, frameIndex);
        
        score.Should().Be(rollValue);
    }

    [Test]
    public void CalculateCurrentRollScore_With_Frame_With_Two_Roll_With_No_Strike_Or_Spare_Previously_Should_Return_Last_Roll_Value()
    {
        int rollValue2 = 5;
        frame.AddRoll(4);
        frame.AddRoll(rollValue2);

        int score = scoreCalculator.CalculateCurrentRollScore(frame, frameIndex);

        score.Should().Be(rollValue2);
    }

    [Test]
    public void CalculateCurrentRollScore_With_Frame_With_Roll_1_After_Spare_Should_Return_2()
    {
        frame.AddRoll(4);
        scoreCalculator.CalculateCurrentRollScore(frame, frameIndex);
        frame.AddRoll(6);
        scoreCalculator.CalculateCurrentRollScore(frame, frameIndex);


        frame = new();
        frame.AddRoll(1);
        int score = scoreCalculator.CalculateCurrentRollScore(frame, frameIndex);
        score.Should().Be(2);
    }

    [Test]
    public void CalculateCurrentRollScore_With_Frame_With_Roll_1_3_After_Spare_Should_Return_3()
    {
        frame.AddRoll(4);
        scoreCalculator.CalculateCurrentRollScore(frame, frameIndex);
        frame.AddRoll(6);
        scoreCalculator.CalculateCurrentRollScore(frame, frameIndex);

        frame = new();
        frame.AddRoll(1);
        scoreCalculator.CalculateCurrentRollScore(frame, frameIndex);
        frame.AddRoll(3);
        int score = scoreCalculator.CalculateCurrentRollScore(frame, frameIndex);
        score.Should().Be(3);
    }

    [Test]
    public void CalculateCurrentRollScore_With_Frame_With_Roll_1_After_Strike_Should_Return_2()
    {
        frame.AddRoll(10);
        scoreCalculator.CalculateCurrentRollScore(frame, frameIndex);

        frame = new();
        frame.AddRoll(1);
        int score = scoreCalculator.CalculateCurrentRollScore(frame, frameIndex);
        score.Should().Be(2);
    }

    [Test]
    public void CalculateCurrentRollScore_With_Frame_With_Roll_1_3_After_Strike_Should_Return_6()
    {
        frame.AddRoll(10);
        scoreCalculator.CalculateCurrentRollScore(frame, frameIndex);

        frame = new();
        frame.AddRoll(1);
        scoreCalculator.CalculateCurrentRollScore(frame, frameIndex);
        frame.AddRoll(3);
        int score = scoreCalculator.CalculateCurrentRollScore(frame, frameIndex);
        score.Should().Be(6);
    }

    [Test]
    public void CalculateCurrentRollScore_With_Strike_Strike_1_1_1_Should_Return_10_20_3_2_1()
    {
        frame = new();
        frame.AddRoll(10);
        scoreCalculator.CalculateCurrentRollScore(frame, frameIndex).Should().Be(10);

        frame = new();
        frame.AddRoll(10);
        scoreCalculator.CalculateCurrentRollScore(frame, frameIndex).Should().Be(20);

        frame = new();
        frame.AddRoll(1);
        scoreCalculator.CalculateCurrentRollScore(frame, frameIndex).Should().Be(3);

        frame = new();
        frame.AddRoll(1);
        scoreCalculator.CalculateCurrentRollScore(frame, frameIndex).Should().Be(2);

        frame = new();
        frame.AddRoll(1);
        scoreCalculator.CalculateCurrentRollScore(frame, frameIndex).Should().Be(1);
    }

    [Test]
    public void CalculateCurrentRollScore_With_Strike_Strike_Strike_Strike_Strike_Should_Return_10_20_30_30_30()
    {
        frame = new();
        frame.AddRoll(10);
        scoreCalculator.CalculateCurrentRollScore(frame, frameIndex).Should().Be(10);

        frame = new();
        frame.AddRoll(10);
        scoreCalculator.CalculateCurrentRollScore(frame, frameIndex).Should().Be(20);

        frame = new();
        frame.AddRoll(10);
        scoreCalculator.CalculateCurrentRollScore(frame, frameIndex).Should().Be(30);

        frame = new();
        frame.AddRoll(10);
        scoreCalculator.CalculateCurrentRollScore(frame, frameIndex).Should().Be(30);

        frame = new();
        frame.AddRoll(10);
        scoreCalculator.CalculateCurrentRollScore(frame, frameIndex).Should().Be(30);
    }

    [Test]
    public void CalculateCurrentRollScore_With_Strike_Strike_Strike_Strike_Strike_With_FrameIndex_Start_At_7_Should_Return_10_20_30_20_10()
    {
        frame = new();
        frame.AddRoll(10);
        scoreCalculator.CalculateCurrentRollScore(frame, 7).Should().Be(10);

        frame = new();
        frame.AddRoll(10);
        scoreCalculator.CalculateCurrentRollScore(frame, 8).Should().Be(20);

        frame = new();
        frame.AddRoll(10);
        scoreCalculator.CalculateCurrentRollScore(frame, 9).Should().Be(30);

        frame = new();
        frame.AddRoll(10);
        scoreCalculator.CalculateCurrentRollScore(frame, 10).Should().Be(20);

        frame = new();
        frame.AddRoll(10);
        scoreCalculator.CalculateCurrentRollScore(frame, 11).Should().Be(10);
    }
}
