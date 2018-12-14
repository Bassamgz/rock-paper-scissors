namespace RockPaperScissors.Data.Model.Tests
{
    using System;
    using RockPaperScissors.Data.Model.Enums;
    using RockPaperScissors.Data.Model.Requests;
    using Xunit;

    public class RequestTests
    {
        private readonly Player testPlayer;
        private readonly Guid playerGuid;
        private readonly Guid gameGuid;

        public RequestTests()
        {
            this.playerGuid = Guid.NewGuid();
            this.gameGuid = Guid.NewGuid();
            this.testPlayer = new Player
            {
                Id = this.playerGuid,
                Move = Move.Empty,
                Name = "Test Player One"
            };
        }

        [Fact]
        public void PlayGameRequest_Correct_ObjectCreated()
        {
            // Arrange
            var playGameRequest = new PlayGameRequest
            {
                Player = this.testPlayer,
                GameId = this.gameGuid
            };

            // Act
            // Assert
            Assert.Equal(this.gameGuid, playGameRequest.GameId);
            Assert.Equal(this.testPlayer, playGameRequest.Player);
        }

        [Fact]
        public void JoinGameRequest_Correct_ObjectCreated()
        {
            // Arrange
            var joinGameRequest = new JoinGameRequest()
            {
                SecondPlayer = this.testPlayer,
                GameId = this.gameGuid
            };

            // Act
            // Assert
            Assert.Equal(this.gameGuid, joinGameRequest.GameId);
            Assert.Equal(this.testPlayer, joinGameRequest.SecondPlayer);
        }

        [Fact]
        public void CreateGameRequest_Correct_ObjectCreated()
        {
            // Arrange
            var createGameRequest = new CreateGameRequest
            {
                PlayerOne = this.testPlayer
            };

            // Act
            // Assert
            Assert.Equal(this.testPlayer, createGameRequest.PlayerOne);
        }

        [Fact]
        public void GameStatusRequest_Correct_ObjectCreated()
        {
            // Arrange
            var gameStatusRequest = new GameStatusRequest
            {
                GameId = this.gameGuid
            };

            // Act
            // Assert
            Assert.Equal(this.gameGuid, gameStatusRequest.GameId);
        }
    }
}
