using System;
using System.Collections.Generic;

namespace Poker.Domain {
    public class CommunityCards {
        public List<Card> communityCards { get; } 
        private readonly int MaxCCLength = 5;
        public CommunityCards() {
            this.communityCards = new List<Card>();
        }

        public void RecieveCard(Card card) {
            if (this.communityCards.Count < MaxCCLength) {
                this.communityCards.Add(card);
            } else {
                throw new Exception("communityCards can only contain 5 cards!");
            }
        }
    }
}