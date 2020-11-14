using CheatAndCoop.Strategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CheatAndCoop.Tests.Domain.Strategies
{
    [TestClass]
    public class OptimistTests
    {
        IStrategy Strategy { get; init; } = new Optimist();

        [TestMethod]
        public void FirstChoiceIsCoop()
        {
            Choice firstChoice = Strategy.GetNextChoice(Enumerable.Empty<Choice>(), Enumerable.Empty<Choice>());

            Assert.AreEqual(Choice.Coop, firstChoice);
        }

        [TestMethod]
        public void ChooseCoop_When_OpponentCheats()
        {
            for(int i = 1; i < 10; i++)
            {
                Choice choice = Strategy.GetNextChoice(GameScenarios.AllCoop(i), GameScenarios.AllCheat(i));
                Assert.AreEqual(Choice.Coop, choice);
            }
        }

        [TestMethod]
        public void ChooseCoop_When_OpponentCoops()
        {
            for(int i = 1; i<10; i++)
            {
                Choice choice = Strategy.GetNextChoice(GameScenarios.AllCoop(i), GameScenarios.AllCoop(i));
                Assert.AreEqual(Choice.Coop, choice);
            }
        }
    }
}
