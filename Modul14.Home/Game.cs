using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul14.Home
{
    public class Game
    {
        private List<Player> players = new List<Player>();
        private List<Card> deck = new List<Card>();
        private Random random = new Random();

        public Game()
        {
            CreateDeck();
            ShuffleDeck();
        }

        private void CreateDeck()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    deck.Add(new Card(suit, rank));
                }
            }
        }

        private void ShuffleDeck()
        {
            int n = deck.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Card value = deck[k];
                deck[k] = deck[n];
                deck[n] = value;
            }
        }

        public void AddPlayer(string name)
        {
            players.Add(new Player(name));
        }

        public void DealCards()
        {
            int playerCount = players.Count;
            int cardCount = deck.Count / playerCount;

            for (int i = 0; i < cardCount; i++)
            {
                foreach (var player in players)
                {
                    player.AddCard(deck[i + cardCount * players.IndexOf(player)]);
                }
            }
        }

        public bool IsGameOver()
        {
            return players.Any(p => p.Hand.Count == 0);
        }

        public Player GetWinner()
        {
            return players.OrderByDescending(p => p.Hand.Count).FirstOrDefault();
        }

        public void PlayRound()
        {
            var playedCards = new List<Card>();
            foreach (var player in players)
            {
                Card card = player.PlayCard();
                Console.WriteLine($"{player.Name} кладет {card}");
                playedCards.Add(card);
            }
            int winningIndex = DetermineWinner(playedCards);
            Player roundWinner = players[winningIndex];
            Console.WriteLine($"{roundWinner.Name} выигрывает раунд!");
            foreach (var card in playedCards)
            {
                roundWinner.AddCard(card);
            }
        }
        private int DetermineWinner(List<Card> playedCards)
        {
            int winnerIndex = 0;
            Card winningCard = playedCards[0];
            for (int i = 1; i < playedCards.Count; i++)
            {
                if (IsCardHigher(playedCards[i], winningCard))
                {
                    winningCard = playedCards[i];
                    winnerIndex = i;
                }
            }

            return winnerIndex;
        }

        private bool IsCardHigher(Card card1, Card card2)
        {
            if (card1.Rank == Rank.Six && card2.Rank == Rank.Ace)
            {
                return false;
            }
            if (card2.Rank == Rank.Six && card1.Rank == Rank.Ace)
            {
                return true;
            }
            return card1.Rank > card2.Rank;
        }

    }

}
