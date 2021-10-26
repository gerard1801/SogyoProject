using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Domain {
    public class Deck {
        public Stack<Card> deck { get; }

        public Deck() {
            this.deck = FillDeckWithCards();
        }

        public Deck(IList<Card> deckList) {
            Stack<Card> iListToStack = new Stack<Card>();
            for (int i=deckList.Count; i>0; i--) {
                iListToStack.Push(new Card(deckList[i-1].suit, deckList[i-1].rank));
            }
            this.deck = iListToStack;
        }

        private Stack<Card> FillDeckWithCards() {
            Stack<Card> tempDeck = new Stack<Card>();
            foreach(Suits suit in Enum.GetValues(typeof(Suits))){
                foreach(Ranks rank in Enum.GetValues(typeof(Ranks))) {
                    tempDeck.Push(new Card(suit, rank));
                }
            }
            return tempDeck;
        }

        public Card GetTopCardFromDeck() {
            return (Card) this.deck.Peek();
        }

        public void RemoveTopCardFromDeck() {
            this.deck.Pop();
        }

        public void ShuffleDeck() {
            Random rng = new Random();
            var values = this.deck.ToArray();
            this.deck.Clear();
            foreach (var value in values.OrderBy(x => rng.Next()))
            this.deck.Push(value);
        }
    }
}