using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Domain {

    public enum HandStrength {
        RoyalFlush, StraightFlush, FourOfAKind, FullHouse, Flush, Straight,
        ThreeOfAKind, TwoPair, Pair, HighCard
    }
    public class Game {
        private CommunityCards communityCards;
        private Deck deck;
        private Hand hand;
        public IList<Card[]> combinationList { get; private set; }
        public Game() {
            this.communityCards = new CommunityCards();
            this.deck = new Deck();
            this.hand = new Hand();
            this.combinationList = new List<Card[]>();
        }
        public void CreateCombinations(CommunityCards communityCards, Hand hand) {
            var tempCombinationList = communityCards.communityCards.Concat(hand.hand).DifferentCombinations(5);
            var cardList = new List<Card[]>();
            foreach (var list in tempCombinationList) {
                cardList.Add(SortCardListOnRank(list.ToArray()));
            }
            this.combinationList = (IList<Card[]>)cardList;
        }
        public Card[] SortCardListOnRank(Card[] cardList) {
            return cardList.OrderBy(card => card.rank).ToArray();
        }
        public Boolean IsStraight(Card[] cards) {
            if (
                cards[0].GetRankValue()+1 == cards[1].GetRankValue() && 
                cards[1].GetRankValue()+1 == cards[2].GetRankValue() &&
                cards[2].GetRankValue()+1 == cards[3].GetRankValue() &&
                cards[3].GetRankValue()+1 == cards[4].GetRankValue()) 
            {
                return true;
            } else if (
                cards[0].GetRankValue()+1 == cards[1].GetRankValue() && 
                cards[1].GetRankValue()+1 == cards[2].GetRankValue() && 
                cards[2].GetRankValue()+1 == cards[3].GetRankValue() && 
                cards[3].GetRankValue()+9 == cards[4].GetRankValue()) 
            {
                return true;
            } else {
                return false;
            }
        }
        public Boolean IsFlush(Card[] cards) {
            if (
                cards[0].GetSuitValue() == cards[1].GetSuitValue() &&
                cards[1].GetSuitValue() == cards[2].GetSuitValue() &&
                cards[2].GetSuitValue() == cards[3].GetSuitValue() &&
                cards[3].GetSuitValue() == cards[4].GetSuitValue()
            ) {
                return true;
            } else {
                return false;
            }
        }

        public IDictionary<Enum, int> CountCardOccurences(Card[] cards) {
            IDictionary<Enum, int> cardCount = new Dictionary<Enum, int>();
            foreach (var card in cards) {
                if (cardCount.ContainsKey(card.rank)) {
                    cardCount[card.rank]++;
                } else {
                    cardCount.Add(card.rank, 1);
                }
            }
            return cardCount;
        }

        public Boolean IsFourOfAKind(IDictionary<Enum, int> cardCount) {
            if (cardCount.Values.Max() == 4 && cardCount.Values.Min() == 1) {
                return true;
            } else {
                return false;
            }
        }

        public Boolean IsFullHouse(IDictionary<Enum, int> cardCount) {
            if (cardCount.Values.Max() == 3 && cardCount.Values.Min() == 2) {
                return true;
            } else {
                return false;
            }
        }

        public Boolean IsThreeOfAKind(IDictionary<Enum, int> cardCount) {
            if (cardCount.Values.Max() == 3 && cardCount.Values.Min() == 1) {
                return true;
            } else {
                return false;
            }
        }

        public int pairCounter(IDictionary<Enum, int> cardCount) {
            int pairCounter = 0;
            foreach ( var kv in cardCount) {
                if (kv.Value == 2) {
                    pairCounter++;
                }
            }
            return pairCounter;
        }

        public HandStrength CheckHandStrength(Card[] cards) {
            var cardCountDictionary = CountCardOccurences(cards);
            if (IsStraight(cards) && IsFlush(cards)) {
                if (cards[3].rank == Ranks.KING && cards[4].rank == Ranks.ACE) {
                    return HandStrength.RoyalFlush;
                } else {
                    return HandStrength.StraightFlush;
                }
            } else if (IsFourOfAKind(cardCountDictionary)) {
                return HandStrength.FourOfAKind;
            } else if (IsFullHouse(cardCountDictionary)) {
                return HandStrength.FullHouse;
            } else if (IsFlush(cards)) {
                return HandStrength.Flush;
            } else if (IsStraight(cards)) {
                return HandStrength.Straight;
            } else if (IsThreeOfAKind(cardCountDictionary)) {
                return HandStrength.ThreeOfAKind;
            } else if (pairCounter(cardCountDictionary) == 2) {
                return HandStrength.TwoPair;
            } else if (pairCounter(cardCountDictionary) == 1) {
                return HandStrength.Pair;
            } else {
                return HandStrength.HighCard;
            }   
        }
    }
}

public static class Ex
{
    public static IEnumerable<IEnumerable<T>> DifferentCombinations<T>(this IEnumerable<T> elements, int k)
    {
        return k == 0 ? new[] { new T[0] } :
          elements.SelectMany((e, i) =>
            elements.Skip(i + 1).DifferentCombinations(k - 1).Select(c => (new[] {e}).Concat(c)));
    }
}