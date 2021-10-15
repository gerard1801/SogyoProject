using NUnit.Framework;

namespace poker {
    public class Tests {
        [Test]
        public void cardReturnsASuit()
        {   
            Card card = new Card(Suits.CLUBS, Ranks.ACE);
            Assert.AreEqual(Suits.CLUBS, card.getSuit());
        }

        [Test]
        public void cardReturnsARank() {
            Card card = new Card(Suits.CLUBS, Ranks.ACE);
            Assert.AreEqual(Ranks.ACE, card.getRank());
        }

        [Test]
        public void getRankValueFromEnum() {
            Card card = new Card(Suits.CLUBS, Ranks.ACE);
            Assert.AreEqual(1, card.getRankValue());
        }
    }
}