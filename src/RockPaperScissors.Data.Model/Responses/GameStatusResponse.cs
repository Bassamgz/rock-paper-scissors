namespace RockPaperScissors.Data.Model.Responses
{
    using RockPaperScissors.Data.Model.Enums;

    public class GameStatusResponse
    {
        public GameStatus Status { get; set; }

        public ResponseError Error { get; set; }
    }
}
