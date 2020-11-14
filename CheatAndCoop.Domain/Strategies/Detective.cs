using System.Collections.Generic;
using System.Linq;

namespace CheatAndCoop.Strategies
{
    /// <summary>
    /// Pick Coop, Cheat, Coop, Coop; then, if any were Cheat, always Cheat, otherwise copy opponent's last choice
    /// </summary>
    public record Detective : IStrategy
    {
        public Choice GetNextChoice(IEnumerable<Choice> ownChoices, IEnumerable<Choice> opponentChoices)
        {
            return ownChoices.Count() switch
            {
                0 => Choice.Coop,
                1 => Choice.Cheat,
                2 => Choice.Coop,
                3 => Choice.Coop,
                _ => opponentChoices.Take(4).Any(oc => oc == Choice.Cheat) ? opponentChoices.Last() : Choice.Cheat
            };
        }
    }
}