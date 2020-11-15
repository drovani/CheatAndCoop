using System.Collections.Generic;

namespace CheatAndCoop
{
    public interface ITournament
    {
        public IReadOnlyCollection<Player> Players { get; }
        public TournamentHistory CommenceTournament();
    }
}
