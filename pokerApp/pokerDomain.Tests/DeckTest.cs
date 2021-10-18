using NUnit.Framework;

namespace Poker.Domain {
    public class DeckTest {
        [Test]
        public void fillDeckWithCards() {
            Deck Deck = new Deck();
            Assert.AreEqual(52, Deck.GetDeck.Count);
        }
    }

}