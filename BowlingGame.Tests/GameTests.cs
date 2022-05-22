using FluentAssertions;

namespace BowlingGame.Tests
{
    public class GameTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Game_Score_Should_Return_Zero_Initially()
        {
            Game game = new();
            game.Score.Should().Be(0);
        }

        [Test]
        public void Game_Roll_Should_Increase_Score()
        {
            Game game = new();
            game.Roll(10);

            game.Score.Should().Be(10);
        }

        [Test]
        public void Game_Roll_8_And_Then_Roll_3_Should_Throw_Exception()
        {
            Game game = new();
            game.Roll(8);
            game.Invoking(y => y.Roll(3))
                .Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void Game_Score_Should_Return_300_If_All_Rolls_Are_Xs()
        {
            Game game = new();
            for (int i=0; i<12; i++)
            {
                game.Roll(10);
            }
            game.Score.Should().Be(300);
        }

        [Test]
        public void Game_Score_Should_Return_90_If_All_Rolls_Are_9s()
        {
            Game game = new();
            for (int i = 0; i < 10; i++)
            {
                game.Roll(9);
                game.Roll(0);
            }
            game.Score.Should().Be(90);
        }

        [Test]
        public void Game_Score_Should_Return_150_If_All_Rolls_Are_5s()
        {
            Game game = new();
            for (int i = 0; i < 10; i++)
            {
                game.Roll(5);
                game.Roll(5);
            }
            game.Roll(5);
            game.Score.Should().Be(150);
        }

        [Test]
        public void CalculateScore_Should_Return_Correct_Score_For_Normal_Rolls()
        {
            Game game = new();
            for (int i = 0; i < 10; i++)
            {
                game.Roll(0);
                game.Roll(0);
            }
            game.Score.Should().Be(0);

            Game game2 = new();
            for (int i = 0; i < 10; i++)
            {
                game2.Roll(1);
                game2.Roll(1);
            }
            game2.Score.Should().Be(20);

            Game game3 = new();
            for (int i = 0; i < 10; i++)
            {
                game3.Roll(2);
                game3.Roll(2);
            }
            game3.Score.Should().Be(40);
        }

        [Test]
        public void CalculateScore_Should_Return_Correct_Score_For_Strikes_And_Spares_Mixes()
        {
            Game game = new();
            game.Roll(0);
            game.Roll(10);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(10);
            game.Roll(1);
            game.Roll(0);
            game.Roll(0);
            game.Roll(10);
            game.Roll(0);
            game.Roll(10);
            game.Roll(9);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Score.Should().Be(60);

            Game game2 = new();
            game2.Roll(10);
            game2.Roll(1);
            game2.Roll(1);
            game2.Roll(1);
            game2.Roll(1);
            game2.Roll(10);
            game2.Roll(2);
            game2.Roll(2);
            game2.Roll(2);
            game2.Roll(1);
            game2.Roll(10);
            game2.Roll(10);
            game2.Roll(9);
            game2.Roll(0);
            game2.Roll(0);
            game2.Roll(0);
            game2.Score.Should().Be(94);

            Game game3 = new();
            game3.Roll(5);
            game3.Roll(5);
            game3.Roll(10);
            game3.Roll(5);
            game3.Roll(0);
            game3.Roll(10);
            game3.Roll(3);
            game3.Roll(7);
            game3.Roll(8);
            game3.Roll(2);
            game3.Roll(10);
            game3.Roll(1);
            game3.Roll(0);
            game3.Roll(0);
            game3.Roll(0);
            game3.Roll(10);
            game3.Roll(5);
            game3.Roll(5);
            game3.Score.Should().Be(130);
        }
    }
}
