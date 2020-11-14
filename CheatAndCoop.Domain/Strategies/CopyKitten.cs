using System.Collections.Generic;
using System.Linq;

namespace CheatAndCoop.Strategies
{
    /// <summary>
    /// Pick Coop to start; if opponent's last two are cheat, pick cheat; otherwise, coop.
    /// </summary>
    public record CopyKitten : IStrategy
    {
        public Choice GetNextChoice(IEnumerable<Choice> ownChoices, IEnumerable<Choice> opponentChoices)
        {
            if (opponentChoices.Count() < 2)
            {
                return Choice.Coop;
            }else if (opponentChoices.TakeLast(2).All(oc => oc == Choice.Cheat))
            {
                return Choice.Cheat;
            }
            else
            {
                return Choice.Coop;
            }
        }
    }
}