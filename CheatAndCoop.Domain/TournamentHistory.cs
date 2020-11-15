using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheatAndCoop
{
    public class TournamentHistory
    {
        public IDictionary<Player, int> PlayersAndScores { get; protected init; }
        public IList<GameHistory> GameHistories { get; } = new List<GameHistory>();

        public TournamentHistory(IEnumerable<Player> players) => PlayersAndScores = players.ToDictionary(key => key, el => 0);

        public void AddGame(GameHistory gameHistory)
        {
            GameHistories.Add(gameHistory);
            PlayersAndScores[gameHistory.Player1] += gameHistory.Player1Score;
            PlayersAndScores[gameHistory.Player2] += gameHistory.Player2Score;
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine($"Total Games: {GameHistories.Count}");
            var leaderboard = PlayersAndScores.OrderByDescending(ps => ps.Value);
            foreach(var playerAndScore in leaderboard)
            {
                output.AppendLine($"{playerAndScore.Key}: {playerAndScore.Value}");
            }
            return output.ToString();
        }
    }
}
