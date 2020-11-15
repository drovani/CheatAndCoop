using CheatAndCoop;
using CheatAndCoop.Strategies;
using CheatAndCoop.Tournaments;
using System;

ConsoleKeyInfo readkey = default(ConsoleKeyInfo);

do
{
    var players = new Player[]
    {
        Player.UsingStrategy<Alternate>(),
        Player.UsingStrategy<CopyCat>(),
        Player.UsingStrategy<CopyKitten>(),
        Player.UsingStrategy<Detective>(),
        Player.UsingStrategy<FiftyFiftyRandom>(),
        Player.UsingStrategy<Grudger>(),
        Player.UsingStrategy<Optimist>(),
        Player.UsingStrategy<Pessimist>(),
        Player.UsingStrategy<Simpleton>(),
    };

    var tournament = new RoundRobin(players);
    var history = tournament.CommenceTournament();

    Console.WriteLine(history);

    readkey = Console.ReadKey(true);
} while (readkey.Key != ConsoleKey.Escape);