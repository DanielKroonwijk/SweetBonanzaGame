using System;
using Information;

namespace SweetBonanzaGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var setGameInfo = new SetGameInfo();
            var gameInfo = setGameInfo.Set();

            var startGame = new StartGame();
            startGame.Start(gameInfo);

            Console.WriteLine();  Console.WriteLine("DONE");
        }
    }
}
