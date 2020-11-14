using System;
using System.Collections.Generic;
using System.Linq;

namespace CheatAndCoop
{
    public class GameHistory
    {
        public int Player1Score { get; protected set; }
        public int Player2Score { get; protected set; }
        public IList<Choice> Player1Choices { get; } = new List<Choice>();
        public IList<Choice> Player2Choices { get; } = new List<Choice>();
        public int NumberOfRounds { get; protected set; }

        public void AddTurn(Choice player1Choice, int player1Score, Choice player2Choice, int player2Score)
        {
            Player1Score += player1Score;
            Player2Score += player2Score;
            Player1Choices.Add(player1Choice);
            Player2Choices.Add(player2Choice);
            NumberOfRounds++;
        }

        public override string ToString()
        {
            string scoreline = $"Player 1: {Player1Score}, Player 2: {Player2Score}";
            string p1 = Player1Choices.Aggregate(" ", (incoming, choice) => $"{incoming}{(choice == Choice.Coop ? '+' : '-')} | ");
            string p2 = Player2Choices.Aggregate(" ", (incoming, choice) => $"{incoming}{(choice == Choice.Coop ? '+' : '-')} | ");

            return string.Join(Environment.NewLine, new[] { scoreline, p1.Remove(p1.Length - 3), p2.Remove(p2.Length - 3) });
        }
    }
}