using System;
using System.Collections;

namespace Poker.Domain {
    public class Deck {
        public Stack GetDeck { get; }

        public Deck() {
            this.GetDeck = fillDeckWithCards();
        }
        private Stack fillDeckWithCards() {
            Stack tempDeck = new Stack();
            foreach(Suits suit in Enum.GetValues(typeof(Suits))){
                foreach(Ranks rank in Enum.GetValues(typeof(Ranks))) {
                    tempDeck.Push(new Card(suit, rank));
                }
            }
            return tempDeck;
        }

        public Card getTopCardFromDeck() {
            return (Card) this.GetDeck.Peek();
        }
    }
}