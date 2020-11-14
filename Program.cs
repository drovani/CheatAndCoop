using CheatAndCoop;
using CheatAndCoop.Strategies;
using System;

ConsoleKeyInfo readkey = default(ConsoleKeyInfo);

do
{
    var game1 = GameMaster.CommenceGame(Player.UsingStrategy<Simpleton>(), Player.UsingStrategy<CopyKitten>(), 10, .99);
    Console.WriteLine(game1);
    readkey = Console.ReadKey();
} while (readkey.Key != ConsoleKey.Escape);