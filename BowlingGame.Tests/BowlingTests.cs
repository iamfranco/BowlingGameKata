using FluentAssertions;

namespace BowlingGame.Tests
{
    public class BowlingTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CalculateScore_Should_Return_300_If_All_Rolls_Are_Xs()
        {
            Bowling.CalculateScore("X X X X X X X X X X X X").Should().Be(300);
        }

        [Test]
        public void CalculateScore_Should_Return_90_If_All_Rolls_Are_9s()
        {
            Bowling.CalculateScore("9- 9- 9- 9- 9- 9- 9- 9- 9- 9-").Should().Be(90);
        }

        [Test]
        public void CalculateScore_Should_Return_150_If_All_Rolls_Are_5s()
        {
            Bowling.CalculateScore("5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/5").Should().Be(150);
        }

        [Test]
        public void CalculateScore_Should_Return_Correct_Score_For_Normal_Rolls()
        {
            Bowling.CalculateScore("-- -- -- -- -- -- -- -- -- --").Should().Be(0);
            Bowling.CalculateScore("11 11 11 11 11 11 11 11 11 11").Should().Be(20);
            Bowling.CalculateScore("22 22 22 22 22 22 22 22 22 22").Should().Be(40);
        }

        [Test]
        public void CalculateScore_Should_Return_Correct_Score_For_Strikes_And_Spares_Mixes()
        {
            Bowling.CalculateScore("-/ -- -/ 1- -/ -/ 9- -- -- --").Should().Be(60);
            Bowling.CalculateScore("X 11 11 X 22 21 X X 9- --").Should().Be(94);
            Bowling.CalculateScore("5/ X 5- X 3/ 8/ X 1- -- X 5/").Should().Be(130);
        }
    }
}