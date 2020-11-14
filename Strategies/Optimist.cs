using System.Collections.Generic;

namespace CheatAndCoop.Strategies
{
    /// <summary>
    /// Always pick Coop.
    /// </summary>
    public record Optimist : IStrategy
    {
        public Choice GetNextChoice(IEnumerable<Choice> ownChoices, IEnumerable<Choice> opponentChoices)
        {
            return Choice.Coop;
        }
    }
}