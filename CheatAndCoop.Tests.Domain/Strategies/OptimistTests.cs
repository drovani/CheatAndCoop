﻿using CheatAndCoop.Strategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheatAndCoop.Tests.Domain.Strategies
{
    [TestClass]
    public class OptimistTests : StrategyTests<Optimist>
    {
        public OptimistTests() : base(Choice.Coop) { }

        [TestMethod]
        public void ChooseCoop_When_OpponentCheats()
        {
            for (int i = 1; i < RoundsToTest; i++)
            {
                Choice choice = Strategy.GetNextChoice(GameScenarios.AllCoop(i), GameScenarios.AllCheat(i));
                Assert.AreEqual(Choice.Coop, choice);
            }
        }

        [TestMethod]
        public void ChooseCoop_When_OpponentCoops()
        {
            for (int i = 1; i < RoundsToTest; i++)
            {
                Choice choice = Strategy.GetNextChoice(GameScenarios.AllCoop(i), GameScenarios.AllCoop(i));
                Assert.AreEqual(Choice.Coop, choice);
            }
        }

        [TestMethod]
        public void ChooseCoop_When_OpponentRandom()
        {
            for (int i = 1; i < RoundsToTest; i++)
            {
                Choice choice = Strategy.GetNextChoice(GameScenarios.RandomChoices(i), GameScenarios.RandomChoices(i));
                Assert.AreEqual(Choice.Coop, choice);
            }
        }
    }
}
