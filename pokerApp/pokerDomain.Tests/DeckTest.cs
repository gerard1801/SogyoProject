using NUnit.Framework;

namespace poker {
    public class DeckTest {
        [Test]
        public void fillDeckWithCards() {
            Deck deck = new Deck();
            Assert.AreEqual(52, deck.getDeck().Count);
        }
    }

}