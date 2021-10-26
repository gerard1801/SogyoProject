using System;
using NUnit.Framework;

namespace Poker.Domain {
    public class HandTests {
        [Test]
        public void HandCanRecieveCard() {
            Card card = new Card(Suits.CLUBS, Ranks.ACE);
            Hand hand = new Hand();
            hand.RecieveCard(card);
            Assert.AreEqual(Suits.CLUBS, hand.hand[0].suit);
            Assert.AreEqual(Ranks.ACE, hand.hand[0].rank);
        }

        [Test]
        public void HandCanStoreTwoCards() {
            Card card1 = new Card(Suits.CLUBS, Ranks.ACE);
            Card card2 = new Card(Suits.DIAMONDS, Ranks.EIGHT);
            Hand hand = new Hand();
            hand.RecieveCard(card1);
            hand.RecieveCard(card2);
            Assert.AreEqual(Suits.CLUBS, hand.hand[0].suit);
            Assert.AreEqual(Ranks.ACE, hand.hand[0].rank);
            Assert.AreEqual(Suits.DIAMONDS, hand.hand[1].suit);
            Assert.AreEqual(Ranks.EIGHT, hand.hand[1].rank);
        }
    }
}