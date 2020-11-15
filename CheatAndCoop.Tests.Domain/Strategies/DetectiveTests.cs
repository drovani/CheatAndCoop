using CheatAndCoop.Strategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CheatAndCoop.Tests.Domain.Strategies
{
    [TestClass]
    public class DetectiveTests : StrategyTests<Detective>
    {
        public DetectiveTests() : base(Choice.Coop) { }

        [DataTestMethod]
        [DataRow(Choice.Coop)]
        [DataRow(Choice.Cheat)]
        public void SecondChoice_AlwaysCheat(Choice opponentsFirstChoice)
        {
            Choice choice = Strategy.GetNextChoice(new Choice[] { Choice.Coop }, new Choice[] { opponentsFirstChoice });

            Assert.AreEqual(Choice.Cheat, choice);
        }

        [DataTestMethod]
        [DataRow(Choice.Coop, Choice.Coop)]
        [DataRow(Choice.Coop, Choice.Cheat)]
        [DataRow(Choice.Cheat, Choice.Coop)]
        [DataRow(Choice.Cheat, Choice.Cheat)]
        public void ThirdChoice_AlwaysCoop(Choice opponentsFirstChoice, Choice opponentsSecondChoice)
        {
            Choice choice = Strategy.GetNextChoice(new Choice[] { Choice.Coop, Choice.Cheat }, new Choice[] { opponentsFirstChoice, opponentsSecondChoice});

            Assert.AreEqual(Choice.Coop, choice);
        }

        [DataTestMethod]
        [DataRow(Choice.Coop, Choice.Coop, Choice.Coop)]
        [DataRow(Choice.Coop, Choice.Coop, Choice.Cheat)]
        [DataRow(Choice.Coop, Choice.Cheat, Choice.Coop)]
        [DataRow(Choice.Coop, Choice.Cheat, Choice.Cheat)]
        [DataRow(Choice.Cheat, Choice.Coop, Choice.Coop)]
        [DataRow(Choice.Cheat, Choice.Coop, Choice.Cheat)]
        [DataRow(Choice.Cheat, Choice.Cheat, Choice.Coop)]
        [DataRow(Choice.Cheat, Choice.Cheat, Choice.Cheat)]
        public void FourthChoice_AlwaysCoop(Choice opponentsFirstChoice, Choice opponentsSecondChoice, Choice opponentsThirdChoice)
        {
            Choice choice = Strategy.GetNextChoice(new Choice[] { Choice.Coop, Choice.Cheat, Choice.Coop }, new Choice[] { opponentsFirstChoice, opponentsSecondChoice, opponentsThirdChoice });

            Assert.AreEqual(Choice.Coop, choice);
        }

        [DataTestMethod]
        [DataRow(Choice.Coop, Choice.Coop, Choice.Coop, Choice.Coop)]
        public void LaterMovesAlwaysCheat_When_OpponentCoopAllFirstFour(Choice opponentsFirstChoice, Choice opponentsSecondChoice, Choice opponentsThirdChoice, Choice opponentsFourthChoice)
        {
            var opponentOpener = new Choice[] { opponentsFirstChoice, opponentsSecondChoice, opponentsThirdChoice, opponentsFourthChoice };
            var ownOpener = new Choice[] { Choice.Coop, Choice.Cheat, Choice.Coop, Choice.Coop };

            for(int i = 0; i <= RoundsToTest - 4; i++)
            {
                Choice choice = Strategy.GetNextChoice(ownOpener.Concat(GameScenarios.RandomChoices(i)), opponentOpener.Concat(GameScenarios.RandomChoices(i)));

                Assert.AreEqual(Choice.Cheat, choice);
            }
        }

        [DataTestMethod]
        [DataRow(Choice.Coop, Choice.Coop, Choice.Coop, Choice.Cheat)]
        [DataRow(Choice.Coop, Choice.Coop, Choice.Cheat, Choice.Coop)]
        [DataRow(Choice.Coop, Choice.Coop, Choice.Cheat, Choice.Cheat)]
        [DataRow(Choice.Coop, Choice.Cheat, Choice.Coop, Choice.Coop)]
        [DataRow(Choice.Coop, Choice.Cheat, Choice.Coop, Choice.Cheat)]
        [DataRow(Choice.Coop, Choice.Cheat, Choice.Cheat, Choice.Coop)]
        [DataRow(Choice.Coop, Choice.Cheat, Choice.Cheat, Choice.Cheat)]
        [DataRow(Choice.Cheat, Choice.Coop, Choice.Coop, Choice.Coop)]
        [DataRow(Choice.Cheat, Choice.Coop, Choice.Coop, Choice.Cheat)]
        [DataRow(Choice.Cheat, Choice.Coop, Choice.Cheat, Choice.Coop)]
        [DataRow(Choice.Cheat, Choice.Coop, Choice.Cheat, Choice.Cheat)]
        [DataRow(Choice.Cheat, Choice.Cheat, Choice.Coop, Choice.Coop)]
        [DataRow(Choice.Cheat, Choice.Cheat, Choice.Coop, Choice.Cheat)]
        [DataRow(Choice.Cheat, Choice.Cheat, Choice.Cheat, Choice.Coop)]
        [DataRow(Choice.Cheat, Choice.Cheat, Choice.Cheat, Choice.Cheat)]
        public void LaterMovesCopyOpponentLast_When_OpponentCheatInAnyFirstFour(Choice opponentsFirstChoice, Choice opponentsSecondChoice, Choice opponentsThirdChoice, Choice opponentsFourthChoice)
        {
            var opponentOpener = new Choice[] { opponentsFirstChoice, opponentsSecondChoice, opponentsThirdChoice, opponentsFourthChoice };
            var ownOpener = new Choice[] { Choice.Coop, Choice.Cheat, Choice.Coop, Choice.Coop };

            for (int i = 0; i <= RoundsToTest - 4; i++)
            {
                IEnumerable<Choice> opponentChoices = opponentOpener.Concat(GameScenarios.RandomChoices(i));
                Choice expected = opponentChoices.Last();

                Choice choice = Strategy.GetNextChoice(ownOpener.Concat(GameScenarios.RandomChoices(i)), opponentChoices);

                Assert.AreEqual(expected, choice);
            }
        }
    }
}
