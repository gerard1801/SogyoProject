using System;
using System.Collections;

namespace poker {
    public class Deck {
        private Stack deck;

        public Deck() {
            this.deck = fillDeckWithCards();
        }

        public Stack getDeck() {
            return this.deck;
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
            return (Card) this.deck.Peek();
        }
    }
}