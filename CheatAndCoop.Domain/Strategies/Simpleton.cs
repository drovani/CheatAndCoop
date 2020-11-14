using System;
using System.Collections.Generic;
using System.Linq;

namespace CheatAndCoop.Strategies
{
    /// <summary>
    /// First pick Coop; if opponent's last is cheat, then pick opposite of last choice
    /// </summary>
    public class Simpleton : IStrategy
    {
        public Choice GetNextChoice(IEnumerable<Choice> ownChoices, IEnumerable<Choice> opponentChoices)
        {
            if (!ownChoices.Any()) return Choice.Coop;
            else return (opponentChoices.Last(), ownChoices.Last()) switch
            {
                (Choice.Cheat, Choice.Cheat) => Choice.Coop,
                (Choice.Cheat, Choice.Coop) => Choice.Cheat,
                (Choice.Coop, Choice.Cheat) => Choice.Cheat,
                (Choice.Coop, Choice.Coop) => Choice.Coop,
                _ => throw new InvalidOperationException($"Unknown state - Opponent Last:{opponentChoices.Last()}, Self Last: {ownChoices.Last()}")
            };
        }
    }
}
