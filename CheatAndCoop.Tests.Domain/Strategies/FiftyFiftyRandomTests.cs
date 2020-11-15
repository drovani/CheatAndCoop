using CheatAndCoop.Strategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CheatAndCoop.Tests.Domain.Strategies
{
    [TestClass]
    public class FiftyFiftyRandomTests
    {
        public IStrategy Strategy { get; private init; } = new FiftyFiftyRandom();
        const int TotalIterrations = 1_000_000;
        const decimal Tolerance = 0.001m;

        [TestMethod]
        public void ChoicesAverageCloseToFiftyPercentEach()
        {
            Random rng = new Random();
            Dictionary<Choice, int> tracker = new Dictionary<Choice, int>() { { Choice.Coop, 0 }, { Choice.Cheat, 0 } };

            for(int itr = 0; itr < TotalIterrations; itr++)
            {
                int numRounds = rng.Next(9);
                Choice actual = Strategy.GetNextChoice(GameScenarios.RandomChoices(numRounds), GameScenarios.RandomChoices(numRounds));
                tracker[actual]++;
            }

            var halfway = TotalIterrations / 2;
            var range = TotalIterrations * Tolerance;

            Assert.IsTrue(halfway - range <= tracker[Choice.Coop], $"Coop Lower Limit: {halfway - range}; Actual: {tracker[Choice.Coop]}");
            Assert.IsTrue(halfway + range >= tracker[Choice.Coop], $"Coop Upper Limit: {halfway + range}; Actual: {tracker[Choice.Coop]}");
            Assert.IsTrue(halfway - range <= tracker[Choice.Cheat], $"Cheat Lower Limit: {halfway - range}; Actual: {tracker[Choice.Cheat]}");
            Assert.IsTrue(halfway + range >= tracker[Choice.Cheat], $"Cheat Upper Limit: {halfway + range}; Actual: {tracker[Choice.Cheat]}");
            Assert.AreEqual(TotalIterrations, tracker[Choice.Coop] + tracker[Choice.Cheat]);
        }
    }
}
