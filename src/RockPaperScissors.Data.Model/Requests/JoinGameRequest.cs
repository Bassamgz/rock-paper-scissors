namespace RockPaperScissors.Data.Model.Requests
{
    using System;

    public class JoinGameRequest
    {
        public Guid GameId { get; set; }

        public Player SecondPlayer { get; set; }
    }
}
