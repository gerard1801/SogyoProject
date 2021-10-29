using System;
using NUnit.Framework;

namespace Poker.Domain {
    public class GameTests {
        [Test]
        public void CreateListCombinationsOfCommunityCardsAndHand() {
            Deck deck = new Deck();
            CommunityCards communityCards = new CommunityCards();
            Hand hand = new Hand();
            Game game = new Game();
            communityCards.RecieveCard(deck.GetTopCardFromDeck());
            deck.RemoveTopCardFromDeck();
            communityCards.RecieveCard(deck.GetTopCardFromDeck());
            deck.RemoveTopCardFromDeck();
            communityCards.RecieveCard(deck.GetTopCardFromDeck());
            deck.RemoveTopCardFromDeck();
            communityCards.RecieveCard(deck.GetTopCardFromDeck());
            deck.RemoveTopCardFromDeck();
            communityCards.RecieveCard(deck.GetTopCardFromDeck());
            deck.RemoveTopCardFromDeck();
            hand.RecieveCard(new Card(Suits.CLUBS, Ranks.TWO));
            hand.RecieveCard(new Card(Suits.CLUBS, Ranks.THREE));
            
            game.CreateCombinations(communityCards, hand);
            Assert.AreEqual(21, game.combinationList.Count);
        }

        [Test]
        public void SortCardListLowestToHighestRank() {
            Game game = new Game();
            Card[] cardList = {new Card(Suits.CLUBS, Ranks.JACK), new Card(Suits.CLUBS, Ranks.TEN), 
            new Card(Suits.CLUBS, Ranks.KING), new Card(Suits.CLUBS, Ranks.QUEEN), new Card(Suits.CLUBS, Ranks.ACE)};
            Card[] sortedListTest = {new Card(Suits.CLUBS, Ranks.TEN), new Card(Suits.CLUBS, Ranks.JACK), 
            new Card(Suits.CLUBS, Ranks.QUEEN), new Card(Suits.CLUBS, Ranks.KING), new Card(Suits.CLUBS, Ranks.ACE)};
            Assert.AreEqual(sortedListTest[0].rank, game.SortCardListOnRank(cardList)[0].rank);
            Assert.AreEqual(sortedListTest[1].rank, game.SortCardListOnRank(cardList)[1].rank);
            Assert.AreEqual(sortedListTest[2].rank, game.SortCardListOnRank(cardList)[2].rank);
            Assert.AreEqual(sortedListTest[3].rank, game.SortCardListOnRank(cardList)[3].rank);
            Assert.AreEqual(sortedListTest[4].rank, game.SortCardListOnRank(cardList)[4].rank);
        }

        [Test]
        public void CardCombinationIsStraightWithAceAsHighestCard() {
            Game game = new Game();
            Card[] cardList = {new Card(Suits.CLUBS, Ranks.TEN), new Card(Suits.CLUBS, Ranks.JACK), 
            new Card(Suits.CLUBS, Ranks.QUEEN), new Card(Suits.CLUBS, Ranks.KING), new Card(Suits.CLUBS, Ranks.ACE)};
            game.IsStraight(cardList);
            Assert.AreEqual(true, game.isStraight);
        }

        [Test]
        public void CardCombinationIsStraightWithAceAsLowestCard() {
            Game game = new Game();
            Card[] cardList = {new Card(Suits.CLUBS, Ranks.TWO), new Card(Suits.CLUBS, Ranks.THREE), 
            new Card(Suits.CLUBS, Ranks.FOUR), new Card(Suits.CLUBS, Ranks.FIVE), new Card(Suits.CLUBS, Ranks.ACE)};
            game.IsStraight(cardList);
            Assert.AreEqual(true, game.isStraight);
        }

        [Test]
        public void CardCombinationIsNotAStraigth() {
            Game game = new Game();
            Card[] cardList = {new Card(Suits.CLUBS, Ranks.TWO), new Card(Suits.CLUBS, Ranks.THREE), 
            new Card(Suits.CLUBS, Ranks.FOUR), new Card(Suits.CLUBS, Ranks.FIVE), new Card(Suits.CLUBS, Ranks.KING)};
            game.IsStraight(cardList);
            Assert.AreEqual(false, game.isStraight);
        }

        [Test]
        public void CardCombinationIsFlush() {
            Game game = new Game();
            Card[] cardList = {new Card(Suits.CLUBS, Ranks.TWO), new Card(Suits.CLUBS, Ranks.THREE), 
            new Card(Suits.CLUBS, Ranks.FOUR), new Card(Suits.CLUBS, Ranks.FIVE), new Card(Suits.CLUBS, Ranks.KING)};
            game.IsFlush(cardList);
            Assert.AreEqual(true, game.isFlush);
        }

        [Test]
        public void CardCombinationIsNotAFlush() {
            Game game = new Game();
            Card[] cardList = {new Card(Suits.SPADES, Ranks.TWO), new Card(Suits.CLUBS, Ranks.THREE), 
            new Card(Suits.CLUBS, Ranks.FOUR), new Card(Suits.CLUBS, Ranks.FIVE), new Card(Suits.CLUBS, Ranks.KING)};
            game.IsFlush(cardList);
            Assert.AreEqual(false, game.isFlush);
        }

        [Test]
        public void CardCombinationIsRoyalFlush() {
            Game game = new Game();
            Card[] cardList = {new Card(Suits.CLUBS, Ranks.TEN), new Card(Suits.CLUBS, Ranks.JACK), 
            new Card(Suits.CLUBS, Ranks.QUEEN), new Card(Suits.CLUBS, Ranks.KING), new Card(Suits.CLUBS, Ranks.ACE)};
            game.IsStraight(cardList);
            game.IsFlush(cardList);
            Assert.AreEqual("royal", game.CheckStraightFlush(cardList));
        }

        [Test]
        public void CardCombinationIsStraightFlush() {
            Game game = new Game();
            Card[] cardList = {new Card(Suits.CLUBS, Ranks.NINE) ,new Card(Suits.CLUBS, Ranks.TEN), 
            new Card(Suits.CLUBS, Ranks.JACK), new Card(Suits.CLUBS, Ranks.QUEEN), new Card(Suits.CLUBS, Ranks.KING)};
            game.IsStraight(cardList);
            game.IsFlush(cardList);
            Assert.AreEqual("straight flush", game.CheckStraightFlush(cardList));
        }
    }

}