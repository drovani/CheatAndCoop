using System.Collections.Generic;
using System.Linq;

namespace CheatAndCoop.Tests.Domain
{
    public static class GameScenarios
    {
        public static IEnumerable<Choice> AllCoop(int rounds) => Enumerable.Repeat(Choice.Coop, rounds);
        public static IEnumerable<Choice> AllCheat(int rounds) => Enumerable.Repeat(Choice.Cheat, rounds);
    }
}
