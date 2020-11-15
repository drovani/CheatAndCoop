using System;
using System.Collections.Generic;
using System.Linq;

namespace CheatAndCoop.Tests.Domain
{
    public static class GameScenarios
    {
        public static IEnumerable<Choice> AllCoop(int rounds) => Enumerable.Repeat(Choice.Coop, rounds);
        public static IEnumerable<Choice> AllCheat(int rounds) => Enumerable.Repeat(Choice.Cheat, rounds);
        public static IEnumerable<Choice> RandomChoices(int rounds)
        {
            var rng = new Random();
            var choices = new List<Choice>(rounds);
            for(int i = 0; i < rounds; i++)
            {
                choices.Add(rng.NextDouble() >= 0.5 ? Choice.Cheat : Choice.Coop);
            }
            return choices;
        }
    }
}
