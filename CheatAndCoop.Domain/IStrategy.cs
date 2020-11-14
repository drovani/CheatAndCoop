using System.Collections.Generic;

namespace CheatAndCoop
{
    public interface IStrategy
    {
        Choice GetNextChoice(IEnumerable<Choice> ownChoices, IEnumerable<Choice> opponentChoices);
    }
}