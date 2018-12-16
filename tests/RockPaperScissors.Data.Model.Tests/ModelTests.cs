namespace RockPaperScissors.Data.Model.Tests
{
    using System;
    using RockPaperScissors.Data.Model.Enums;
    using Xunit;

    public class ModelTests
    {
        private readonly Player testPlayerOne;
        private readonly Player testPlayerTwo;
        private readonly string gameName;

        public ModelTests()
        {
            this.gameName = "Test Game";
            this.testPlayerOne = new Player
            {
                Id = Guid.NewGuid(),
                Move = Move.Empty,
                Name = "Test Player One"
            };

            this.testPlayerTwo = new Player
            {
                Id = Guid.NewGuid(),
                Move = Move.Empty,
                Name = "Test Player Two"
            };
        }

        [Fact]
        public void Game_Correct_ObjectCreated()
        {
            // Arrange
            var game = new Game
            {
                Id = Guid.NewGuid(),
                Name = this.gameName,
                Status = GameStatus.Created,
                FirstPlayer = this.testPlayerOne,
                SecondPlayer = this.testPlayerTwo
            };

            // Act
            // Assert
            Assert.NotEqual(Guid.Empty, game.Id);
            Assert.Equal(this.gameName, game.Name);
            Assert.Equal(this.testPlayerOne, game.FirstPlayer);
            Assert.Equal(this.testPlayerTwo, game.SecondPlayer);
            Assert.Equal(GameStatus.Created, game.Status);
        }

        [Fact]
        public void Player_Correct_ObjectCreated()
        {
            // Arrange
            var player = this.testPlayerOne;

            // Act
            // Assert
            Assert.Equal(this.testPlayerOne.Id, player.Id);
            Assert.Equal(this.testPlayerOne.Move, player.Move);
            Assert.Equal(this.testPlayerOne.Name, player.Name);
        }
    }
}
