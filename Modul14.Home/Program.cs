using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul14.Home
{
    internal class Program
    {
        public static Dictionary<string, int> CalculateWordFrequency(string text)
        {
            var wordFrequency = new Dictionary<string, int>();
            var words = text.Split(new char[] { ' ', '.', ',', '!', '?', ':', ';', '\n', '\r', '-', '—', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                var lowerCaseWord = word.ToLower(); // Приведение слов к нижнему регистру для унификации

                if (!wordFrequency.ContainsKey(lowerCaseWord))
                {
                    wordFrequency[lowerCaseWord] = 1;
                }
                else
                {
                    wordFrequency[lowerCaseWord]++;
                }
            }

            return wordFrequency;
        }
        public static void DisplayWordFrequency(Dictionary<string, int> wordFrequency)
        {
            Console.WriteLine("Слово\tЧастота");
            foreach (var pair in wordFrequency)
            {
                Console.WriteLine($"{pair.Key}\t{pair.Value}");
            }
        }

        static void Main(string[] args)
        {
            string text = "Вот дом, Который построил Джек. А это пшеница, Которая в темном чулане хранится В доме, Который построил Джек. ..."; // Продолжение вашего текста
            var wordFrequency = CalculateWordFrequency(text);
            DisplayWordFrequency(wordFrequency);
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

        }
    }
}
