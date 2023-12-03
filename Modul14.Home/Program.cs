using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul14.Home
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.AddPlayer("Игрок 1");
            game.AddPlayer("Игрок 2");
            game.DealCards();
            while (!game.IsGameOver())
            {
                game.PlayRound();
            }
            Player winner = game.GetWinner();
            Console.WriteLine($"Победитель: {winner.Name}");
            Console.ReadKey();
        }
    }
}
