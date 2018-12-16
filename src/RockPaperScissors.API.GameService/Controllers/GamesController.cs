namespace RockPaperScissors.API.GameService.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using RockPaperScissors.Core.Services;
    using RockPaperScissors.Data.Model;
    using RockPaperScissors.Data.Model.Enums;
    using RockPaperScissors.Data.Model.Requests;

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService gameService;

        public GamesController(IGameService gameService)
        {
            this.gameService = gameService;
        }

        // GET api/games/gameId
        [HttpGet("{id}")]
        public ActionResult<Game> Get(Guid gameId)
        {
            var gameStatusRequest = new GameStatusRequest
            {
                GameId = gameId
            };

            var gameStatusResponse = this.gameService.CheckGameStatus(gameStatusRequest);
            if (gameStatusResponse == null)
            {
                return this.NotFound();
            }

            return this.Ok(gameStatusResponse);
        }

        // Create Game
        // Post api/games/gameName
        [HttpPost]
        public void Post(string gameName)
        {
            var createGameRequest = new CreateGameRequest
            {
                GameName = gameName
            };

            var createGameResponse = this.gameService.CreateGame(createGameRequest);
        }

        // Join Game
        // Post api/games/gameName/playerName
        [HttpPost]
        [Route("{gameName}/{playerName}")]
        public void Post(string gameName, string playerName)
        {
            var joinGameRequest = new JoinGameRequest
            {
                GameName = gameName,
                SecondPlayer = new Player
                {
                    Id = Guid.NewGuid(),
                    Name = playerName,
                    Move = Move.Empty
                }
            };
            var joinGameResponse = this.gameService.JoinGame(joinGameRequest);
        }

        // Play Game
        // Post api/games/guid/playerId/nextMove
        [HttpPost]
        [Route("{gameName}/{playerName}/{nextMove:int}")]
        public void Post(string gameName, string playerName, Move nextMove)
        {
            var playGameRequest = new PlayGameRequest
            {
                GameName = gameName,
                PlayerName = playerName,
                NextMove = nextMove
            };
            var playGameResponse = this.gameService.PlayGame(playGameRequest);
        }
    }
}