namespace RockPaperScissors.Data.Model.Requests
{
    using System;

    public class PlayGameRequest
    {
        public Guid GameId { get; set; }

        public Player Player { get; set; }
    }
}
