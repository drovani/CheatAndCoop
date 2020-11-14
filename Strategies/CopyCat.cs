using System.Collections.Generic;
using System.Linq;

namespace CheatAndCoop.Strategies
{
    /// <summary>
    /// Pick Coop to start, then copy the opponent's last choice.
    /// </summary>
    public record CopyCat : IStrategy
    {
        public Choice GetNextChoice(IEnumerable<Choice> ownChoices, IEnumerable<Choice> opponentChoices)
        {
            if (opponentChoices.Any())
            {
                return opponentChoices.Last();
            }
            else
            {
                return Choice.Coop;
            }
        }
    }
}