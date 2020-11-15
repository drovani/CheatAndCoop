using CheatAndCoop.Strategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheatAndCoop.Tests.Domain.Strategies
{
    [TestClass]
    public class CopyKittenTests : StrategyTests<CopyKitten>
    {
        public CopyKittenTests() : base(Choice.Coop) { }

        [DataTestMethod]
        [DataRow(Choice.Coop)]
        [DataRow(Choice.Cheat)]
        public void SecondChoice_AlwaysCoop(Choice opponentFirstChoice)
        {
            Choice choice = Strategy.GetNextChoice(new Choice[] { Choice.Coop }, new Choice[] { opponentFirstChoice });

            Assert.AreEqual(Choice.Coop, choice);
        }

        [DataTestMethod]
        [DataRow(Choice.Coop, Choice.Coop)]
        [DataRow(Choice.Coop, Choice.Cheat)]
        [DataRow(Choice.Cheat, Choice.Coop)]
        public void ThirdChoiceCoop_When_OpponentChoseAtLeastOneCoop(Choice opponentFirstChoice, Choice opponentSecondChoice)
        {
            Choice choice = Strategy.GetNextChoice(new Choice[] { Choice.Coop, Choice.Coop }, new Choice[] { opponentFirstChoice, opponentSecondChoice });

            Assert.AreEqual(Choice.Coop, choice);
        }

        [DataTestMethod]
        [DataRow(Choice.Cheat, Choice.Cheat)]
        public void ThirdChoiceCheat_When_OpponentChoseBothCheat(Choice opponentFirstChoice, Choice opponentSecondChoice)
        {
            Choice choice = Strategy.GetNextChoice(new Choice[] { Choice.Coop, Choice.Coop }, new Choice[] { opponentFirstChoice, opponentSecondChoice });

            Assert.AreEqual(Choice.Cheat, choice);
        }

        [TestMethod]
        public void OnlyCheat_When_OpponentLastTwoCheat()
        {
            for(int i = 3; i <= RoundsToTest - 3; i++)
            {
                IEnumerable<Choice> opponentChoices = GameScenarios.RandomChoices(i);
                Choice expected = opponentChoices.TakeLast(2).All(oc => oc == Choice.Cheat) ? Choice.Cheat : Choice.Coop;

                Choice choice = Strategy.GetNextChoice(GameScenarios.RandomChoices(i), opponentChoices);

                Assert.AreEqual(expected, choice);
            }
        }
    }
}
