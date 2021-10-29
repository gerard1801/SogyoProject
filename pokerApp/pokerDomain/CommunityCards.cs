using System;
using System.Collections.Generic;

namespace Poker.Domain {
    public class CommunityCards {
        public IList<Card> communityCards { get; private set; } 
        private readonly int MaxCCLength = 5;
        public CommunityCards() {
            this.communityCards = new List<Card>();
        }

        public CommunityCards(IList<Card> communityCards) {
            this.communityCards = communityCards;
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