using System;
using System.Collections.Generic;

namespace CheatAndCoop.Strategies
{
    public class FiftyFiftyRandom : IStrategy
    {
        protected Random gen { get; init; } = new Random();
        public Choice GetNextChoice(IEnumerable<Choice> ownChoices, IEnumerable<Choice> opponentChoices)
        {
            if (gen.NextDouble() >= 0.5) return Choice.Cheat;
            else return Choice.Coop;
        }
    }
}
