using System.Collections.Generic;
using System.Linq;

namespace CheatAndCoop.Tournaments
{
    public class RoundRobin : ITournament
    {
        public IReadOnlyCollection<Player> Players { get ; protected init; }
        public int NumberOfRoundsPerGame { get; protected init; }

        public RoundRobin(IEnumerable<Player> players, int numberOfRoundsPerGame = 10)
        {
            Players = (IReadOnlyCollection<Player>)players;
            NumberOfRoundsPerGame = numberOfRoundsPerGame;
        }

        public TournamentHistory CommenceTournament()
        {
            var history = new TournamentHistory(Players);

            for(int p1 = 0; p1 < Players.Count(); p1++)
            {
                for(int p2 = p1 + 1; p2 < Players.Count(); p2++)
                {
                    if (p1 != p2)
                    {
                        history.AddGame(GameMaster.CommenceGame(Players.ElementAt(p1), Players.ElementAt(p2), NumberOfRoundsPerGame));
                    }
                }
            }

            return history;
        }
    }
}
