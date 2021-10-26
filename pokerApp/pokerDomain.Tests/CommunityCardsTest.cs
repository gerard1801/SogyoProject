using System;
using NUnit.Framework;

namespace Poker.Domain {
    public class CommunityCardsTest {
        [Test]
        public void AddCardToCommunityCards() {
            Card card = new Card(Suits.CLUBS, Ranks.ACE);
            CommunityCards communityCards = new CommunityCards();
            communityCards.RecieveCard(card);
            Assert.AreEqual(Suits.CLUBS, communityCards.communityCards[0].suit);
            Assert.AreEqual(Ranks.ACE, communityCards.communityCards[0].rank);
        }

        [Test]
        public void Add5CardsToCommunityCards() {
            Card card = new Card(Suits.CLUBS, Ranks.ACE);
            CommunityCards communityCards = new CommunityCards();
            communityCards.RecieveCard(card);
            communityCards.RecieveCard(card);
            communityCards.RecieveCard(card);
            communityCards.RecieveCard(card);
            communityCards.RecieveCard(card);
            Assert.AreEqual(5, communityCards.communityCards.Count);
        }
    }
}