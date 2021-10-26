using NUnit.Framework;

namespace Poker.Domain {
    public class PlayerTest {
        [Test]
        public void PlayerHasAName() {
            Player player = new Player("gerard");
            Assert.AreEqual("gerard", player.GetPlayerName());
        }

        [Test]
        public void PlayerHasTwoCardsInHand() {
            Player player = new Player("gerard");
            Deck deck = new Deck();
            player.hand.RecieveCard(deck.GetTopCardFromDeck());
            deck.RemoveTopCardFromDeck();
            player.hand.RecieveCard(deck.GetTopCardFromDeck());
            Assert.AreEqual(2, player.hand.hand.Count);
        }
    }
}