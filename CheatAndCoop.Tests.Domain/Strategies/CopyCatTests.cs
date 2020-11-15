using CheatAndCoop.Strategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CheatAndCoop.Tests.Domain.Strategies
{
    [TestClass]
    public class CopyCatTests : StrategyTests<CopyCat>
    {
        public CopyCatTests() : base(Choice.Coop) { }

        [TestMethod]
        public void ChooseCoop_When_OpponentPreviousIsCoop()
        {
            for (int i = 1; i < RoundsToTest; i++)
            {
                Choice choice = Strategy.GetNextChoice(GameScenarios.RandomChoices(i), GameScenarios.AllCoop(i));
                Assert.AreEqual(Choice.Coop, choice, $"Round {i}");
            }
        }

        [TestMethod]
        public void ChooseCheat_When_OpponentPreviousIsCheat()
        {
            for (int i = 1; i < RoundsToTest; i++)
            {
                Choice choice = Strategy.GetNextChoice(GameScenarios.RandomChoices(i), GameScenarios.AllCheat(i));
                Assert.AreEqual(Choice.Cheat, choice);
            }
        }

        [TestMethod]
        public void ChooseSameAsOpponentPrevious_WithRandomGeneration()
        {
            for (int i = 1; i < RoundsToTest; i++)
            {
                IEnumerable<Choice> opponentChoices = GameScenarios.RandomChoices(i);
                Choice choice = Strategy.GetNextChoice(GameScenarios.RandomChoices(i), opponentChoices);

                Choice expected = opponentChoices.Last();
                Assert.AreEqual(expected, choice, $"Opponent's Choices:{string.Join(" | ", opponentChoices)}");
            }
        }
    }
}
