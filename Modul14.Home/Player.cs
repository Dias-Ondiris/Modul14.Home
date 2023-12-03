using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul14.Home
{
    public class Player
    {
        public List<Card> Hand { get; private set; }
        public string Name { get; private set; }

        public Player(string name)
        {
            Name = name;
            Hand = new List<Card>();
        }
        public void AddCard(Card card)
        {
            Hand.Add(card);
        }
        public Card PlayCard()
        {
            var card = Hand.FirstOrDefault();
            Hand.Remove(card);
            return card;
        }
        public void DisplayHand()
        {
            foreach (var card in Hand)
            {
                Console.WriteLine(card);
            }
        }
    }

}
