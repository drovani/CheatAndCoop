using System.Collections.Generic;
using System.Linq;

namespace CheatAndCoop.Strategies
{
    /// <summary>
    /// Alternate Coop, Cheat; starting with Coop
    /// </summary>
    public class Alternate : IStrategy
    {
        public Choice GetNextChoice(IEnumerable<Choice> ownChoices, IEnumerable<Choice> opponentChoices)
        {
            if (!ownChoices.Any()) return Choice.Coop;
            else if (ownChoices.Last() == Choice.Coop) return Choice.Cheat;
            else return Choice.Coop;
        }
    }
}
