using System.Collections.Generic;
using System.Linq;

namespace CheatAndCoop.Strategies
{
    /// <summary>
    /// Pick Coop to start; if opponent ever cheats, pick cheat thereafter
    /// </summary>
    public class Grudger : IStrategy
    {
        public Choice GetNextChoice(IEnumerable<Choice> ownChoices, IEnumerable<Choice> opponentChoices)
        {
            return opponentChoices.Any(oc => oc == Choice.Cheat) ? Choice.Cheat : Choice.Coop;
        }
    }
}
