using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheatAndCoop
{
    public class GameHistory
    {
        public Player Player1 { get; init; }
        public Player Player2 { get; init; }
        public int Player1Score { get; protected set; }
        public int Player2Score { get; protected set; }
        public IList<Choice> Player1Choices { get; } = new List<Choice>();
        public IList<Choice> Player2Choices { get; } = new List<Choice>();

        public void AddTurn(Choice player1Choice, int player1Score, Choice player2Choice, int player2Score)
        {
            Player1Score += player1Score;
            Player2Score += player2Score;
            Player1Choices.Add(player1Choice);
            Player2Choices.Add(player2Choice);
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine($"{(Player1 == default(Player) ? "Player 1" : Player1)}: {Player1Score}, {(Player2 == default(Player) ? "Player 2" : Player2)}: {Player2Score}");
            string p1 = Player1Choices.Aggregate(" ", (incoming, choice) => $"{incoming}{(choice == Choice.Coop ? '+' : '-')} | ");
            output.AppendLine(p1.Remove(p1.Length - 3));
            string p2 = Player2Choices.Aggregate(" ", (incoming, choice) => $"{incoming}{(choice == Choice.Coop ? '+' : '-')} | ");
            output.AppendLine(p2.Remove(p2.Length - 3));

            return output.ToString();
        }
    }
}