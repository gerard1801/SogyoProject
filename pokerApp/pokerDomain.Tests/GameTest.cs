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
            Assert.AreEqual(true, game.IsStraight(cardList));
        }

        [Test]
        public void CardCombinationIsStraightWithAceAsLowestCard() {
            Game game = new Game();
            Card[] cardList = {new Card(Suits.CLUBS, Ranks.TWO), new Card(Suits.CLUBS, Ranks.THREE), 
            new Card(Suits.CLUBS, Ranks.FOUR), new Card(Suits.CLUBS, Ranks.FIVE), new Card(Suits.CLUBS, Ranks.ACE)};
            Assert.AreEqual(true, game.IsStraight(cardList));
        }

        [Test]
        public void CardCombinationIsNotAStraigth() {
            Game game = new Game();
            Card[] cardList = {new Card(Suits.CLUBS, Ranks.TWO), new Card(Suits.CLUBS, Ranks.THREE), 
            new Card(Suits.CLUBS, Ranks.FOUR), new Card(Suits.CLUBS, Ranks.FIVE), new Card(Suits.CLUBS, Ranks.KING)};
            Assert.AreEqual(false, game.IsStraight(cardList));
        }

        [Test]
        public void CardCombinationIsFlush() {
            Game game = new Game();
            Card[] cardList = {new Card(Suits.CLUBS, Ranks.TWO), new Card(Suits.CLUBS, Ranks.THREE), 
            new Card(Suits.CLUBS, Ranks.FOUR), new Card(Suits.CLUBS, Ranks.FIVE), new Card(Suits.CLUBS, Ranks.KING)};
            Assert.AreEqual(true, game.IsFlush(cardList));
        }

        [Test]
        public void CardCombinationIsNotAFlush() {
            Game game = new Game();
            Card[] cardList = {new Card(Suits.SPADES, Ranks.TWO), new Card(Suits.CLUBS, Ranks.THREE), 
            new Card(Suits.CLUBS, Ranks.FOUR), new Card(Suits.CLUBS, Ranks.FIVE), new Card(Suits.CLUBS, Ranks.KING)};
            Assert.AreEqual(false, game.IsFlush(cardList));
        }

        [Test]
        public void CardCombinationIsRoyalFlush() {
            Game game = new Game();
            Card[] cardList = {new Card(Suits.CLUBS, Ranks.TEN), new Card(Suits.CLUBS, Ranks.JACK), 
            new Card(Suits.CLUBS, Ranks.QUEEN), new Card(Suits.CLUBS, Ranks.KING), new Card(Suits.CLUBS, Ranks.ACE)};
            Assert.AreEqual(HandStrength.RoyalFlush, game.CheckHandStrength(cardList));
        }

        [Test]
        public void CardCombinationIsStraightFlush() {
            Game game = new Game();
            Card[] cardList = {new Card(Suits.CLUBS, Ranks.NINE) ,new Card(Suits.CLUBS, Ranks.TEN), 
            new Card(Suits.CLUBS, Ranks.JACK), new Card(Suits.CLUBS, Ranks.QUEEN), new Card(Suits.CLUBS, Ranks.KING)};
            Assert.AreEqual(HandStrength.StraightFlush, game.CheckHandStrength(cardList));
        }

        [Test]
        public void CountCardOccurences() {
            Game game = new Game();
            Card[] cardList = {new Card(Suits.CLUBS, Ranks.NINE) ,new Card(Suits.HEARTS, Ranks.NINE), 
            new Card(Suits.DIAMONDS, Ranks.NINE), new Card(Suits.CLUBS, Ranks.ACE), new Card(Suits.DIAMONDS, Ranks.ACE)};
            var countDict = game.CountCardOccurences(cardList);
            Assert.AreEqual(3, countDict[Ranks.NINE]);
            Assert.AreEqual(2, countDict[Ranks.ACE]);
        }

        [Test]
        public void IsFourOfAKindAsFunction() {
            Game game = new Game();
            Card[] cardList = {new Card(Suits.CLUBS, Ranks.ACE) ,new Card(Suits.DIAMONDS, Ranks.ACE), 
            new Card(Suits.HEARTS, Ranks.ACE), new Card(Suits.SPADES, Ranks.ACE), new Card(Suits.CLUBS, Ranks.KING)};
            var cardCountDictionary = game.CountCardOccurences(cardList);
            Assert.AreEqual(true, game.IsFourOfAKind(cardCountDictionary));
        }

        [Test]
        public void IsFourOfAKindInCheckHandStrengthFunction() {
            Game game = new Game();
            Card[] cardList = {new Card(Suits.CLUBS, Ranks.ACE) ,new Card(Suits.DIAMONDS, Ranks.ACE), 
            new Card(Suits.HEARTS, Ranks.ACE), new Card(Suits.SPADES, Ranks.ACE), new Card(Suits.CLUBS, Ranks.KING)};
            Assert.AreEqual(HandStrength.FourOfAKind, game.CheckHandStrength(cardList));
        }

        [Test]
        public void IsFullHouseAsFunction() {
            Game game = new Game();
            Card[] cardList = {new Card(Suits.CLUBS, Ranks.ACE) ,new Card(Suits.DIAMONDS, Ranks.ACE), 
            new Card(Suits.HEARTS, Ranks.ACE), new Card(Suits.SPADES, Ranks.KING), new Card(Suits.CLUBS, Ranks.KING)};
            var cardCountDictionary = game.CountCardOccurences(cardList);
            Assert.AreEqual(true, game.IsFullHouse(cardCountDictionary));
        }

        [Test]
        public void IsFullHouseInCheckHandStrengthFunction() {
            Game game = new Game();
            Card[] cardList = {new Card(Suits.CLUBS, Ranks.ACE) ,new Card(Suits.DIAMONDS, Ranks.ACE), 
            new Card(Suits.HEARTS, Ranks.ACE), new Card(Suits.SPADES, Ranks.KING), new Card(Suits.CLUBS, Ranks.KING)};
            Assert.AreEqual(HandStrength.FullHouse, game.CheckHandStrength(cardList));
        }

        [Test]
        public void IsFlushInCheckHandStrengthFunction() {
            Game game = new Game();
            Card[] cardList = {new Card(Suits.CLUBS, Ranks.TWO), new Card(Suits.CLUBS, Ranks.THREE), 
            new Card(Suits.CLUBS, Ranks.FOUR), new Card(Suits.CLUBS, Ranks.FIVE), new Card(Suits.CLUBS, Ranks.KING)};
            Assert.AreEqual(HandStrength.Flush, game.CheckHandStrength(cardList));
        }

        [Test]
        public void IsStraightInCheckHandStrengthFunction() {
            Game game = new Game();
            Card[] cardList = {new Card(Suits.HEARTS, Ranks.TWO), new Card(Suits.CLUBS, Ranks.THREE), 
            new Card(Suits.DIAMONDS, Ranks.FOUR), new Card(Suits.SPADES, Ranks.FIVE), new Card(Suits.CLUBS, Ranks.ACE)};
            Assert.AreEqual(HandStrength.Straight, game.CheckHandStrength(cardList));
        }

        [Test]
        public void IsThreeOfAKindAsFunction() {
            Game game = new Game();
            Card[] cardList = {new Card(Suits.CLUBS, Ranks.ACE) ,new Card(Suits.DIAMONDS, Ranks.ACE), 
            new Card(Suits.HEARTS, Ranks.ACE), new Card(Suits.SPADES, Ranks.QUEEN), new Card(Suits.CLUBS, Ranks.KING)};
            var cardCountDictionary = game.CountCardOccurences(cardList);
            Assert.AreEqual(true, game.IsThreeOfAKind(cardCountDictionary));
        }

        [Test]
        public void IsThreeOfAKindInCheckHandStrengthFunction() {
            Game game = new Game();
            Card[] cardList = {new Card(Suits.CLUBS, Ranks.ACE) ,new Card(Suits.DIAMONDS, Ranks.ACE), 
            new Card(Suits.HEARTS, Ranks.ACE), new Card(Suits.SPADES, Ranks.QUEEN), new Card(Suits.CLUBS, Ranks.KING)};
            Assert.AreEqual(HandStrength.ThreeOfAKind, game.CheckHandStrength(cardList));
        }

        [Test]
        public void PairCounterIsTwoPairAsFunction() {
            Game game = new Game();
            Card[] cardList = {new Card(Suits.CLUBS, Ranks.ACE) ,new Card(Suits.DIAMONDS, Ranks.ACE), 
            new Card(Suits.HEARTS, Ranks.QUEEN), new Card(Suits.SPADES, Ranks.QUEEN), new Card(Suits.CLUBS, Ranks.KING)};
            var cardCountDictionary = game.CountCardOccurences(cardList);
            Assert.AreEqual(2, game.pairCounter(cardCountDictionary));
        }

        [Test]
        public void PairCounterIsTwoPairInCheckHandStrengthFunction() {
            Game game = new Game();
            Card[] cardList = {new Card(Suits.CLUBS, Ranks.ACE) ,new Card(Suits.DIAMONDS, Ranks.ACE), 
            new Card(Suits.HEARTS, Ranks.QUEEN), new Card(Suits.SPADES, Ranks.QUEEN), new Card(Suits.CLUBS, Ranks.KING)};
            Assert.AreEqual(HandStrength.TwoPair, game.CheckHandStrength(cardList));
        }

        [Test]
        public void PairCounterIsOnePairAsFunction() {
            Game game = new Game();
            Card[] cardList = {new Card(Suits.CLUBS, Ranks.ACE) ,new Card(Suits.DIAMONDS, Ranks.ACE), 
            new Card(Suits.HEARTS, Ranks.THREE), new Card(Suits.SPADES, Ranks.QUEEN), new Card(Suits.CLUBS, Ranks.KING)};
            var cardCountDictionary = game.CountCardOccurences(cardList);
            Assert.AreEqual(1, game.pairCounter(cardCountDictionary));
        }

        [Test]
        public void PairCounterIsOnePairInCheckHandStrengthFunction() {
            Game game = new Game();
            Card[] cardList = {new Card(Suits.CLUBS, Ranks.ACE) ,new Card(Suits.DIAMONDS, Ranks.ACE), 
            new Card(Suits.HEARTS, Ranks.THREE), new Card(Suits.SPADES, Ranks.QUEEN), new Card(Suits.CLUBS, Ranks.KING)};
            Assert.AreEqual(HandStrength.Pair, game.CheckHandStrength(cardList));
        }

        [Test]
        public void HighCardInHandStrengthFunction() {
            Game game = new Game();
            Card[] cardList = {new Card(Suits.CLUBS, Ranks.ACE) ,new Card(Suits.DIAMONDS, Ranks.TWO), 
            new Card(Suits.HEARTS, Ranks.THREE), new Card(Suits.SPADES, Ranks.QUEEN), new Card(Suits.CLUBS, Ranks.KING)};
            Assert.AreEqual(HandStrength.HighCard, game.CheckHandStrength(cardList));
        }
    }

}