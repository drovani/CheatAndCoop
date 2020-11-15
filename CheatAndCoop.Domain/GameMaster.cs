using System;

namespace CheatAndCoop
{
    public static class GameMaster
    {
        public static GameHistory CommenceGame(Player player1, Player player2, int numberOfRounds = 10, double didItRightChance = 1)
        {
            var history = new GameHistory()
            {
                Player1 = player1,
                Player2 = player2
            };
            var random = new Random();

            for (int turn = 0; turn < numberOfRounds; turn++)
            {
                var p1choice = player1.GetNextChoice(history.Player1Choices, history.Player2Choices);
                var p2choice = player2.GetNextChoice(history.Player2Choices, history.Player1Choices);

                bool didScrewUpPlayer1 = random.NextDouble() >= didItRightChance;
                bool didScrewUpPlayer2 = random.NextDouble() >= didItRightChance;

                if (didScrewUpPlayer1) p1choice = p1choice == Choice.Cheat ? Choice.Coop : Choice.Cheat;
                if (didScrewUpPlayer2) p2choice = p2choice == Choice.Cheat ? Choice.Coop : Choice.Cheat;

                (int p1pts, int p2pts) = (p1choice, p2choice) switch
                {
                    (Choice.Coop, Choice.Coop) => (2, 2),
                    (Choice.Coop, Choice.Cheat) => (-1, 3),
                    (Choice.Cheat, Choice.Coop) => (3, -1),
                    (Choice.Cheat, Choice.Cheat) => (0, 0),
                    _ => throw new InvalidOperationException($"Unknown choices - P1:{p1choice}, P2:{p2choice}")
                };
                history.AddTurn(p1choice, p1pts, p2choice, p2pts);
            }

            return history;
        }
    }
}