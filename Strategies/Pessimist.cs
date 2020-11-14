using System.Collections.Generic;

namespace CheatAndCoop.Strategies
{
    /// <summary>
    /// Always pick Cheat
    /// </summary>
    public record Pessimist : IStrategy
    {
        public Choice GetNextChoice(IEnumerable<Choice> ownChoices, IEnumerable<Choice> opponentChoices)
        {
            return Choice.Cheat;
        }
    }
}