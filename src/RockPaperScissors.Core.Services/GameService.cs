namespace RockPaperScissors.Core.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using RockPaperScissors.Data.Model;
    using RockPaperScissors.Data.Model.Enums;
    using RockPaperScissors.Data.Model.Requests;
    using RockPaperScissors.Data.Model.Responses;

    public class GameService : IGameService
    {
        private readonly List<Game> games;

        public GameService()
        {
            this.games = new List<Game>();
        }

        public CreateGameResponse CreateGame(CreateGameRequest request)
        {
            // Invalid request for some reason, you will never know
            if (string.IsNullOrEmpty(request?.GameName))
            {
                return new CreateGameResponse
                {
                    GameId = Guid.Empty,
                    Error = new ResponseError
                    {
                        ErrorCode = HttpStatusCode.NotFound,
                        Description = HttpStatusCode.NotFound.ToString()
                    }
                };
            }

            // Validate Game name is unique
            var isDuplicate = this.games.Exists(item => item.Name == request.GameName);
            if (isDuplicate)
            {
                return new CreateGameResponse
                {
                    GameId = Guid.Empty,
                    Error = new ResponseError
                    {
                        ErrorCode = HttpStatusCode.Conflict,
                        Description = HttpStatusCode.Conflict.ToString()
                    }
                };
            }

            // Just create now
            var game = new Game
            {
                Id = Guid.NewGuid(),
                Name = request.GameName,
                Status = GameStatus.Created
            };
            this.games.Add(game);

            return new CreateGameResponse
            {
                GameId = game.Id
            };
        }

        public JoinGameResponse JoinGame(JoinGameRequest request)
        {
            throw new NotImplementedException();
        }

        public PlayGameResponse PlayGame(PlayGameRequest request)
        {
            throw new NotImplementedException();
        }

        public GameStatusResponse CheckGameStatus(GameStatusRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
