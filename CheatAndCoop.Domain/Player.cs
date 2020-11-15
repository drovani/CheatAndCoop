using System.Collections.Generic;

namespace CheatAndCoop
{
    public class Player
    {
        public IStrategy Strategy { get; protected set; }

        public static Player UsingStrategy<TStrategy>() where TStrategy : IStrategy, new()
        {
            return new Player(new TStrategy());
        }

        public Player(IStrategy initialStrategy) => Strategy = initialStrategy;

        public void ChangeStrategy(IStrategy strategy)
        {
            Strategy = strategy;
        }

        public Choice GetNextChoice(IEnumerable<Choice> ownChoices, IEnumerable<Choice> opponentChoices)
        {
            return Strategy.GetNextChoice(ownChoices, opponentChoices);
        }

        public override string ToString()
        {
            return Strategy.GetType().Name;
        }
    }
}