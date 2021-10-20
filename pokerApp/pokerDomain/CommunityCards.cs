using System;
using System.Collections.Generic;

namespace Poker.Domain {
    public class CommunityCards {
        public List<Card> communityCards { get; } 
        private readonly int maxCCLength = 5;
        public CommunityCards() {
            this.communityCards = new List<Card>();
        }

        public void recieveCard(Card card) {
            if (this.communityCards.Count < maxCCLength) {
                this.communityCards.Add(card);
            } else {
                throw new Exception("communityCards can only contain 5 cards!");
            }
        }
    }
}