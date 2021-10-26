using NUnit.Framework;

namespace Poker.Domain {
    public class CardTests {
        [Test]
        public void CardReturnsASuit()
        {   
            Card card = new Card(Suits.CLUBS, Ranks.ACE);
            Assert.AreEqual(Suits.CLUBS, card.suit);
        }

        [Test]
        public void CardReturnsARank() {
            Card card = new Card(Suits.CLUBS, Ranks.ACE);
            Assert.AreEqual(Ranks.ACE, card.rank);
        }

        [Test]
        public void GetRankValueFromEnum() {
            Card card = new Card(Suits.CLUBS, Ranks.ACE);
            Assert.AreEqual(1, card.GetRankValue());
        }

        [Test]
        public void FirstCardHasHigherRankValueThanSecondCard() {
            Card card1 = new Card(Suits.CLUBS, Ranks.THREE);
            Card card2 = new Card(Suits.CLUBS, Ranks.TWO);
            Assert.AreEqual("First", card1.CompareCards(card1, card2));
        }

        [Test]
        public void FirstCardHasLowerRankValueThanSecondCard() {
            Card card1 = new Card(Suits.CLUBS, Ranks.TWO);
            Card card2 = new Card(Suits.CLUBS, Ranks.THREE);
            Assert.AreEqual("Second", card1.CompareCards(card1, card2));
        }

        [Test]
        public void CardAreOfEqualRankValue() {
            Card card1 = new Card(Suits.CLUBS, Ranks.TWO);
            Card card2 = new Card(Suits.DIAMONDS, Ranks.TWO);
            Assert.AreEqual("Equal", card1.CompareCards(card1, card2));
        }
    }
}