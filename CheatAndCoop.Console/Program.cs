using CheatAndCoop;
using CheatAndCoop.Strategies;
using System;

ConsoleKeyInfo readkey = default(ConsoleKeyInfo);

do
{
    var game1 = GameMaster.CommenceGame(Player.UsingStrategy<Simpleton>(), Player.UsingStrategy<CopyKitten>());
    Console.WriteLine(game1);
    readkey = Console.ReadKey(true);
} while (readkey.Key != ConsoleKey.Escape);