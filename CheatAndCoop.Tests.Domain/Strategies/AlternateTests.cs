using CheatAndCoop.Strategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CheatAndCoop.Tests.Domain.Strategies
{
    [TestClass]
    public class AlternateTests : StrategyTests<Alternate>
    {
        public AlternateTests() : base(Choice.Coop) { }

        [TestMethod]
        public void ChooseCoop_When_OwnPreviousIsCheat()
        {
            for (int i = 1; i < RoundsToTest; i++)
            {
                Choice choice = Strategy.GetNextChoice(GameScenarios.AllCheat(i), GameScenarios.RandomChoices(i));
                Assert.AreEqual(Choice.Coop, choice);
            }
        }

        [TestMethod]
        public void ChooseCheat_When_OwnPreviousIsCoop()
        {
            for (int i = 1; i < RoundsToTest; i++)
            {
                Choice choice = Strategy.GetNextChoice(GameScenarios.AllCoop(i), GameScenarios.RandomChoices(i));
                Assert.AreEqual(Choice.Cheat, choice);
            }
        }

        [TestMethod]
        public void ChooseOppositeOfOwnPrevious_WithRandomGeneration()
        {
            for(int i = 1; i < RoundsToTest; i++)
            {
                IEnumerable<Choice> ownChoices = GameScenarios.RandomChoices(i);
                Choice choice = Strategy.GetNextChoice(ownChoices, GameScenarios.RandomChoices(i));

                Choice expected = ownChoices.Last() == Choice.Cheat ? Choice.Coop : Choice.Cheat;
                Assert.AreEqual(expected, choice, $"Last Own Choice: {ownChoices.Last()}");
            }
        }
    }
}
