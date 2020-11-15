using CheatAndCoop.Strategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CheatAndCoop.Tests.Domain.Strategies
{
    [TestClass]
    public class GrudgerTests : StrategyTests<Grudger>
    {
        public GrudgerTests() : base(Choice.Coop) { }

        [TestMethod]
        public void AlwaysChooseCoop_When_OpponentAlwaysCoops()
        {
            for (int i = 1; i <= RoundsToTest; i++)
            {
                Choice choice = Strategy.GetNextChoice(GameScenarios.RandomChoices(i), GameScenarios.AllCoop(i));

                Assert.AreEqual(Choice.Coop, choice);
            }
        }

        [TestMethod]
        public void AlwaysChooseCheat_When_OpponentEverCheats()
        {
            for (int i = 0; i < RoundsToTest; i++)
            {
                Choice choice = Strategy.GetNextChoice(GameScenarios.RandomChoices(i + 1), GameScenarios.RandomChoices(i).Append(Choice.Cheat));

                Assert.AreEqual(Choice.Cheat, choice);
            }
        }

        [TestMethod]
        public void AlwaysChooseCheat_When_OpponentEverRandomlyCheats()
        {
            for (int i = 1; i <= RoundsToTest; i++)
            {
                IEnumerable<Choice> opponentChoices = GameScenarios.RandomChoices(i);
                Choice choice = Strategy.GetNextChoice(GameScenarios.RandomChoices(i), opponentChoices);

                Choice expected = opponentChoices.Any(oc => oc == Choice.Cheat) ? Choice.Cheat : Choice.Coop;

                Assert.AreEqual(expected, choice);
            }
        }
    }
}
