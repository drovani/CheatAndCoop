using CheatAndCoop.Strategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheatAndCoop.Tests.Domain.Strategies
{
    [TestClass]
    public class PessimistTests : StrategyTests<Pessimist>
    {
        public PessimistTests() : base(Choice.Cheat) { }

        [TestMethod]
        public void ChooseCheat_When_OpponentCheats()
        {
            for (int i = 1; i < RoundsToTest; i++)
            {
                Choice choice = Strategy.GetNextChoice(GameScenarios.AllCheat(i), GameScenarios.AllCheat(i));
                Assert.AreEqual(Choice.Cheat, choice);
            }
        }

        [TestMethod]
        public void ChooseCheat_When_OpponentCoops()
        {
            for (int i = 1; i < RoundsToTest; i++)
            {
                Choice choice = Strategy.GetNextChoice(GameScenarios.AllCoop(i), GameScenarios.AllCoop(i));
                Assert.AreEqual(Choice.Cheat, choice);
            }
        }

        [TestMethod]
        public void ChooseCheat_When_OpponentRandom()
        {
            for (int i = 1; i < RoundsToTest; i++)
            {
                Choice choice = Strategy.GetNextChoice(GameScenarios.RandomChoices(i), GameScenarios.RandomChoices(i));
                Assert.AreEqual(Choice.Cheat, choice);
            }
        }
    }
}
