using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Domain {
    public class Game {
        private CommunityCards communityCards;
        private Deck deck;
        private Hand hand;
        public IList<Card[]> combinationList { get; private set; }
        public Boolean isStraight { get; private set; }
        public Boolean isFlush { get; private set; }
        public Game() {
            this.communityCards = new CommunityCards();
            this.deck = new Deck();
            this.hand = new Hand();
            this.combinationList = new List<Card[]>();
            this.isStraight = false;
            this.isFlush = false;
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
        public void IsStraight(Card[] cards) {
            if (
                cards[0].GetRankValue()+1 == cards[1].GetRankValue() && 
                cards[1].GetRankValue()+1 == cards[2].GetRankValue() &&
                cards[2].GetRankValue()+1 == cards[3].GetRankValue() &&
                cards[3].GetRankValue()+1 == cards[4].GetRankValue()) 
            {
                this.isStraight = true;
            } else if (
                cards[0].GetRankValue()+1 == cards[1].GetRankValue() && 
                cards[1].GetRankValue()+1 == cards[2].GetRankValue() && 
                cards[2].GetRankValue()+1 == cards[3].GetRankValue() && 
                cards[3].GetRankValue()+9 == cards[4].GetRankValue()) 
            {
                this.isStraight = true;
            }
        }
        public void IsFlush(Card[] cards) {
            if (
                cards[0].GetSuitValue() == cards[1].GetSuitValue() &&
                cards[1].GetSuitValue() == cards[2].GetSuitValue() &&
                cards[2].GetSuitValue() == cards[3].GetSuitValue() &&
                cards[3].GetSuitValue() == cards[4].GetSuitValue()
            ) {
                this.isFlush = true;
            }
        }
        public String CheckStraightFlush(Card[] cards) {
            Console.WriteLine(isStraight);
            Console.WriteLine(isFlush);
            if (isStraight) {
                if (isFlush) {
                    if (cards[3].rank == Ranks.KING && cards[4].rank == Ranks.ACE) {
                        return "royal";
                    } else {
                        return "straight flush";
                    }
                }
            }
            return "straight";
        }



        //ENUM Hand sterkte
        //combinatie van de CCards en Hand

        //loop door de lijst heen
        //sorteer op rank
        //is het een straight (bool)?
        //is het een flush (bool)?
        //check overige

        //return sterkte van de hand
        //sterkte hoger dan de vorige? -> vervang


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