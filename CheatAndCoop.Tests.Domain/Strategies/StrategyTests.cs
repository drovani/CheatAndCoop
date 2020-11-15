using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CheatAndCoop.Tests.Domain.Strategies
{
    public abstract class StrategyTests<TStrategy> : StrategyTests where TStrategy : IStrategy, new()
    {
        protected StrategyTests(Choice firstChoiceShouldBe)
        {
            Strategy = new TStrategy();
            FirstChoiceShouldBe = firstChoiceShouldBe;
        }
    }

    public abstract class StrategyTests
    {
        public int RoundsToTest { get; init; } = 10;
        public IStrategy Strategy { get; init; }
        public Choice FirstChoiceShouldBe { get; init; }

        [TestMethod]
        public void FirstChoiceMatches()
        {
            Choice choice = Strategy.GetNextChoice(Enumerable.Empty<Choice>(), Enumerable.Empty<Choice>());

            Assert.AreEqual(FirstChoiceShouldBe, choice);
        }
    }
}