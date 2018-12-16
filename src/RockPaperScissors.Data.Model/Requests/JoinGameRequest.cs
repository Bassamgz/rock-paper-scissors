namespace RockPaperScissors.Data.Model.Requests
{
    public class JoinGameRequest
    {
        public Player SecondPlayer { get; set; }

        public string GameName { get; set; }
    }
}
