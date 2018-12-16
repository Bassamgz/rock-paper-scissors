namespace RockPaperScissors.Core.Services
{
    using System;
    using RockPaperScissors.Data.Model;
    using RockPaperScissors.Data.Model.Requests;
    using RockPaperScissors.Data.Model.Responses;

    public interface IGameService
    {
        CreateGameResponse CreateGame(CreateGameRequest request);

        JoinGameResponse JoinGame(JoinGameRequest request);

        PlayGameResponse PlayGame(PlayGameRequest request);

        GameStatusResponse CheckGameStatus(GameStatusRequest request);
    }
}