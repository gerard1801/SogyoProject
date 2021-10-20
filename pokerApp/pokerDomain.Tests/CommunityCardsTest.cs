using System;
using NUnit.Framework;

namespace Poker.Domain {
    public class CommunityCardsTest {
        [Test]
        public void AddCardToCommunityCards() {
            Card card = new Card(Suits.CLUBS, Ranks.ACE);
            CommunityCards communityCards = new CommunityCards();
            communityCards.recieveCard(card);
            Assert.AreEqual(Suits.CLUBS, communityCards.communityCards[0].GetSuit);
            Assert.AreEqual(Ranks.ACE, communityCards.communityCards[0].GetRank);
        }

        [Test]
        public void Add5CardsToCommunityCards() {
            Card card = new Card(Suits.CLUBS, Ranks.ACE);
            CommunityCards communityCards = new CommunityCards();
            communityCards.recieveCard(card);
            communityCards.recieveCard(card);
            communityCards.recieveCard(card);
            communityCards.recieveCard(card);
            communityCards.recieveCard(card);
            Assert.AreEqual(5, communityCards.communityCards.Count);
        }
    }
}