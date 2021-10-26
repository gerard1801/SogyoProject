using NUnit.Framework;
using System.Collections.Generic;

namespace Poker.Domain {
    public class DeckTest {
        [Test]
        public void FillDeckWithCards() {
            Deck deck = new Deck();
            Assert.AreEqual(52, deck.deck.Count);
        }

        [Test]
        public void TestTopCardFromDeck() {
            Deck deck = new Deck();
            Card card = deck.GetTopCardFromDeck();
            Assert.AreEqual(Ranks.KING, card.rank);
            Assert.AreEqual(Suits.SPADES, card.suit);
        }

        [Test]
        public void RemoveTopCardFromDeck() {
            Deck deck = new Deck();
            deck.RemoveTopCardFromDeck();
            Assert.AreEqual(51, deck.deck.Count);
        }

        [Test]
        public void ConvertIlistToStackInConstructor() {
            IList<Card> deckList = new List<Card>();
            deckList.Add(new Card(Suits.CLUBS, Ranks.ACE));
            deckList.Add(new Card(Suits.DIAMONDS, Ranks.THREE));
            Deck deck = new Deck(deckList);
            Assert.AreEqual(2, deck.deck.Count);
            Assert.AreEqual(true, deck.deck is Stack<Card>);
        }

        [Test]
        public void GiveTopCardToPlayerHand() {
            Deck deck = new Deck();
            Card card = deck.GetTopCardFromDeck();
            
        }

        [Test]
        public void ShuffleDeck() {
            //
        }
    }

}