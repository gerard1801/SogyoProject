using System;
using System.Collections.Generic;


namespace Poker.Domain {
    public class Hand {
        public List<Card> hand { get; } 
        private readonly int MaxHandLenght = 2;
        public Hand() {
            this.hand = new List<Card>();
        }
        public void RecieveCard(Card card) {
            if (this.hand.Count < MaxHandLenght) {
                this.hand.Add(card);
            } else {
                throw new Exception("Hand can only hold two cards!");
            }
        }
    }
}