using CheatAndCoop.Strategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CheatAndCoop.Tests.Domain.Strategies
{
    [TestClass]
    public class SimpletonTests : StrategyTests<Simpleton>
    {
        public SimpletonTests() : base(Choice.Coop) { }

        [TestMethod]
        public void RepeatLast_When_OpponentLastCoop()
        {
            for(int i = 0; i <= RoundsToTest -1; i++)
            {
                var ownMoves = GameScenarios.RandomChoices(i+1);
                var oppMoves = GameScenarios.RandomChoices(i).Append(Choice.Coop);

                Choice expected = ownMoves.Last();

                Choice actual = Strategy.GetNextChoice(ownMoves, oppMoves);

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void ChooseOppositeOfLast_When_OpponentLastCheat()
        {
            for (int i = 0; i <= RoundsToTest - 1; i++)
            {
                var ownMoves = GameScenarios.RandomChoices(i + 1);
                var oppMoves = GameScenarios.RandomChoices(i).Append(Choice.Cheat);

                Choice expected = ownMoves.Last() == Choice.Coop ? Choice.Cheat : Choice.Coop;

                Choice actual = Strategy.GetNextChoice(ownMoves, oppMoves);

                Assert.AreEqual(expected, actual);
            }
        }
    }
}
