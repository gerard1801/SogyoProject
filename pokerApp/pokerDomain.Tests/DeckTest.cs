using NUnit.Framework;

namespace Poker.Domain {
    public class DeckTest {
        [Test]
        public void FillDeckWithCards() {
            Deck Deck = new Deck();
            Assert.AreEqual(52, Deck.GetDeck.Count);
        }

        [Test]
        public void TestTopCardFromDeck() {
            Deck Deck = new Deck();
            Card Card = Deck.GetTopCardFromDeck();
            Assert.AreEqual(Ranks.KING, Card.GetRank);
            Assert.AreEqual(Suits.SPADES, Card.GetSuit);
        }

        [Test]
        public void RemoveTopCardFromDeck() {
            Deck Deck = new Deck();
            Deck.RemoveTopCardFromDeck();
            Assert.AreEqual(51, Deck.GetDeck.Count);
        }
    }

}