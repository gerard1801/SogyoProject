using NUnit.Framework;

namespace Poker.Domain {
    public class CardTests {
        [Test]
        public void cardReturnsASuit()
        {   
            Card Card = new Card(Suits.CLUBS, Ranks.ACE);
            Assert.AreEqual(Suits.CLUBS, Card.GetSuit);
        }

        [Test]
        public void cardReturnsARank() {
            Card Card = new Card(Suits.CLUBS, Ranks.ACE);
            Assert.AreEqual(Ranks.ACE, Card.GetRank);
        }

        [Test]
        public void getRankValueFromEnum() {
            Card Card = new Card(Suits.CLUBS, Ranks.ACE);
            Assert.AreEqual(1, Card.getRankValue());
        }

        [Test]
        public void FirstCardHasHigherRankValueThanSecondCard() {
            Card Card1 = new Card(Suits.CLUBS, Ranks.THREE);
            Card Card2 = new Card(Suits.CLUBS, Ranks.TWO);
            Assert.AreEqual("First", Card1.CompareCards(Card1, Card2));
        }

        [Test]
        public void FirstCardHasLowerRankValueThanSecondCard() {
            Card Card1 = new Card(Suits.CLUBS, Ranks.TWO);
            Card Card2 = new Card(Suits.CLUBS, Ranks.THREE);
            Assert.AreEqual("Second", Card1.CompareCards(Card1, Card2));
        }

        [Test]
        public void CardAreOfEqualRankValue() {
            Card Card1 = new Card(Suits.CLUBS, Ranks.TWO);
            Card Card2 = new Card(Suits.DIAMONDS, Ranks.TWO);
            Assert.AreEqual("Equal", Card1.CompareCards(Card1, Card2));
        }
    }
}