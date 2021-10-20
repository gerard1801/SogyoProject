using System;
using System.Collections;
using System.Linq;

namespace Poker.Domain {
    public class Deck {
        public Stack GetDeck { get; }

        public Deck() {
            this.GetDeck = FillDeckWithCards();
        }
        private Stack FillDeckWithCards() {
            Stack tempDeck = new Stack();
            foreach(Suits suit in Enum.GetValues(typeof(Suits))){
                foreach(Ranks rank in Enum.GetValues(typeof(Ranks))) {
                    tempDeck.Push(new Card(suit, rank));
                }
            }
            return tempDeck;
        }

        public Card GetTopCardFromDeck() {
            return (Card) this.GetDeck.Peek();
        }

        public void RemoveTopCardFromDeck() {
            this.GetDeck.Pop();
        }

        public void ShuffleDeck() {
            Random rng = new Random();
            var values = this.GetDeck.ToArray();
            this.GetDeck.Clear();
            foreach (var value in values.OrderBy(x => rng.Next()))
            this.GetDeck.Push(value);
            Console.Write(this.GetDeck);
        }
    }
}